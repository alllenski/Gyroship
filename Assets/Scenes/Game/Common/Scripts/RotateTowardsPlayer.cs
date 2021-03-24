using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsPlayer : MonoBehaviour
{
    
    public float RotationSpeed;

    private Transform Target;
    private Vector2 Direction;

    void Start()
    {
        Target = GameObject.Find("Player Ship").transform;
    }

    void FixedUpdate()
    {
        Direction = Target.position - transform.position;

        transform.up = Vector2.Lerp((Vector2)transform.up, Direction, Time.deltaTime * RotationSpeed);
    }
}
