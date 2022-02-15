using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//using UnityEngine.XR.Interaction.Toolkit;

public class serrure : MonoBehaviour//XRBaseInteractable
{

    public GameObject door;
    public GameObject perso;
    //public GameObject self;
    public Vector3 posPersoInit;
    public Vector3 rotPersoInit;

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
    public void Start()
    {
      Debug.Log("start serrure");

      doorAnimator = door.GetComponent<Animator>();
      tryingToUnlock = doorAnimator.GetBool("tryingToUnlock");

      posPersoInit= perso.transform.position;
      rotPersoInit= perso.transform.localEulerAngles;


/*
      rend = GetComponent<Renderer>();
      initColor = rend.material.color;
*/
    }

    // Update is called once per frame
    void Update()
    {



      if(Input.GetKeyDown("b")) { TryingToUnlock(); }
    }


    void OnMouseDown() { open(); }

    public void open(){
      Debug.Log("open");
      isOpen   = doorAnimator.GetBool("isOpen");
      isLocked = doorAnimator.GetBool("isLocked");

      //Debug.Log("isLocked");
      if(!isLocked){
        if(!isOpen) { doorAnimator.Play("doorOpen"); }
        else { doorAnimator.Play("doorClose");}

        isOpen = !isOpen;
        doorAnimator.SetBool("isOpen", isOpen);

        if(tryingToUnlock){ camMoveAway(); }

        Debug.Log("a:"+(isOpen));
        Debug.Log("b:"+doorAnimator.GetBool("isOpen"));
      } else { TryingToUnlock(); }
    }

    void TryingToUnlock(){
      if(tryingToUnlock){ camMoveAway(); }
      else { camMoveCloser(); }
      tryingToUnlock = !tryingToUnlock;
      doorAnimator.SetBool("tryingToUnlock", tryingToUnlock);

      Debug.Log("tryingToUnlock="+tryingToUnlock);
     }

    void camMoveAway(){
      //Debug.Log("camMoveAway");
      perso.transform.position = posPersoInit;
      perso.transform.localEulerAngles = rotPersoInit;
    }
    void camMoveCloser(){
      //Debug.Log("camMoveCloser");
      perso.transform.position = transform.position + new Vector3(-0.7f, -2.0f, 0.0f);
      perso.transform.localEulerAngles = new Vector3(0f, 90f, 0f);
    }


/*
    void OnHoverEnter(){
      //base.OnEnable();
      rend.material.color = color_over;
    }

    void OnHoverExit(){
      //base.OnDisable();
      rend.material.color = initColor;
    }
*/

/*
    void OnSelectEnter() {
      rend.material.color = Color.red;
      tryingToUnlock= true;
    }
*/
/*
    void OnMouseExit() {
        rend.material.color = initColor;
    }
    void OnMouseOver() {
        rend.material.color = color_over;
    }
*/
}
