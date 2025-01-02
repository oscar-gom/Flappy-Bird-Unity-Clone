using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerFlap : MonoBehaviour
{
    public float force = 10.0f;
    public int score;
    private Rigidbody2D _rb;
    public bool dead;
    private bool _godMode;
    public bool started;

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
            Debug.Log("God mode activated");
            _godMode = true;
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