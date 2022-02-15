using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogRotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log($"x:{transform.localRotation.x},y:{transform.localRotation.y},z:{transform.localRotation.z}");
    }
}
