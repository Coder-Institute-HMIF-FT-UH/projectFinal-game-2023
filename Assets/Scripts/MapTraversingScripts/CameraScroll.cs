using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScroll : MonoBehaviour
{
    public float scrollSpeed = 5f;
    public float minPositionX = 0f;
    public float maxPositionX = 10f;

    private Vector3 touchStartPos;

    private void OnDisable()
    {
        PlayerPrefs.SetFloat("CameraPositionX", transform.position.x);
        PlayerPrefs.Save();
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("CameraPositionX"))
        {
            float savedPositionX = PlayerPrefs.GetFloat("CameraPositionX");
            Vector3 savedPosition = transform.position;
            savedPosition.x = savedPositionX;

            // Ensure the loaded position is within your defined boundaries
            savedPosition.x = Mathf.Clamp(savedPosition.x, minPositionX, maxPositionX);

            transform.position = savedPosition;
        }
    }

    private void Update()
    {
        // Detect a touch or mouse button press
        if (Input.GetMouseButtonDown(0))
        {
            touchStartPos = Input.mousePosition;
        }

        // Detect if touch or mouse button is held down
        if (Input.GetMouseButton(0))
        {
            Vector3 touchEndPos = Input.mousePosition;
            Vector3 touchDelta = touchEndPos - touchStartPos;

            Vector3 moveDirection = new Vector3(-touchDelta.x, 0, 0);
            Vector3 newPosition = transform.position + moveDirection * scrollSpeed * Time.deltaTime;

            // Check if the new position exceeds the defined boundaries and limit it manually
            if (newPosition.x < minPositionX)
                newPosition.x = minPositionX;
            else if (newPosition.x > maxPositionX)
                newPosition.x = maxPositionX;

            // Update the camera's position
            transform.position = newPosition;

            touchStartPos = touchEndPos;
        }
    }
}


