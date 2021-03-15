using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Controllable controller;
    public Animator playerAnimation;

    public float maxSpeed = 10; //m/s
    public float acceleration = 5; //m/s^2
    public float deceleration = 20;

    private Camera cam;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        float curSpeed = Vector3.Magnitude(new Vector3(rb.velocity.x, 0, rb.velocity.z));
        playerAnimation.SetFloat("speed", curSpeed);
        float facing = Camera.main.transform.eulerAngles.y;
        Vector3 myTurnedInputs = Quaternion.Euler(0, facing, 0) * new Vector3(controller.Joystick1().x, 0, controller.Joystick1().y);

        if (curSpeed < maxSpeed)
        {
            Vector3 movment = (new Vector3(myTurnedInputs.x * acceleration * Time.deltaTime, 0, myTurnedInputs.z * acceleration * Time.deltaTime));
            Vector3 xzVector = rb.velocity;
            xzVector.y = 0;
            rb.velocity = rb.velocity + movment + ((myTurnedInputs - xzVector.normalized) * (deceleration * Time.deltaTime));
            
        }
        //rb.AddForce(new Vector3(controller.Joystick1().x * acceleration * Time.deltaTime, 0, controller.Joystick1().y * acceleration * Time.deltaTime));

        transform.LookAt( transform.position + myTurnedInputs);
    }
}
