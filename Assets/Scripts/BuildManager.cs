using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager Instance;

    public GameObject standardTurretPrefab;
    public GameObject anotherTurretPrefab;
    
    private GameObject _turretToBuild;

    void Awake()
    {
        if (!Instance)
            Instance = this;
    }
    
    public GameObject GetTurretToBuild()
    {
        return _turretToBuild;
    }

    public void SetTurretToBuild(GameObject turret)
    {
        _turretToBuild = turret;
    }
}
