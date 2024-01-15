using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class CubeManager : MonoBehaviour
{
    [SerializeField] private GameObject Cube;
    [SerializeField] private int _startAmount = 20;
    [SerializeField] private float _timeBetweenSpawn = 1f;
    [SerializeField] private float _respawnTime = 1f;

    private static CubeManager _instance;

    public static CubeManager Instance => _instance;


    private void Awake()
    {
        if (_instance == null)
            _instance = this;
    }

    IEnumerator CO_AutoSpawner()
    {
        while (true)
        {
            SpawnCube();
            yield return new WaitForSeconds(_timeBetweenSpawn);
        }
    }

    private void Start()
    {
        for (int i = 0; i < _startAmount; i++)
        {
            SpawnCube();
        }
        StartCoroutine(CO_AutoSpawner());
    }

    public void SpawnCube()
    {
        Instantiate(Cube, new Vector3(Random.Range(0,50),Random.Range(0,50),Random.Range(0,50)),Quaternion.identity);
    }
    
    public void ReSpawnCube()
    {
        StartCoroutine(CO_SpawnCubeWithDelay(_respawnTime));
    }

    IEnumerator CO_SpawnCubeWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SpawnCube();
    }

}
