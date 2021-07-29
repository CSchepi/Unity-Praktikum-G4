using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DungeonCheckInput : MonoBehaviour
{
    Text displayInput;
    public Text txt;
    public string pin = "YODA";
    public string input;
    private bool pinWasGuessed;
    //public GameObject DoorLeft;
    //public GameObject DoorRight;

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
    //SerializeField startAngle;
    //SerializeField endAngle;

    public float startAngle = 0f;
    public float endAngle = -40f;


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




    // Start is called before the first frame update
    void Start()
    {
        displayInput = GetComponent<Text>();
        pinWasGuessed = false;
    }

    public void _addNumber(string num)
    {
        if (!pinWasGuessed)
        {
            input = input + num;
            displayInput.text = input;
            checkIfInputLenghtIs6();
        }
    }

    private void checkIfInputLenghtIs6()
    {
        if (input.Length < 4)
        {
            return;
        }

        else if (input.Length == 4)
        {
            //check if pin is correct
            //int enteredPin = Int32.Parse(input);
            if (input == pin)
            {
                txt.GetComponent<Text>().text = "Pin is correct!";
                pinWasGuessed = true;
                //DoorLeft.GetComponent<OpenLiftDoor>()._openDoor();
                //DoorRight.GetComponent<OpenLiftDoor>()._openDoor();

                OpenChest();
                return;
            }
            else
            {
                txt.GetComponent<Text>().text = "Pin is incorrect! Try again...";
                input = "";
                displayInput.text = input;
            }
        }
    }
}
