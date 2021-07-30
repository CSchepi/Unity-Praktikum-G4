using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IDCardScanner : MonoBehaviour
{
    public GameObject image;

    enum LidState
    {
        Closed,
        Opening,
        Closing,
        Open
    }

    LidState chestState = LidState.Closed;

    public Transform hinge;

    public float openSpeed = 1f;

    public float startAngle = 0f;
    public float endAngle = -90f;


    public void OpenChest()
    {
        if (chestState == LidState.Closed)
            StartCoroutine(ToggleChest(startAngle, endAngle, LidState.Opening, LidState.Open));
    }

    public void CloseChest()
    {
        if (chestState == LidState.Closed)
            StartCoroutine(ToggleChest(endAngle, startAngle, LidState.Opening, LidState.Open));
    }

    IEnumerator ToggleChest(float angleStart, float angleEnd, LidState initial, LidState complete)
    {
        chestState = initial;

        float time = 0f;
        GetComponent<AudioSource>().Play();

        while (time <= 1f)
        {
            // Calculate currrent angle
            float angle = Mathf.Lerp(angleStart, angleEnd, time);

            //Get a copy of current Euler angles
            Vector3 euler = hinge.eulerAngles;

            // Set current angle
            euler.y = angle;

            // Reapply Euler angles to transform
            hinge.eulerAngles = euler;

            // Increment time
            time = time + Time.deltaTime / openSpeed;


            yield return null;

        }

        chestState = complete;
    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(ColorCoroutine());
        //Check to see if the tag on the collider is equal to Enemy
        if (other.tag == "IDCard")
        {
            image.GetComponent<Image>().color = Color.green;
            Debug.Log("Card scanner touched.");
            OpenChest();
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
