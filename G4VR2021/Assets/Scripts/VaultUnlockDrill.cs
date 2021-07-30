using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaultUnlockDrill : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.name == "Drill")
        {
            Debug.Log(other.gameObject.name);
            var rb = GameObject.Find("vault_door").GetComponent<Rigidbody>();
            rb.isKinematic = false;
        }
    }
}
