using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager _buildManager;

    void Start()
    {
        _buildManager = BuildManager.Instance;
    }
    public void PurchaseStandardTurret()
    {
        Debug.Log("Standard Turret Selected");
        _buildManager.SetTurretToBuild(_buildManager.standardTurretPrefab);
    }

    public void PurchaseAnotherTurret()
    {
        Debug.Log("Another Turret Selected");
        _buildManager.SetTurretToBuild(_buildManager.anotherTurretPrefab);
    }
}
