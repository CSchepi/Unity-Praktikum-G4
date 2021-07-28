using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowCode : MonoBehaviour
{
    Text displayInput;

    void Start()
    {
        displayInput = GetComponent<Text>();
    }

    public void _ArrowPress(string arrowKeyCode)
    {
        displayInput.text = arrowKeyCode; 
    }
}
