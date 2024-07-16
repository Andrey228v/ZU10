using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private int _size = 1;
    [SerializeField] private float _speed = 2f;

    private TaregetObject _taregetObject;

    private void Update()
    {
        float step = _speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, _taregetObject.transform.position, step);
    }

    public void Initialize(Vector3 position,TaregetObject target, Material material)
    {
        transform.position = position;
        GetComponent<Renderer>().material = material;
        _taregetObject = target;
    }
}
