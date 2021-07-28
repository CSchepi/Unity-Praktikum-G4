using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonPot : MonoBehaviour
{
    public string PotPin;
    private bool potionIsGuessed;

    string input;

    void Start()
    {
        potionIsGuessed = false;
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Potion")
        {
            input = input + col.GetComponent<Potion>().potionColorCode;
            Debug.Log("Input = "+ input);
            Destroy(col.gameObject);
            checkCode();
        }
    }

    private void checkCode()
    {
        if(input.Length>=4)
        {
            if(input.Equals(PotPin))
            {
                potionIsGuessed = true;
                Debug.Log("Potion order is correct");
                return;
            }
            else 
            {
                //toDo reinstantiate Potions;
                input = "";
                Debug.Log("Potion order is incorrect");
                return;
            }  
        }
    }
}
