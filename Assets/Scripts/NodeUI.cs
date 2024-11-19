using UnityEngine;

public class NodeUI : MonoBehaviour
{
    public GameObject canvasUI;
    
    private Node _target;

    public void SetTarget(Node target)
    {
        _target = target;

        transform.position = _target.GetBuildPosition();
        
        canvasUI.SetActive(true);
    }

    public void Hide()
    {
        canvasUI.SetActive(false);
    }
}
