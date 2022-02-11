using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class serrure : MonoBehaviour
{


    public GameObject door;
    //public GameObject item;

    private Animator doorAnimator;

/*
    private Renderer rend;
    public Color color_over = Color.red;
    public Color initColor;
    public Color color_angle = Color.blue;
*/
    private bool tryingToUnlock;

    private bool isOpen;
    private bool isLocked;


    // Start is called before the first frame update
    void Start()
    {
      Debug.Log("start serrure");

      doorAnimator = door.GetComponent<Animator>();
      tryingToUnlock = doorAnimator.GetBool("tryingToUnlock");



/*
      rend = GetComponent<Renderer>();
      initColor = rend.material.color;
*/
    }

    // Update is called once per frame
    void Update()
    {

      if(Input.GetKeyDown("b")) {

        if(tryingToUnlock){ camMoveAway(); }
        else { camMoveCloser(); }
        tryingToUnlock = !tryingToUnlock;
        doorAnimator.SetBool("tryingToUnlock", tryingToUnlock);

        Debug.Log("tryingToUnlock="+tryingToUnlock);
      }
    }


    void OnMouseDown() {
      Debug.Log("OnMouseDown");

      open();
    }

    void open(){
      Debug.Log("open");
      isOpen   = doorAnimator.GetBool("isOpen");
      isLocked = doorAnimator.GetBool("isLocked");

      Debug.Log("isLocked");
      if(!isLocked){
        if(!isOpen) { doorAnimator.Play("doorOpen"); }
        else { doorAnimator.Play("doorClose");}

        isOpen = !isOpen;
        doorAnimator.SetBool("isOpen", isOpen);

        Debug.Log("a:"+(isOpen));
        Debug.Log("b:"+doorAnimator.GetBool("isOpen"));
      }
    }

    void camMoveAway(){
      Debug.Log("camMoveAway");
    }
    void camMoveCloser(){
      Debug.Log("camMoveCloser");
    }


/*
    void OnMouseExit() {
        rend.material.color = initColor;
    }
    void OnMouseOver() {
        rend.material.color = color_over;
    }
*/
}
