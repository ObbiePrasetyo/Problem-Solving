using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManualOveride : MonoBehaviour
{
    [Header("Ball Movement")]
    public float ballSpeed = 2f;

    // Update is called once per frame
    void Update()
    {
        float yInput = Input.GetAxisRaw("Vertical");
        float xInput = Input.GetAxisRaw("Horizontal");

        transform.Translate(new Vector3(xInput, yInput, 0)*ballSpeed * Time.deltaTime);
    }
}
