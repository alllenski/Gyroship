using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsPlayer : MonoBehaviour
{
    
    public float rotationSpeed;

    private Transform target;
    private Vector2 direction;

    void Start()
    {
        target = GameObject.Find("Player Ship").transform;
    }

    void FixedUpdate()
    {
        direction = target.position - transform.position;

        transform.up = Vector2.Lerp((Vector2)transform.up, direction, Time.deltaTime * rotationSpeed);
    }
}
