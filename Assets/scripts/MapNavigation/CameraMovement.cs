using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    public float dragSpeed = 2.0f;
    public Vector2 minPosition;
    public Vector2 maxPosition;

    private Vector2 dragOrigin;
    private bool isDragging = false;

    void Update()
    {
        if (Touchscreen.current != null && Touchscreen.current.primaryTouch != null)
        {

            if (Touchscreen.current.primaryTouch.press.isPressed)
            {
                if (!isDragging)
                {
                    dragOrigin = Touchscreen.current.primaryTouch.position.ReadValue();
                    isDragging = true;
                }
                else
                {
                    Vector2 currentTouchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
                    Vector2 dragDelta = currentTouchPosition - dragOrigin;

                    Vector3 move = new Vector3(dragDelta.x * dragSpeed, dragDelta.y * dragSpeed, 0);

                    // Batasi pergerakan kamera sesuai dengan batas min dan max
                    Vector3 newPosition = transform.position + move;
                    newPosition.x = Mathf.Clamp(newPosition.x, minPosition.x, maxPosition.x);
                    newPosition.y = Mathf.Clamp(newPosition.y, minPosition.y, maxPosition.y);

                    transform.position = newPosition;

                    dragOrigin = currentTouchPosition;
                }
            }
            else
            {
                isDragging = false;
            }
        }
    }
}
