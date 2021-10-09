using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsController : MonoBehaviour
{
    private SpriteRenderer sprite;

    private float redColor = 100f;
    private float greenColor = 100f;
    private float blueColor = 255f;


    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        sprite.color = ColorTransition();
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
}
