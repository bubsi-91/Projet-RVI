using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public BoatController BoatController;
    public BoatController.PaddleOrientation PaddleOrientation;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("WaterMovement"))
        {
            Debug.Log("Detected trigger enter for paddle! " + _rigidbody.velocity.z);
            BoatController.AddForce(-_rigidbody.velocity, PaddleOrientation);
        }
    }
}