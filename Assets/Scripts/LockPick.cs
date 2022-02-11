using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockPick : MonoBehaviour
{
  public GameObject door;
  public GameObject parentReferant;

  //public Transform pickPosition;


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
    eulerAngle = transform.eulerAngles.x;
    if(door.GetComponent<Animator>().GetBool("tryingToUnlock") && Input.GetKeyDown("a")) unlock();

  }


  void unlock(){
    Debug.Log("in unlock");

    Debug.Log("eulerAngle:"+eulerAngle);
    if(unlockRange[0]<eulerAngle && eulerAngle<unlockRange[1]){
      Debug.Log("Now Unlocked");
      door.GetComponent<Animator>().SetBool("isLocked",false);
    }
  }

  void newLock(){
    unlockAngle = 0;//Random.Range(-maxAngle + lockRange, maxAngle - lockRange);
    unlockRange = new Vector2(unlockAngle - lockRange, unlockAngle + lockRange);

    Debug.Log("unlockRange:"+unlockRange);
    Debug.Log("unlockAngle:"+unlockAngle);
  }

/*
  public Camera cam;
  public Transform serrure;

  public float maxAngle = 90;
  private float unlockAngle;

  [Range(1,25)]
  public float lockRange = 10;
  private Vector2 unlockRange;

  private float eulerAngle;
  public float lockSpeed = 10;




  private float keyPressTime = 0;

  private bool movePick = true;

  // Start is called before the first frame update
  void Start()
  {
    newLock();
  }

  // Update is called once per frame
  void Update()
  {
    transform.localPosition = pickPosition.position;

    if(movePick)
    {
      Vector3 dir = Input.mousePosition - cam.WorldToScreenPoint(transform.position);

      eulerAngle = Vector3.Angle(dir, Vector3.up);

      Vector3 cross = Vector3.Cross(Vector3.up, dir);
      if (cross.z < 0) { eulerAngle = -eulerAngle; }

      eulerAngle = Mathf.Clamp(eulerAngle, -maxAngle, maxAngle);

      Quaternion rotateTo = Quaternion.AngleAxis(eulerAngle, Vector3.forward);
      transform.rotation = rotateTo;
    }

    if(Input.GetKeyDown(KeyCode.D))
    {
      movePick = false;
      keyPressTime = 1;
    }
    if(Input.GetKeyUp(KeyCode.D))
    {
      movePick = true;
      keyPressTime = 0;
    }

    float percentage = Mathf.Round(100 - Mathf.Abs(((eulerAngle - unlockAngle) / 100) * 100));
    float lockRotation = ((percentage / 100) * maxAngle) * keyPressTime;
    float maxRotation = (percentage / 100) * maxAngle;

    float lockLerp = Mathf.Lerp(innerLock.eulerAngles.z, lockRotation, Time.deltaTime * lockSpeed);
    innerLock.eulerAngles = new Vector3(0, 0, lockLerp);

    if(lockLerp >= maxRotation -1)
    {
      if (eulerAngle < unlockRange.y && eulerAngle > unlockRange.x)
      {
        Debug.Log("Unlocked");
        newLock();

        movePick = true;
        keyPressTime = 0;
      }
      else
      {
        float randomRotation = Random.insideUnitCircle.x;
        transform.eulerAngles += new Vector3(0, 0, Random.Range(-randomRotation, randomRotation));
      }
    }
  }

  void newLock()
  {
    unlockAngle = maxAngle;
    unlockRange = new Vector2(unlockAngle - lockRange, unlockAngle + lockRange);
*/
    /*
    unlockAngle = Random.Range(-maxAngle + lockRange, maxAngle - lockRange);
    unlockRange = new Vector2(unlockAngle - lockRange, unlockAngle + lockRange);
    */
  //}
}
