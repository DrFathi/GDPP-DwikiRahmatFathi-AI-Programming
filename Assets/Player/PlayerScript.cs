using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.Windows;

public class PlayerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Rigidbody rb;

    [SerializeField]
    public float speed;

    [SerializeField]
    public Transform _camera;

    public InputActionReference move;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    
    }

    void MovePlayer()
    {
        Vector2 moveDirection = move.action.ReadValue<Vector2>();

        Vector3 horizontalDirection = moveDirection.x * _camera.right;
        Vector3 verticallDirection = moveDirection.y * _camera.forward;

        verticallDirection.y = 0;
        horizontalDirection.y = 0;

        Vector3 moveChar = horizontalDirection + verticallDirection;

        rb.linearVelocity = moveChar * speed * Time.fixedDeltaTime;
        //rb.MovePosition (rb.position + new Vector3(moveDirection.x, 0f, moveDirection.y) * Speed * Time.fixedDeltaTime);
    }
}
