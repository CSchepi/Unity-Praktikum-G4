using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IDCardScanner : MonoBehaviour
{
    public GameObject image;

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(ColorCoroutine());
        //Check to see if the tag on the collider is equal to Enemy
        if (other.tag == "IDCard")
        {
            image.GetComponent<Image>().color = Color.green;
            Debug.Log("Card scanner touched.");
        } 
        else 
        {
            image.GetComponent<Image>().color = Color.red;
        }
    }

    IEnumerator ColorCoroutine()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(3);
        image.GetComponent<Image>().color = Color.white;

    }
}
