using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaultUnlockDrill : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Drill")
        {
            var rb = GameObject.Find("vault_door").GetComponent<Rigidbody>();
            rb.isKinematic = false;
        }
    }
}
