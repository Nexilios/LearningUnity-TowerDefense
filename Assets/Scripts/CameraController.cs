using UnityEngine;

public class CameraController : MonoBehaviour {
    public float panSpeed = 30f;
    public float scrollSpeed = 150f;
    public float vPanBorderThickness = Screen.height/ 25f;
    public float hPanBorderThickness = Screen.width/ 25f;
    public float zoomInLimit = 10f;
    public float zoomOutLimit = 80f;
    public float xRotationLowerLimit = 10f;
    public float xRotationUpperLimit = 90f;
    
    public bool mousePanning;
    
    void Update()
    {
        if (GameManager.GameIsOver)
        {
            enabled = false;
            return;
        };
        
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
        if (moveForward)
            transform.Translate(Vector3.forward * (panSpeed * Time.deltaTime), Space.World);
        if (moveBackward)
            transform.Translate(Vector3.back * (panSpeed * Time.deltaTime), Space.World);
        if (moveLeft)
            transform.Translate(Vector3.left * (panSpeed * Time.deltaTime), Space.World);
        if (moveRight)
            transform.Translate(Vector3.right * (panSpeed * Time.deltaTime), Space.World);

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