using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayerHeight : MonoBehaviour
{
    private GameObject player;

    public void goToOtherFloor(float y_position)
    {
       if(player == null){
           player = GameObject.FindWithTag("Player");
       } 
       
       player.transform.position = new Vector3(player.transform.position.x, y_position, player.transform.position.z);
    }
}
