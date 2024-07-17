using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

[RequireComponent(typeof(Renderer))]
public class Spawner : MonoBehaviour
{
    [Min(0.1f)][SerializeField] private float _timeSpawn;
    [SerializeField] private Enemy _objectPrefab;
    [SerializeField] private Material _material;
    [SerializeField] private TaregetObject _targetObject;

    private bool _isSpawn = true;

    public ObjectPool<Enemy> Pool { get; private set; }

    private void Start()
    {
        Pool = new ObjectPool<Enemy>(CreateObject);

        GetComponent<Renderer>().material = _material;

        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        WaitForSeconds wait = new WaitForSeconds(_timeSpawn);

        while (_isSpawn)
        {
            Enemy spawnerObject = Pool.Get();

            Vector3 position = GetSpawnPosition();

            spawnerObject.Initialize(position, _targetObject, _material, this);

            yield return wait;
        }
    }

    private Vector3 GetSpawnPosition()
    {
        float yUp = 2f;

        Vector3 bounds = GetComponent<Collider>().bounds.extents;
        Vector3 positionS = transform.position;

        float x = Random.Range(positionS.x - bounds.x, positionS.x + bounds.x);
        float y = gameObject.transform.position.y + yUp;
        float z = Random.Range(positionS.z - bounds.z, positionS.z + bounds.z);

        Vector3 position = new Vector3(x, y, z);

        return position;
    }

    private Enemy CreateObject()
    {
        return Instantiate(_objectPrefab);
    }
}
