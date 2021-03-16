using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float rotationAmount;

    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.rotation += rotationAmount;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.rotation -= rotationAmount;
        }
    }
}
