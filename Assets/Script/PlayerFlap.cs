using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerFlap : MonoBehaviour
{
    public float force = 10.0f;
    public int score = 0;
    private Rigidbody2D _rb;
    
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
        if (Input.GetMouseButtonDown(0))
        {
            ApplyImpulse();
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
        if (other.gameObject.CompareTag("Death"))
        {
            Debug.Log("Game Over");
            
            // Reset scene
            Debug.Log("Scene reloaded");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
