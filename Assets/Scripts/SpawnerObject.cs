using System;
using UnityEngine;

public class SpawnerObject : MonoBehaviour
{
    [SerializeField] private int _size = 1;
    [SerializeField] private float _speed = 2f;

    public event Action<Vector3> Test;

    private void Update()
    {
        transform.position += transform.forward * _speed * Time.deltaTime;
    }

    public void SetDirection(Vector3 angle)
    {
        transform.rotation = Quaternion.Euler(angle);
    }
}
