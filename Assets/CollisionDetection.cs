using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionDetection : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Detected collision");

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
