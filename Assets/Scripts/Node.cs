using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

    [Header("Optional")]
    public GameObject turret;
    
    private Renderer _rend;
    private Color _startColor;

    private BuildManager _buildManager;

    void Start()
    {
        _rend = GetComponent<Renderer>();
        _startColor = _rend.material.color;
        _buildManager = BuildManager.instance;
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
        
        _buildManager.BuildTurret(this);
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }
}
