using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float rotateSpeed = 500f;
    public GameObject shadow;
    private Rigidbody2D rb;

    public GameObject nonRotatingChild;

    private SpriteRenderer sprite;

    private float redColor = 240f;
    private float greenColor = 100f;
    private bool maxColor;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        sprite.color = ColorTransition();

        float horizontalControl = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.forward, rotateSpeed * Time.deltaTime * horizontalControl);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            BallController[] balls = FindObjectsOfType<BallController>();
            foreach (BallController ball in balls)
            {
                ball.GravityPull();
                shadow.SetActive(true);
            }
        }

        nonRotatingChild.transform.rotation = Quaternion.Euler(0, 0, gameObject.transform.rotation.z * -1.0f);
    }

    Color ColorTransition()
    {
        if (!maxColor)
        {
            greenColor++;
            if (greenColor == 240f)
                maxColor = true;
        }
        else
        {
            greenColor--;
            if (greenColor < 100)
                maxColor = false;
        }

        return new Color(redColor / 255f, greenColor / 255f, 0);
    }
}
