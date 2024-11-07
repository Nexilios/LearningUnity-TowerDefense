using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset;

    private GameObject _turret;
    
    private Renderer _rend;
    private Color _startColor;

    void Start()
    {
        _rend = GetComponent<Renderer>();
        _startColor = _rend.material.color;
    }
    
    void OnMouseEnter()
    {
        _rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        _rend.material.color = _startColor;
    }

    void OnMouseDown()
    {
        if (_turret)
        {
            Debug.Log("Can't build here! - TODO: Display on screen.");
            return;
        }
        
        GameObject turretToBuild = BuildManager.Instance.GetTurretToBuild();
        _turret = Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
    }
}
