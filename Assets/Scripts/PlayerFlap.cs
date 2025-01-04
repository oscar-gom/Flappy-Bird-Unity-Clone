using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerFlap : MonoBehaviour
{
    public float force = 10.0f;
    public int score;
    public bool dead;
    public bool started;
    private Rigidbody2D _rb;
    private bool _godMode;
    private Quaternion _targetRotation;
    private float _rotationSpeed = 10.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        // Set player initial position
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (!started)
        {
            _rb.simulated = false;
        }

        if (Input.GetMouseButtonDown(0) && !dead)
        {
            _rb.simulated = true;
            ApplyImpulse();
            started = true;
        }

        // God mode
        if (Input.GetKeyDown(KeyCode.G))
        {
            _godMode = !_godMode;
            if (_godMode)
            {
                Debug.Log("God mode activated");
            }
            else
            {
                Debug.Log("God mode deactivated");
            }
        }
        
        // Rotation interpolation
        transform.rotation = Quaternion.Lerp(transform.rotation, _targetRotation, _rotationSpeed * Time.deltaTime);
        
        if (started)
        {
            // Rotate when falling or going up
            if (_rb.linearVelocityY < 0)
            {
                _targetRotation = Quaternion.Euler(0, 0, -25);
            }
            else if (_rb.linearVelocityY > 0)
            {
                _targetRotation = Quaternion.Euler(0, 0, 25);
            }
        }
        else
        {
            _targetRotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ScorePoint"))
        {
            score++;
            Debug.Log("Score: " + score);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Death") && !_godMode)
        {
            Debug.Log("Game Over");
            dead = true;
        }
    }

    void ApplyImpulse()
    {
        float originalGravity = _rb.gravityScale;
        
        _rb.gravityScale = 0;
        _rb.linearVelocity = Vector2.up * force;

        _rb.gravityScale = originalGravity;
    }
}