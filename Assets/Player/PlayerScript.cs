using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.Windows;

public class PlayerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Rigidbody rb;

    [SerializeField]
    public float Speed;

    public InputActionReference move;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    
    }

    void MovePlayer()
    {
        Vector2 moveDirection = move.action.ReadValue<Vector2>();
        Vector3 moveChar = new Vector3(moveDirection.x, 0f, moveDirection.y);
        rb.linearVelocity = moveChar * Speed * Time.fixedDeltaTime;
        //rb.MovePosition (rb.position + new Vector3(moveDirection.x, 0f, moveDirection.y) * Speed * Time.fixedDeltaTime);
    }
}
