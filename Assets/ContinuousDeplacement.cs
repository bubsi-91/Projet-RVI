using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class ContinuousDeplacement : MonoBehaviour
{
    public float speed = 1.0f;
    public XRNode inputSource;


    private float TriggerValue;
    private XRRig rig;
    private CharacterController character;

    void Start()
    {
        character = GetComponent<CharacterController>();
        rig = GetComponent<XRRig>();
    }

    // Update is called once per frame
    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        //device.TryGetFeatureValue(CommonUsages.Trigger, out TriggerValue);
        
    }

    private void fixedUpdate() {

        Quaternion headYaw = Quaternion.Euler(0, rig.cameraGameObject.transform.eulerAngles.y, 0);
        Vector3 direction = headYaw * new Vector3(0, 0, 1);

        if (TriggerValue > 0.1)
            character.Move(direction * Time.fixedDeltaTime * speed);
    }
}
