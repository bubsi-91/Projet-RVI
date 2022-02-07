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

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("WaterMovement"))
        {
            Debug.Log("Detected trigger enter for paddle!");
            BoatController.AddForce(-_rigidbody.velocity, PaddleOrientation);
        }
    }
}
