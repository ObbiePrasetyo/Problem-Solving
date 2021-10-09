using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManualOverride : MonoBehaviour
{
    [Header("Ball Movement")]
    public float ballSpeed = 2f;

    private void Update()
    {
        float yInput = Input.GetAxisRaw("Vertical");
        float xInput = Input.GetAxisRaw("Horizontal");

        transform.Translate(new Vector3(xInput, yInput, 0) * ballSpeed * Time.deltaTime);
    }
}
