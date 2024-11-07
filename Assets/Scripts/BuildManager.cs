using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager Instance;

    public GameObject standardTurretPrefab;
    
    private GameObject _turretToBuild;

    void Awake()
    {
        if (!Instance)
            Instance = this;
    }

    void Start()
    {
        _turretToBuild = standardTurretPrefab;
    }
    
    public GameObject GetTurretToBuild()
    {
        return _turretToBuild;
    }
}
