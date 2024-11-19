using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Camera Options")] 
    public bool fancyZoom;
    public bool mousePanning;
    
    [Header("Camera Parameters")]
    public float panSpeed = 30f;
    public float scrollSpeed = 150f;
    public float vPanBorderThickness = Screen.height/ 25f;
    public float hPanBorderThickness = Screen.width/ 25f;
    public float zoomInLimit = 10f;
    public float zoomOutLimit = 80f;
    public float sidePanLimit = 100f;
    public float forwardPanLimit = 100f;
    
    [HideInInspector]
    public float xRotationLowerLimit = 10f;
    [HideInInspector]
    public float xRotationUpperLimit = 90f;
    
    void Update()
    {
        if (GameManager.GameIsOver)
        {
            enabled = false;
            return;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
            mousePanning = !mousePanning;
        
        bool moveForward = false;
        bool moveBackward = false;
        bool moveLeft = false;
        bool moveRight = false;

        // Move camera by mouse
        if (mousePanning)
        {
            if (Input.mousePosition.y >= Screen.height - vPanBorderThickness)
                moveForward = true;
            if (Input.mousePosition.y <= vPanBorderThickness)
                moveBackward = true;
            if (Input.mousePosition.x <= hPanBorderThickness)
                moveLeft = true;
            if (Input.mousePosition.x >= Screen.width - hPanBorderThickness)
                moveRight = true;
        }

        // Move camera by keyboard
        if (Input.GetAxis("Vertical") > 0)
            moveForward = true;
        if (Input.GetAxis("Vertical") < 0)
            moveBackward = true;
        if (Input.GetAxis("Horizontal") < 0)
            moveLeft = true;
        if (Input.GetAxis("Horizontal") > 0)
            moveRight = true;
        
        // Move the camera
        if (moveForward && transform.position.z < forwardPanLimit)
            transform.Translate(Vector3.forward * (panSpeed * Time.deltaTime), Space.World);
        if (moveBackward && transform.position.z > -forwardPanLimit)
            transform.Translate(Vector3.back * (panSpeed * Time.deltaTime), Space.World);
        if (moveLeft && transform.position.x > -sidePanLimit)
            transform.Translate(Vector3.left * (panSpeed * Time.deltaTime), Space.World);
        if (moveRight && transform.position.x < sidePanLimit)
            transform.Translate(Vector3.right * (panSpeed * Time.deltaTime), Space.World);

        if (fancyZoom) 
            FancyZooming();
        else
        {
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            Vector3 pos = transform.position;
            
            pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
            pos.y = Mathf.Clamp(pos.y, zoomInLimit, zoomOutLimit);
            transform.position = pos;
        }
    }

    void FancyZooming()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if ((scroll > 0f) && transform.position.y > zoomInLimit)
        {
            transform.Translate(Vector3.down * (scrollSpeed * Time.deltaTime), Space.World);
            if (transform.position.y > xRotationLowerLimit && transform.position.y < xRotationUpperLimit)
                transform.rotation = Quaternion.Euler(transform.position.y, 0f, 0f);
        }
        
        if ((scroll < 0f) && transform.position.y < zoomOutLimit)
        {
            transform.Translate(Vector3.up * (scrollSpeed * Time.deltaTime), Space.World);
            if (transform.position.y > xRotationLowerLimit && transform.position.y < xRotationUpperLimit)
                transform.rotation = Quaternion.Euler(transform.position.y, 0f, 0f);
        }
    }
}