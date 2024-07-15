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
            _point = GetPoint();
       }
       else
       {
            float step = _speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, _points[_point], step);
       }
    }

    private int GetPoint()
    {
        int nextPoint;

        if(_point == _points.Count - 1)
        {
            nextPoint = 0;
        }
        else
        {
            _point++;
            nextPoint = _point;
        }

        return nextPoint;
    }
}
