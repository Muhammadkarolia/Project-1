using UnityEngine;

public class CameraDrag : MonoBehaviour
{
    public float dragSpeed = 0.1f;
    private Vector3 lastMousePosition;

    private void Update()
    {
        if (Input.GetMouseButtonDown(2)) // Middle mouse button
        {
            lastMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(2))
        {
            Vector3 delta = Input.mousePosition - lastMousePosition;
            Vector3 move = new Vector3(-delta.x * dragSpeed, 0, -delta.y * dragSpeed);
            transform.Translate(move, Space.World);
            lastMousePosition = Input.mousePosition;
        }
    }
}
