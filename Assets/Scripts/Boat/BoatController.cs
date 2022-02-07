using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public Transform LeftPaddlePosition;
    public Transform RightPaddlePosition;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public enum PaddleOrientation { Right, Left }

    public void AddForce(Vector3 force, PaddleOrientation paddleOrientation)
    {
        if (paddleOrientation == PaddleOrientation.Right)
        {
            _rigidbody.AddForceAtPosition(force, RightPaddlePosition.position, ForceMode.Force);
        }
        else
        {
            _rigidbody.AddForceAtPosition(force, LeftPaddlePosition.position, ForceMode.Force);
        }
    }
}
