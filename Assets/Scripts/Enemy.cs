using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    
    [HideInInspector]
    public float moveSpeed;
    
    public float health = 100;
    public int worth = 50;
    
    public GameObject deathEffect;

    private bool _dead;
    
    void Start()
    {
        moveSpeed = startSpeed;
    }
    
    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            if (!_dead)
                Die();
        }
    }

    public void Slow(float slowAmount)
    {
        moveSpeed = startSpeed * (1f - slowAmount);
    }

    void Die()
    {
        _dead = true;
        PlayerStats.Money += worth;
        
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        
        Destroy(gameObject);
    }
}
