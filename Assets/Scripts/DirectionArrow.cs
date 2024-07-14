using UnityEngine;

public class DirectionArrow : MonoBehaviour
{
    public Vector3 Angle {get; private set;}

    public void SetTurnAngle()
    {
        float minAngle = 0;
        float maxAngle = 360;

        float x = gameObject.transform.eulerAngles.x;
        float y = Random.Range(minAngle, maxAngle);
        float z = gameObject.transform.eulerAngles.z;

        Angle = new Vector3(x, y, z);

        transform.rotation = Quaternion.Euler(Angle);
    }
}
