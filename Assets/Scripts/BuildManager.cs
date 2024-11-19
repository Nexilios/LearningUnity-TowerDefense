using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    public GameObject buildEffect;
    public NodeUI nodeUI;
    
    private TurretBlueprint _turretToBuild;
    private Node _selectedNode;
    
    public bool CanBuildTurret => _turretToBuild != null;
    public bool HasMoney => PlayerStats.Money >= _turretToBuild.cost;

    void Awake()
    {
        if (!instance)
            instance = this;
    }
    
    public void DeselectNode()
    {
        _selectedNode = null;
        nodeUI.Hide();
    }
    
    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        _turretToBuild = turret;
        DeselectNode();
    }

    public void SelectNode(Node node)
    {
        if (_selectedNode == node)
        {
            DeselectNode();
            return;
        }
        
        _selectedNode = node;
        _turretToBuild = null;
        
        nodeUI.SetTarget(node);
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
        
        GameObject effect = Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
        
        Debug.Log("Turret Built! Money left: " + PlayerStats.Money);
    }
}
