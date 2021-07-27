using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CheckInput : MonoBehaviour
{
    Text displayInput;
    public Text txt;
    public int pin = 1234;
    public string input;

    // Start is called before the first frame update
    void Start()
    {
        displayInput = GetComponent<Text>();
    }

    public void _addNumber(string num)
    {
        input = input + num; 
        displayInput.text = input; 
        checkIfInputLenghtIs4();
    }

    private void checkIfInputLenghtIs4()
    {
        if(input.Length<4)
        {
            return;
        } 

        else if(input.Length==4) 
        {
            //check if pin is correct
            int enteredPin = Int32.Parse(input);
            if (enteredPin == pin)
            {
                txt.GetComponent<Text>().text = "Pin is correct!";
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
