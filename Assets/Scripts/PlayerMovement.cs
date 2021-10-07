using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;

    private Rigidbody2D p_rigidbody;
    
    private void Awake()
    {
        p_rigidbody = GetComponent<Rigidbody2D>();
    }
    
    private void Start()
    {
        // problem 2solved 
       // p_rigidbody.AddForce(new Vector2(1,1) * moveSpeed);
    }

    private void Update()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxisRaw("Vertical");
        Vector2 direction = new Vector2(xInput, yInput). normalized;

        p_rigidbody.velocity = direction * moveSpeed;
    }
}
