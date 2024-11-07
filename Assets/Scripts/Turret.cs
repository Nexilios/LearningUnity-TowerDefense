using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform _target;
    
    [Header("Attribute")]
    public float range = 15f;
    public float fireRate = 1f;
    public float turnSpeed = 5f;
    private float _fireCountdown;
    private Quaternion _originalRotation;
    
    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";
    public Transform partToRotate;
    public GameObject bulletPrefab;
    public Transform firePoint;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (partToRotate)
        {
            _originalRotation = partToRotate.rotation;
        }
        
        InvokeRepeating(nameof(UpdateTarget), 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy && shortestDistance <= range)
        {
            _target = nearestEnemy.transform;
        }
        else
        {
            _target = null;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (!_target)
        {
            if (partToRotate && partToRotate.rotation != _originalRotation)
            {
                partToRotate.rotation = Quaternion.Lerp(partToRotate.rotation, _originalRotation, Time.deltaTime * turnSpeed);
            }
            return;
        }
        
        Vector3 dir = _target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (_fireCountdown <= 0f)
        {
            Shoot();
            _fireCountdown = 1f / fireRate;    
        }
        
        _fireCountdown -= Time.deltaTime;
    }

    void Shoot()
    {
        GameObject bulletObj = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletObj.GetComponent<Bullet>();

        if (bullet)
        {
            bullet.SetTarget(_target);
        }
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
