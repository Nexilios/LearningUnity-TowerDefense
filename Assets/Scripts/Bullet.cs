using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform _target;
    public GameObject impactEffect;
    public float speed = 70f;
    public float explosionRadius;
    public int damage = 50;
    
    public void SetTarget(Transform target)
    {
        _target = target;
    }
    
    void Update()
    {
        if (!_target)
        {
            Destroy(gameObject);
            return;
        }
        
        Vector3 dir = _target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(_target);
    }

    void HitTarget()
    {
        GameObject effectIns =  Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 5f);

        if (explosionRadius > 0f)
        {
            Explode();    
        }
        else
        {
            Damage(_target);
        }
        
        Destroy(gameObject);
    }
    void Explode()
    {
        Collider[] colliders = new Collider[15];
        Physics.OverlapSphereNonAlloc(transform.position, explosionRadius, colliders);
        foreach (Collider col in colliders)
        {
            if (!col) continue;
            
            if (col.CompareTag("Enemy"))
            {
                Damage(col.transform);
            }
        }
    }

    void Damage(Transform enemy)
    {
        Enemy enemyComp = enemy.GetComponent<Enemy>();
        if (enemyComp)
        {
            enemyComp.TakeDamage(damage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
