using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private int _size = 1;
    [SerializeField] private float _speed = 2f;

    private TaregetObject _taregetObject;
    private Spawner _spawner;
    private Renderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        float step = _speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, _taregetObject.transform.position, step);
    }

    private void OnDestroy()
    {
        _spawner.Pool.Release(this);
    }

    public void Initialize(Vector3 position,TaregetObject target, Material material, Spawner spawner)
    {
        transform.position = position;
        _renderer.material = material;
        _taregetObject = target;
        _spawner = spawner;
    }
}
