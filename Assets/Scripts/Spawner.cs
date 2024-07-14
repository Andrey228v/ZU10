using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
{
    [Min(0.1f)][SerializeField] private float _timeSpawn;
    [SerializeField] private SpawnerObject _objectPrefab;
    [SerializeField] private Material _material;
    [SerializeField] private DirectionArrow _directionArrowPrefab;

    private Renderer _renderer;
    private DirectionArrow _directionArrow;
    private bool _isSpawn = true;

    public ObjectPool<SpawnerObject> Pool { get; private set; }

    private void Start()
    {
        CreateDirectionArrow();

        Pool = new ObjectPool<SpawnerObject>(CreateObject);

        _renderer = GetComponent<Renderer>();
        _renderer.material = _material;

        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (_isSpawn)
        {
            SpawnerObject spawnerObject = Pool.Get();
            spawnerObject.transform.position = GetSpawnPosition();
            spawnerObject.SetDirection(_directionArrow.Angle);

            spawnerObject.GetComponent<Renderer>().material = _material;

            yield return new WaitForSeconds(_timeSpawn);
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

    private SpawnerObject CreateObject()
    {
        return Instantiate(_objectPrefab);
    }

    private void CreateDirectionArrow()
    {
        float yUp = 15f;

        _directionArrow = Instantiate(_directionArrowPrefab);
        _directionArrow.SetTurnAngle();

        float x = gameObject.transform.position.x;
        float y = gameObject.transform.position.y + yUp;
        float z = gameObject.transform.position.z;

        _directionArrow.transform.position = new Vector3(x, y, z);
    }
}
