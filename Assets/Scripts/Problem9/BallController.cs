using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    public Camera mainCamera;

    [Header("Ball Movement")]
    public Vector2 ballAngle = new Vector2(0, -1);
    public float ballSpeed = 100f;
    public float gravitationalForce = 500f;

    [SerializeField] [Range(100, 255)] private float redColor = 255;
    [SerializeField] [Range(100, 255)] private float greenColor = 100;
    [SerializeField] [Range(100, 255)] private float blueColor = 100;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();

        AddInitialForce();
    }

    private void Update()
    {
        sprite.color = ColorTransition();
        rb.velocity = rb.velocity.normalized * ballSpeed;
    }

    void MoveBallByMouse()
    {
        Vector3 target = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
        Vector3 moveAngle = target - transform.position;

        if (Vector3.Distance(target, transform.position) > 0.5)
            transform.Translate(moveAngle.normalized * ballSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Walls")
            if (FindObjectOfType<AudioManager>() != null) 
                AudioManager.Instance.Play("Impact");
    }

    Color ColorTransition()
    {
        if (redColor > 100 && blueColor == 100) 
        {
            redColor--;
            greenColor++;
        }
        
        if (greenColor > 100 && redColor == 100)
        {
            greenColor--;
            blueColor++;
        }
        
        if (blueColor > 100 && greenColor == 100)
        {
            redColor++;
            blueColor--;
        }

        return new Color(redColor / 255f, greenColor / 255f, blueColor / 255f);
    }

    void AddInitialForce()
    {
        rb.AddForce(ballAngle.normalized * ballSpeed);
    }

    public void GravityPull()
    {
        Vector2 stickPosition = FindObjectOfType<PlayerController>().gameObject.transform.position;
        rb.velocity = (stickPosition - (Vector2)transform.position).normalized;
    }
}
