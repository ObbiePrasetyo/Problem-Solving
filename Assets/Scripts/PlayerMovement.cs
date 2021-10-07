using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;

    private Rigidbody2D p_rigidbody;
    // Start is called before the first frame update
    
    private void Awake()
    {
        p_rigidbody = GetComponent<Rigidbody2D>();
    }
    
    void Start()
    {
        p_rigidbody.AddForce(new Vector2(1,1) * moveSpeed);
    }
}
