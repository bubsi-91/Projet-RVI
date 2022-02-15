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

    void FixedUpdate()
    {
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
        Debug.Log(pathFollower.speed);
    }

    public enum PaddleOrientation { Right, Left }

    public void AddForce(float forwardVelocity)
    {
        if(Math.Abs(currentSpeed) < maxSpeed)
        {
            currentSpeed += forwardVelocity;
        }
    }
}
