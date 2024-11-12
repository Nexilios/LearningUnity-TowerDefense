using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager _buildManager;
    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;

    void Start()
    {
        _buildManager = BuildManager.Instance;
    }
    public void SelectStandardTurret()
    {
        Debug.Log("Standard Turret Selected");
        _buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectMissileLauncher()
    {
        Debug.Log("Missile Launcher Selected");
        _buildManager.SelectTurretToBuild(missileLauncher);
    }
}
