using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float rotationAmount;
    public float boostSpeed;

    private bool boosting = false;

    // From StackOverFlow :D
    private float accelerometerUpdateInterval = 1.0f / 60.0f;
    // The greater the value of LowPassKernelWidthInSeconds, the slower the
    // filtered value will converge towards current input sample (and vice versa).
    private float lowPassKernelWidthInSeconds = 1.0f;
    // This next parameter is initialized to 2.0 per Apple's recommendation,
    // or at least according to Brady! ;)
    private float shakeDetectionThreshold = 2.0f;

    private float lowPassFilterFactor;
    private Vector3 lowPassValue;

    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        lowPassFilterFactor = accelerometerUpdateInterval / lowPassKernelWidthInSeconds;
        shakeDetectionThreshold *= shakeDetectionThreshold;
        lowPassValue = Input.acceleration;
    }

    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            Vector3 acceleration = Input.acceleration;
            lowPassValue = Vector3.Lerp(lowPassValue, acceleration, lowPassFilterFactor);
            Vector3 deltaAcceleration = acceleration - lowPassValue;

            if (deltaAcceleration.sqrMagnitude >= shakeDetectionThreshold && boosting == false)
            {
                StartCoroutine(Boost());
            }
        }
    }

    void FixedUpdate()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            float tilt = Input.acceleration.x; 
            rb2d.rotation += rotationAmount * -tilt;
        }
        else 
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

    IEnumerator Boost()
    {
        gameObject.GetComponent<MoveForward>().speed += boostSpeed;
        boosting = true;
        yield return new WaitForSeconds(0.3f);
        gameObject.GetComponent<MoveForward>().speed -= boostSpeed;
        boosting = false;
    }
}
