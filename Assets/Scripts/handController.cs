using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class handController : MonoBehaviour
{
    XRController controller;
    public Hand hand;
    public playerWeapon weapon;
    void Start()
    {
        controller = GetComponent<XRController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.gripButton, out bool gripButtonPressed) && gripButtonPressed)
            hand.SetPeace(0);
        else 
            hand.SetPeace(0.05f);
      
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.triggerButton, out bool triggerButtonPressed) && triggerButtonPressed)
            weapon.setFiregun(true);
        else
            weapon.setFiregun(false);
    }
}
