using UnityEngine;



public class CameraController : MonoBehaviour {
    public float panSpeed = 30f;
    public float scrollSpeed = 150f;
    public float vPanBorderThickness = Screen.height/ 5f;
    public float hPanBorderThickness = Screen.width/ 5f;
    public float zoomInLimit = 10f;
    public float zoomOutLimit = 80f;
    public float xRotationLowerLimit = 10f;
    public float xRotationUpperLimit = 90f;
    
    private bool _doMovement = true;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            _doMovement = !_doMovement;
        if (!_doMovement)
            return;
        
        if (Input.GetAxis("Vertical") > 0 || Input.mousePosition.y >= Screen.height - vPanBorderThickness)
        {
            transform.Translate(Vector3.forward * (panSpeed * Time.deltaTime), Space.World);
        }

        if (Input.GetAxis("Vertical") < 0 || Input.mousePosition.y <= vPanBorderThickness)
        {
            transform.Translate(Vector3.back * (panSpeed * Time.deltaTime), Space.World);
        }

        if (Input.GetAxis("Horizontal") < 0 || Input.mousePosition.x <= hPanBorderThickness)
        {
            transform.Translate(Vector3.left * (panSpeed * Time.deltaTime), Space.World);
        }

        if (Input.GetAxis("Horizontal") > 0 || Input.mousePosition.x >= Screen.width - hPanBorderThickness)
        {
            transform.Translate(Vector3.right * (panSpeed * Time.deltaTime), Space.World);
        }

        // Camera zoom
        if ((Input.GetAxis("Mouse ScrollWheel") > 0f) && transform.position.y > zoomInLimit)
        {
            transform.Translate(Vector3.down * (scrollSpeed * Time.deltaTime), Space.World);
            if (transform.position.y > xRotationLowerLimit && transform.position.y < xRotationUpperLimit)
                transform.rotation = Quaternion.Euler(transform.position.y, 0f, 0f);
        }
        
        if ((Input.GetAxis("Mouse ScrollWheel") < 0f) && transform.position.y < zoomOutLimit)
        {
            transform.Translate(Vector3.up * (scrollSpeed * Time.deltaTime), Space.World);
            if (transform.position.y > xRotationLowerLimit && transform.position.y < xRotationUpperLimit)
                transform.rotation = Quaternion.Euler(transform.position.y, 0f, 0f);
        }
    }
}