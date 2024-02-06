using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 PlayerMovementInput;
    private Vector2 PlayerMouseInput;

    [SerializeField] private float Speed = 5f;
    [SerializeField] private float MouseSensitivity = 1f;
    [SerializeField] private float JumpForce = 5f;
    [Space]
    [SerializeField] private Transform PlayerCamera;
    [SerializeField] private Rigidbody PlayerRigidbody;
    [SerializeField] private CharacterController PlayerController;


    private void Update()
    {
        PlayerMovementInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        PlayerMouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        MovePlayer();
        // MovePlayerCamera();
    }

    private void MovePlayer()
    {
        Vector3 HorizontalMovement = transform.right * PlayerMovementInput.x;
        Vector3 VerticalMovement = transform.forward * PlayerMovementInput.z;

        Vector3 MovementDirection = (HorizontalMovement + VerticalMovement).normalized;

        PlayerRigidbody.MovePosition(transform.position + MovementDirection * Speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerRigidbody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }
    }

    private void MovePlayerCamera()
    {
        Vector2 MouseInput = PlayerMouseInput * MouseSensitivity * Time.deltaTime;

        transform.Rotate(Vector3.up * MouseInput.x);

        float CameraRotationX = PlayerCamera.rotation.eulerAngles.x - MouseInput.y;

        if (CameraRotationX > 180f)
        {
            CameraRotationX -= 360f;
        }

        CameraRotationX = Mathf.Clamp(CameraRotationX, -90f, 90f);

        PlayerCamera.rotation = Quaternion.Euler(CameraRotationX, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
    }
}
