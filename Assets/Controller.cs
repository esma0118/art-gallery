using UnityEngine;

public class FPSController : MonoBehaviour
{
    public float moveSpeed = 4f;         // Hareket hýzý
    public float jumpForce = 1f;         // Zýplama gücü
    public float gravity = -9.81f;      // Yerçekimi
    public float sensitivity = 2f;      // Fare hassasiyeti

    private Camera playerCamera;
    private CharacterController characterController;
    private Vector3 velocity;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerCamera = Camera.main;

        // Fareyi kilitle ve gizle
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        Movement();
        MouseLook();
    }

    private void Movement()
    {
        // Hareket
        float moveDirectionX = Input.GetAxis("Horizontal");
        float moveDirectionZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveDirectionX + transform.forward * moveDirectionZ;

        // Zýplama ve yerçekimi
        if (characterController.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity); // Zýplama gücü
            }
        }
        else
        {
            velocity.y += gravity * Time.deltaTime; // Yerçekimi
        }

        characterController.Move(move * moveSpeed * Time.deltaTime);
        characterController.Move(velocity * Time.deltaTime);
    }

    private void MouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        // Karakterin dönüþ hareketleri
        transform.Rotate(Vector3.up * mouseX);
        float rotationX = playerCamera.transform.localEulerAngles.x - mouseY;
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
    }
}
