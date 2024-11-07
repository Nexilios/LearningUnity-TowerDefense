using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform _target;
    public GameObject impactEffect;
    public float speed = 70f;
    
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
    }

    void HitTarget()
    {
        GameObject effectIns =  Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);
        Destroy(_target.gameObject);
        Destroy(gameObject);
    }
}
