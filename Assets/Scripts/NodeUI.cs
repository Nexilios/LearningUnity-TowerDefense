using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NodeUI : MonoBehaviour
{
    public GameObject canvasUI;

    public Button upgradeButton;
    public TextMeshProUGUI upgradeCost;
    public Button sellButton;
    public TextMeshProUGUI sellAmount;
    
    private Node _target;

    public void SetTarget(Node target)
    {
        _target = target;

        transform.position = _target.GetBuildPosition();

        if (!_target.isUpgraded)
        {
            upgradeCost.text = "$" + target.turretBlueprint.upgradeCost;
            upgradeButton.interactable = true;    
        }
        else
        {
            upgradeCost.text = "DONE";
            upgradeButton.interactable = false;
        }

        sellAmount.text = "$" + target.turretBlueprint.GetSellAmount();
        
        canvasUI.SetActive(true);
    }

    public void Hide()
    {
        canvasUI.SetActive(false);
    }

    public void Upgrade()
    {
        _target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }

    public void Sell()
    {
        _target.SellTurret();
        BuildManager.instance.DeselectNode();
    }
}
