using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float sensitivity = 2f;

    private float rotationX = 0f;  // Kameran�n dikey d�n��� i�in de�i�ken

    void Update()
    {
        MouseLook();
    }

    private void MouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        // Yatay hareket (karakterin d�nmesi)
        transform.Rotate(Vector3.up * mouseX);

        // Dikey hareket (kameran�n yukar� ve a�a��ya d�nmesi)
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);
        Camera.main.transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
    }
}
