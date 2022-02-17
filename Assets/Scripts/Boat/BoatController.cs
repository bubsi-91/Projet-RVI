using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation.Examples;
using System;

public class BoatController : MonoBehaviour
{
    public float currentSpeed = 0.0f;
    public PathFollower pathFollower;
    public float slowdownSpeed = 0.03f;
    public float maxSpeed = 1.5f;

    Vector3 PrevPos;
    Vector3 NewPos;
    Vector3 ObjVelocity;
    public Transform forwardTransform;

    // Start is called before the first frame update
    void Start()
    {
        PrevPos = transform.position;
        NewPos = transform.position;
    }


    void FixedUpdate()
    {
        NewPos = transform.position;  // each frame track the new position
        ObjVelocity = (NewPos - PrevPos) / Time.fixedDeltaTime;  // velocity = dist/time
        PrevPos = NewPos;  // update position for next frame calculation
        //slowdown
        if (Math.Abs(currentSpeed) > 0.005)
        {
            float delta = currentSpeed < 0 ? slowdownSpeed : -slowdownSpeed;
            delta *= Time.deltaTime;
            currentSpeed += delta;
        }
        else
        {
            currentSpeed = 0;
        }
        pathFollower.speed = currentSpeed;
        Debug.Log("SPEED: " + pathFollower.speed);
    }
    public void AddForwardForce(float forwardVelocity)
    {
        Debug.Log("In addforwardforce: " + forwardVelocity);
        if (Math.Abs(currentSpeed) < maxSpeed)
        {
            currentSpeed += forwardVelocity;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("WaterMovement"))
        {
            AddForwardForce(Vector3.Dot(ObjVelocity, forwardTransform.position.normalized) / -100);
        }
    }
}
