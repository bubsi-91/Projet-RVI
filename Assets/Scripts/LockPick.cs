using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockPick : MonoBehaviour
{
  public GameObject door;
  public GameObject pick;
  private float thisRotInitX;

  private Animator doorAnimator;
  private AudioSource audio;

  public float maxAngle = 85;

  //[Range(1,25)]
  public float lockRange = 10;

  private float eulerAngle;
  private float unlockAngle;
  private Vector2 unlockRange;

  void Start(){
    Debug.Log("start lockpick");
    doorAnimator= door.GetComponent<Animator>();
    audio = GetComponent<AudioSource>();

    newLock();
  }

  // Update is called once per frame
  void Update(){
    if(doorAnimator.GetBool("tryingToUnlock")){
      updatePosPick();
      unlock();
    }


  }


  void unlock(){
    //Debug.Log("in unlock");

    Debug.Log("eulerAngle:"+eulerAngle);
    if(unlockRange[0]<eulerAngle && eulerAngle<unlockRange[1]){
      Debug.Log("Now Unlocked");
      doorAnimator.SetBool("isLocked",false);
      if(doorAnimator.GetBool("isLocked")) audio.Play(0);
    }
  }

  void updatePosPick(){
    Debug.Log("upPos");

    Debug.Log("Parent"+transform.localEulerAngles+transform.eulerAngles);
    Debug.Log("Pick"+pick.transform.localEulerAngles+pick.transform.eulerAngles);
    Debug.Log(transform.localEulerAngles.x);

    thisRotInitX = transform.localEulerAngles.x;
    eulerAngle = pick.transform.localEulerAngles.y;

    if(thisRotInitX>180) thisRotInitX= thisRotInitX-360;
    if(eulerAngle>180) eulerAngle= eulerAngle-360;


    Debug.Log("thisRotInitX"+thisRotInitX);
    Debug.Log("eulerAngle"+eulerAngle);



/*
    bool tmp = true;
    if(tmp) {
      eulerAngle= -45;
      tmp= false;
    }
*/

    float mod= (-eulerAngle-thisRotInitX);
    if((eulerAngle>-maxAngle) && (eulerAngle<maxAngle)){
      transform.Rotate(mod, 0f, 0f);//eulerAngles.x = eulerAngle;
    }

  }

  void newLock(){
    unlockAngle = Random.Range(-maxAngle + lockRange, maxAngle - lockRange);
    unlockRange = new Vector2(unlockAngle - lockRange, unlockAngle + lockRange);

    Debug.Log("unlockRange:"+unlockRange);
    Debug.Log("unlockAngle:"+unlockAngle);
  }

}
