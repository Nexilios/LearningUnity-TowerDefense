using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 10f;
    
    public int health = 100;
    public int moneyValue = 50;
    
    public GameObject deathEffect;
    
    private Transform _target;
    private int _wavePointIndex;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        PlayerStats.Money += moneyValue;
        
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        
        Destroy(gameObject);
    }
    
    void Start()
    {
        _target = Waypoints.Points[0];
    }

    void Update()
    {
        Vector3 direction = _target.position - transform.position;
        transform.Translate(direction.normalized * (moveSpeed * Time.deltaTime), Space.World);

        if (Vector3.Distance(transform.position, _target.position) <= 0.3f)
        {
            GetNextWaypoint();
        }
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
        PlayerStats.Lives --;
        Destroy(gameObject);
    }
}
