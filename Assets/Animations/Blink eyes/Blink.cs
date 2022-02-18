using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{

    public GameObject topLid;
    public GameObject bottomLid;
    public Animator anim;

    void Start(){
        anim = GetComponent<Animator>();
    }

    void Update() {
        if(Input.GetKeyDown("a") || Input.GetKeyDown("a")) {
            Invoke("blinkEyes", 2);
            anim.Play("BlinkBottom");
            anim.Play("Blink Top");
        }
    }

    public void blinkEyes(){
        Instantiate(topLid, new Vector3(0.166299999f,0.5546f,0.515999973f), Quaternion.identity);
        Instantiate(bottomLid, new Vector3(0.166299999f,-0.707799971f,0.515999973f), Quaternion.identity);
    }


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
