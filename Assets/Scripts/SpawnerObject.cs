using UnityEngine;

public class SpawnerObject : MonoBehaviour
{
    [SerializeField] private int _size = 1;
    [SerializeField] private float _speed = 2f;

    private TaregetObject _taregetObject;

    private void Update()
    {
        float step = _speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, _taregetObject.transform.position, step);
    }

    public void SetTarget(TaregetObject target) 
    {
        _taregetObject = target;
    }
}
