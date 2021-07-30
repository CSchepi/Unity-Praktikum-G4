using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Voice.Unity;
using Photon.Voice.PUN;
using Photon.Realtime;
using Photon.Pun;

public class InitPlayers : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        RPC_CreatePlayer();
    }

    // Update is called once per frame

    void Update()
    {}


    [PunRPC]
    private void RPC_CreatePlayer()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            Vector3 SpawnVR = new Vector3(-29f,16.6f,-19f);
            Quaternion SpawnVRRot = Quaternion.Euler(0,180,0);
            PhotonNetwork.Instantiate("VR_Player", SpawnVR , SpawnVRRot, 0);
            GameObject wrongCam = GameObject.Find("VRCAM");
            wrongCam.SetActive(true);
        }
        else
        {
            PhotonNetwork.Instantiate("nonVR_Player", transform.position, Quaternion.identity, 0);
            GameObject wrongCam = GameObject.Find("nonVRCAM");
            wrongCam.SetActive(true);
        }
    }
}
