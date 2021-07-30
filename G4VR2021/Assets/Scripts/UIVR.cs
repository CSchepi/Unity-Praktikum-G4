using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class UIVR : MonoBehaviour
{
    public GameObject WinCube;
    public GameObject WinScreen;
    public GameObject PauseScreen;
    void Start()
    {
        Debug.Log("Erkannt");
        WinCube = GameObject.FindGameObjectWithTag("EscapeCube");
        WinScreen.gameObject.SetActive(false);
        PauseScreen.gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseScreen.gameObject.SetActive(true);
        }

        if (!WinCube.active && !WinScreen.gameObject.active)
        {
            WinScreen.gameObject.SetActive(true);
        }
    }

    public void leave()
    {
        PhotonNetwork.LoadLevel("MainMenue");
        PhotonNetwork.LeaveRoom();
    }

    public void continueGame()
    {
        PauseScreen.gameObject.SetActive(false);
    }
}
