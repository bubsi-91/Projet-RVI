using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public BoatController BoatController;
    public BoatController.PaddleOrientation PaddleOrientation;
    public Transform forwardTransform;

    Vector3 PrevPos;
    Vector3 NewPos;
    Vector3 ObjVelocity;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        PrevPos = transform.position;
        NewPos = transform.position;
    }

    void FixedUpdate()
    {
        //TODO: Copy rotation from controller
        NewPos = transform.position;  // each frame track the new position
        ObjVelocity = (NewPos - PrevPos) / Time.fixedDeltaTime;  // velocity = dist/time
        PrevPos = NewPos;  // update position for next frame calculation
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("WaterMovement"))
        {
            //Debug.Log("Detected trigger enter for paddle! " + ObjVelocity.z);
            BoatController.AddForce(Vector3.Dot(ObjVelocity, forwardTransform.position.normalized) / -100);
        }
    }
}
