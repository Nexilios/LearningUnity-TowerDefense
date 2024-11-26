using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [HideInInspector]
    public float moveSpeed;
    
    public float startSpeed = 10f;
    public float startHealth = 100f;
    public int worth = 50;
    public GameObject deathEffect;

    private float _health;
    private bool _dead;

    [Header("Unity Code References")] 
    public Image healthBar;
    
    void Start()
    {
        moveSpeed = startSpeed;
        _health = startHealth;
    }
    
    public void TakeDamage(float damage)
    {
        _health -= damage;
        
        healthBar.fillAmount = _health/startHealth;

        if (_health <= 0 && !_dead) 
            Die();
        
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
