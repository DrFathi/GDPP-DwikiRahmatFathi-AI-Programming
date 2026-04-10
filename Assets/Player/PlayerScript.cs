using System;
using System.Collections;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;

public class PlayerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Rigidbody rb;

    private Coroutine _powerUpCoroutine;

    [SerializeField]
    private float _powerUpDuration;

    public Action OnPowerUpStart;
    public Action OnPowerUpStop;

    [SerializeField]
    public float speed;

    [SerializeField]
    public Transform _camera;
    [SerializeField]
    public Transform _respawnPoint;
    [SerializeField]
    private int _health;

    public InputActionReference move;
    public bool _isPowerUpActive;

    [SerializeField]
    private TMP_Text _healthText;

    void Start()
    {
        UpdateUI();
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

    public void PickPowerUp()
    {
        if (_powerUpCoroutine != null)
        {
            StopCoroutine(_powerUpCoroutine);
        }

        //Debug.Log("Power up picked up");
        _powerUpCoroutine = StartCoroutine(StartPowerUp());

        
    }

    private IEnumerator StartPowerUp()
    {
        _isPowerUpActive = true;

        if (OnPowerUpStart != null)
        {
            speed += 50;
            OnPowerUpStart();
            Debug.Log("Power up started");
        }

        yield return new WaitForSeconds(_powerUpDuration);
        _isPowerUpActive = false;

        if (OnPowerUpStop != null)
        {
            speed -= 50;
            OnPowerUpStop();
            Debug.Log("Power up ended");
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_isPowerUpActive)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                collision.gameObject.GetComponent<EnemyScript>().Dead();
            }
        }
    }

    private void UpdateUI()
    {
        _healthText.text = "Hp  :" + _health;
    }

    public void Dead()
    {
        _health -= 1;

        if(_health > 0)
        {
            Debug.Log("Killed by an Enemy");
            transform.position = _respawnPoint.position;
        }
        else
        {
            _health = 0;
            SceneManager.LoadScene("GameOverScreen");
        }
        UpdateUI();
    }
}
