using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{

    public GameObject topLid;
    public GameObject bottomLid;

    void DestroyGameObject()
    {
        Destroy(gameObject);
    }

    void DestroyScriptInstance()
    {
        // Removes this script instance from the game object
        Destroy(this);
    }

    void DestroyComponent()
    {
        // Removes the rigidbody from the game object
        Destroy(GetComponent<Rigidbody>());
    }
}
