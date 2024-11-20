using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector] 
    public bool isUpgraded;
    
    private Renderer _rend;
    private Color _startColor;

    private BuildManager _buildManager;

    void Start()
    {
        _rend = GetComponent<Renderer>();
        _startColor = _rend.material.color;
        _buildManager = BuildManager.instance;
    }

    public void UpgradeTurret()
    {
        if (PlayerStats.Money < turretBlueprint.upgradeCost)
        {
            Debug.Log("Not enough money to upgrade this turret");
            return;
        }
        
        PlayerStats.Money -= turretBlueprint.upgradeCost;
        
        // Destroy old turret
        Destroy(turret);
        
        // Replacing the old turret
        turret = Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        isUpgraded = true;
        
        GameObject effect = Instantiate(_buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
    }
    
    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        
        if (!_buildManager.CanBuildTurret)
            return;
        
        _rend.material.color = _buildManager.HasMoney ? hoverColor : notEnoughMoneyColor;
    }

    void OnMouseExit()
    {
        _rend.material.color = _startColor;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        
        if (turret)
        {
            _buildManager.SelectNode(this);
            return;
        }
        
        if (!_buildManager.CanBuildTurret)
            return;
        
        BuildTurret(_buildManager.GetTurretToBuild());
    }

    void BuildTurret(TurretBlueprint blueprint)
    {
        if (PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("Not enough money to build turret");
            return;
        }
        
        PlayerStats.Money -= blueprint.cost;
        turret = Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        
        turretBlueprint = blueprint;
        
        GameObject effect = Instantiate(_buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
    }
    
    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }
}
