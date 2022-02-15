using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockPick : MonoBehaviour
{
  public GameObject door;
  public GameObject pick;
  private float thisRotInitX;


  public float maxAngle = 90;

  //[Range(1,25)]
  public float lockRange = 10;

  private float eulerAngle;
  private float unlockAngle;
  private Vector2 unlockRange;

  void Start(){
    Debug.Log("start lockpick");

    newLock();
  }

  // Update is called once per frame
  void Update(){
    updatePosPick();
    if(door.GetComponent<Animator>().GetBool("tryingToUnlock"))
      unlock();


  }


  void unlock(){
    //Debug.Log("in unlock");

    Debug.Log("eulerAngle:"+eulerAngle);
    if(unlockRange[0]<eulerAngle && eulerAngle<unlockRange[1]){
      Debug.Log("Now Unlocked");
      door.GetComponent<Animator>().SetBool("isLocked",false);
    }
  }

  void updatePosPick(){
    Debug.Log("upPos");

    Debug.Log("Parent"+transform.localEulerAngles+transform.eulerAngles);
    Debug.Log("Pick"+pick.transform.localEulerAngles+pick.transform.eulerAngles);

    thisRotInitX = transform.localEulerAngles.x;
    eulerAngle = pick.transform.localEulerAngles.y;

/*
    bool tmp = true;
    if(tmp) {
      eulerAngle= 20;
      tmp= false;
    }
*/

    float mod= (-eulerAngle-thisRotInitX);
    transform.Rotate(mod, 0f, 0f);//eulerAngles.x = eulerAngle;

  }

  void newLock(){
    unlockAngle = 0;//Random.Range(-maxAngle + lockRange, maxAngle - lockRange);
    unlockRange = new Vector2(unlockAngle - lockRange, unlockAngle + lockRange);

    Debug.Log("unlockRange:"+unlockRange);
    Debug.Log("unlockAngle:"+unlockAngle);
  }

}
