using System.Collections.Generic;
using UnityEngine;

public class TaregetObject : MonoBehaviour
{
    [SerializeField] private List<Vector3> _points;
    [SerializeField] private float _speed;

    private int _point = 0;

    private void Update()
    {
       if(transform.position == _points[_point])
       {
            _point = ++ _point % _points.Count;
        }
       else
       {
            float step = _speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, _points[_point], step);
       }
    }
}
