using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset;

    private GameObject _turret;
    
    private Renderer _rend;
    private Color _startColor;
    
    BuildManager _buildManager;

    void Start()
    {
        _rend = GetComponent<Renderer>();
        _startColor = _rend.material.color;
        _buildManager = BuildManager.Instance;
    }
    
    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        
        if (_buildManager.GetTurretToBuild() == null)
            return;
        
        
        _rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        _rend.material.color = _startColor;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        
        if (_buildManager.GetTurretToBuild() == null)
            return;
        
        if (_turret)
        {
            Debug.Log("Can't build here! - TODO: Display on screen.");
            return;
        }
        
        GameObject turretToBuild = BuildManager.Instance.GetTurretToBuild();
        _turret = Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
    }
}
