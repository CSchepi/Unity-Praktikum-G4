using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ManagerChechInput : MonoBehaviour
{
    Text displayInput;
    public Text txt;
    public int pin = 195836;
    public string input;
    private bool pinWasGuessed;

    public AudioSource audio;

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
        audio.Play();

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
        if (input.Length < 6)
        {
            return;
        }

        else if (input.Length == 6)
        {
            //check if pin is correct

            int enteredPin = Int32.Parse(input);
            Debug.Log(enteredPin);
            if (enteredPin == pin)
            {
                Debug.Log("Entered if");
                txt.GetComponent<Text>().text = "Pin is correct!";
                pinWasGuessed = true;

                OpenChest();
                return;
            }
            else
            {
                Debug.Log("Entered if");

                txt.GetComponent<Text>().text = "Pin is incorrect! Try again...";
                input = "";
                displayInput.text = input;
            }
        }
    }
}
