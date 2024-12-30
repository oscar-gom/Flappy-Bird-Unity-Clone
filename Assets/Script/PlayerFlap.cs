using UnityEngine;

public class PlayerFlap : MonoBehaviour
{
    public float force = 10.0f;
    private Rigidbody2D _rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ApplyImpulse();
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
