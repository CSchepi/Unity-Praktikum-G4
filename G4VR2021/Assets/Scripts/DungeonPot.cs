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

    public GameObject SecurityCameras;
    public GameObject VaultLight;

    string input;

    void Start()
    {
        potionWasGuessed = false;
        
        if (VaultLight == null)  VaultLight = GameObject.FindWithTag("VaultLight");
        if (SecurityCameras == null) SecurityCameras = GameObject.FindWithTag("SecurityCameras");
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
                //set Vault lighting
                VaultLight.SetActive(true);
                SecurityCameras.SetActive(false);
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

