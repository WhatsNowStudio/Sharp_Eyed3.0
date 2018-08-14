// Run in split-screen mode
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.XR;

public class SwitchingtoVRmodeatruntime : MonoBehaviour
{
   /* void Start()
    {
        StartCoroutine(LoadDevice("cardboard"));
    }*/

    IEnumerator LoadDevice(string newDevice)
    {
        if (String.Compare(XRSettings.loadedDeviceName, newDevice, true) != 0)
        {
            XRSettings.LoadDeviceByName(newDevice);
            yield return null;
            XRSettings.enabled = true;
        }
    }
}