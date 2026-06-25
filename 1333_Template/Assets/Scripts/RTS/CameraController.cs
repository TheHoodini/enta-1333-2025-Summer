using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 20f;
    public float edgeMoveSpeed = 20f;

    [Header("Zoom")]
    public float zoomSpeed = 200f;
    public float minZoom = 10f;
    public float maxZoom = 100f;

    [Header("Edge Scrolling")]
    public float edgeOffset = 15f;

    private void Update()
    {
        HandleKeyboardMovement();
        HandleEdgeScrolling();
        HandleZoom();
    }

    void HandleKeyboardMovement()
    {
        Vector3 movement = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
            movement += Vector3.forward;

        if (Input.GetKey(KeyCode.S))
            movement += Vector3.back;

        if (Input.GetKey(KeyCode.A))
            movement += Vector3.left;

        if (Input.GetKey(KeyCode.D))
            movement += Vector3.right;

        transform.position += movement.normalized * moveSpeed * Time.deltaTime;
    }

    void HandleEdgeScrolling()
    {
        Vector3 movement = Vector3.zero;

        Vector3 mousePos = Input.mousePosition;

        // left
        if (mousePos.x <= edgeOffset)
            movement += Vector3.left;
        // rigth
        if (mousePos.x >= Screen.width - edgeOffset)
            movement += Vector3.right;
        // bottom
        if (mousePos.y <= edgeOffset)
            movement += Vector3.back;
        // top
        if (mousePos.y >= Screen.height - edgeOffset)
            movement += Vector3.forward;

        transform.position += movement.normalized * edgeMoveSpeed * Time.deltaTime;
    }

    void HandleZoom()
    {
        float scroll = Input.mouseScrollDelta.y;

        if (scroll != 0)
        {
            float yDelta = -scroll * zoomSpeed * Time.deltaTime;
            float newY = transform.position.y + yDelta;

            if (newY < minZoom || newY > maxZoom)
                return;

            Vector3 newPosition = transform.position;

            newPosition.z += scroll * zoomSpeed * Time.deltaTime;
            newPosition.y = newY;

            transform.position = newPosition;
        }
    }
}