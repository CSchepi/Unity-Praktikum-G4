using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class LeaveRoom : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void tomainloby()
    {
        PhotonNetwork.LoadLevel("MainMenue");
        PhotonNetwork.LeaveRoom();
    }
}
