using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class FPC_Motion : MonoBehaviour
{

    public InputDeviceCharacteristics leftHandCharacteristics;
    private InputDevice leftControllerDevice;
    public InputDeviceCharacteristics rightHandCharacteristics;
    private InputDevice rightControllerDevice;
    private XRRig myRig;
    private CharacterController FPC;
    private Vector2 leftJoystick;
    private bool primaryBtnVal;

    public static XRController activeHand;
    private InputDevice activeHandCtrl;

    public float speed = 1;
    private float moveY = 0;
    public float jumpSpeed = 6;
    private float gravity = 20f;

    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(leftHandCharacteristics, devices);
        if (devices.Count > 0) leftControllerDevice = devices[0];

        InputDevices.GetDevicesWithCharacteristics(rightHandCharacteristics, devices);
        if (devices.Count > 0) rightControllerDevice = devices[0];

        myRig = GetComponent<XRRig>();

        FPC = GetComponent<CharacterController>();

        activeHand = null;
    }

    void Update()
    {
        leftControllerDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out leftJoystick);  //Test joystick for movement
        rightControllerDevice.TryGetFeatureValue(CommonUsages.primaryButton, out primaryBtnVal);    // Test 'A' button for jump
    }

    private void FixedUpdate()
    {
        if (activeHand)
        {
            activeHandCtrl = InputDevices.GetDeviceAtXRNode(activeHand.controllerNode);
            activeHandCtrl.TryGetFeatureValue(CommonUsages.deviceVelocity, out Vector3 velocity);
            FPC.Move(transform.rotation * -velocity * Time.fixedDeltaTime);
        }
        else
        {
            if (FPC.isGrounded && primaryBtnVal)
                moveY = jumpSpeed;

            if (moveY >= -10)
                moveY -= gravity * Time.fixedDeltaTime;
            else
                moveY = -10;

            Quaternion headRotation = Quaternion.Euler(0, myRig.cameraGameObject.transform.eulerAngles.y, 0);
            Vector3 movementDirection = headRotation * new Vector3(leftJoystick.x, moveY, leftJoystick.y);
            FPC.Move(movementDirection * Time.fixedDeltaTime * speed);
        }
    }
}
