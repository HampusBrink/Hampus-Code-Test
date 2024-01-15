using UnityEngine;
using Random = UnityEngine.Random;

public class CubeMovement : MonoBehaviour
{
    private Rigidbody _rb;

    private CubeManager _manager;
    
    [Header("Properties")] [SerializeField]
    private float _sphereRadius = 5f;
    
    [SerializeField] 
    private float _sphereOffset = 5f;
    
    [SerializeField] 
    private float _speed = 5f;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _manager = CubeManager.Instance;
    }

    private void Update()
    {
        _rb.AddForce(new Vector3(Random.Range(-_speed,_speed),Random.Range(-_speed,_speed),Random.Range(-_speed,_speed)));

        var hits = Physics.OverlapSphere(transform.position + Vector3.forward * _sphereOffset, _sphereRadius);
        
        foreach (var hit in hits)
        {
            if(hit.gameObject == gameObject)
                break;
            _manager.ReSpawnCube();
            Destroy(hit.gameObject);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rb.AddForce(new Vector3(0,100,0));
        }

        if (transform.position.y <= -20)
        {
            _manager.ReSpawnCube();
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position+ Vector3.forward * _sphereOffset, _sphereRadius);
    }
}
