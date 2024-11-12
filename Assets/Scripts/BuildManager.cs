using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager Instance;
    
    private TurretBlueprint _turretToBuild;
    public bool CanBuildTurret => _turretToBuild != null;

    void Awake()
    {
        if (!Instance)
            Instance = this;
    }
    
    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        _turretToBuild = turret;
    }

    public void BuildTurret(Node node)
    {
        if (PlayerStats.Money < _turretToBuild.cost)
        {
            Debug.Log("Not enough money to build turret");
            return;
        }
        
        PlayerStats.Money -= _turretToBuild.cost;
        GameObject turret = Instantiate(_turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;
        
        Debug.Log("Turret Built! Money left: " + PlayerStats.Money);
    }
}
