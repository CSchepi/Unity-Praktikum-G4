using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyLock : MonoBehaviour
{
    public GameObject OutsideDoorRight;
    public GameObject OutsideDoorLeft;

    void Start()
    {
        OutsideDoorRight.GetComponent<UnityEngine.XR.Interaction.Toolkit.XRGrabInteractable>().enabled = false;
        OutsideDoorLeft.GetComponent<UnityEngine.XR.Interaction.Toolkit.XRGrabInteractable>().enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Key")
        {
            OutsideDoorRight.GetComponent<UnityEngine.XR.Interaction.Toolkit.XRGrabInteractable>().enabled = true;
            OutsideDoorLeft.GetComponent<UnityEngine.XR.Interaction.Toolkit.XRGrabInteractable>().enabled = true;
        }
    }
}
