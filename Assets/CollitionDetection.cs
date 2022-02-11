using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollitionDetection : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {

        Debug.Log("Collision Detected");

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
