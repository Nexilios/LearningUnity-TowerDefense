using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager _buildManager;
    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;
    public TurretBlueprint laserBeamer;

    void Start()
    {
        _buildManager = BuildManager.instance;
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

    public void SelectLaserBeamer()
    {
        Debug.Log("Laser Beamer Selected");
        _buildManager.SelectTurretToBuild(laserBeamer);
    }
}
