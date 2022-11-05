using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandControl : MonoBehaviour
{
    private InputDevice handControllerDevice;
    public InputDeviceCharacteristics characteristics;
    public List<GameObject> handModelPrefabsList;
    private GameObject myHand;
    private Animator handAnim = null;

    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
       // InputDevices.GetDevices(devices);
        // InputDeviceCharacteristics rCntrCharacteristics = InputDeviceCharacteristics.Right;
        InputDevices.GetDevicesWithCharacteristics(characteristics, devices);
        /*   foreach (var dev in devices)
           {
               Debug.Log(dev.name + dev.characteristics);
           }
        */
        if (devices.Count > 0)
            handControllerDevice = devices[0];

        if (handModelPrefabsList.Count > 0)
        {
            myHand = Instantiate(handModelPrefabsList[0], transform);
            handAnim = myHand.GetComponent<Animator>();
        }
    }

    void Update()
    {
        if (handControllerDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerVal))
        {
            handAnim.SetFloat("Trigger", triggerVal);
        }
        else
        {
            handAnim.SetFloat("Trigger", 0);
        }

        if (handControllerDevice.TryGetFeatureValue(CommonUsages.grip, out float gripVal))
        {
            handAnim.SetFloat("Grip", gripVal);
        }
        else
        {
            handAnim.SetFloat("Grip", 0);
        }

    }
}
