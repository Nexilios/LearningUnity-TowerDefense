using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Transform _target;
    private Enemy _enemyComp;
    private int _wavePointIndex;
    
    void Start()
    {
        _enemyComp = GetComponent<Enemy>();
        _target = Waypoints.Points[0];
    }
    
    void Update()
    {
        Vector3 direction = _target.position - transform.position;
        transform.Translate(direction.normalized * (_enemyComp.moveSpeed * Time.deltaTime), Space.World);

        if (Vector3.Distance(transform.position, _target.position) <= 0.3f)
        {
            GetNextWaypoint();
        }

        _enemyComp.moveSpeed = _enemyComp.startSpeed;
    }

    void GetNextWaypoint()
    {
        if (_wavePointIndex >= Waypoints.Points.Length - 1)
        {
            EndPath();
            return;
        }
        _wavePointIndex++;
        _target = Waypoints.Points[_wavePointIndex];
    }

    void EndPath()
    {
        PlayerStats.Lives--;
        WaveSpawner.enemiesAlive--;
        Destroy(gameObject);
    }
}
