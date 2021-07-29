using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonPot : MonoBehaviour
{
    public string PotPin;
    private bool potionWasGuessed;
    public GameObject potSmoke;
    public GameObject potSmoke_CorrectPin;
    public GameObject prefabBottles;

    string input;

    void Start()
    {
        potionWasGuessed = false;
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
                potionWasGuessed = true;
                Debug.Log("Potion order is correct");
                potSmoke.SetActive(false);
                potSmoke_CorrectPin.SetActive(true);
                return;
            }
            else 
            {
                input = "";
                //Re-instantiate potions once the order is not correct
                Instantiate(prefabBottles, new Vector3(-40.2f, 8.8f, -29.2f), Quaternion.identity);
                
                Debug.Log("Potion order is incorrect");
                return;
            }  
        }
    }
}
