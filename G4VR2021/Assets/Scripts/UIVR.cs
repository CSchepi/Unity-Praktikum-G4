using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.InputSystem;

public class UIVR : MonoBehaviour
{
    public GameObject WinCube;
    public GameObject WinScreen;
    public GameObject PauseScreen;
    public GameObject LooseScreen;
    [SerializeField] private InputActionReference menubuttonActionReference;
    void Start()
    {
        Debug.Log("Erkannt");
        WinCube = GameObject.FindGameObjectWithTag("EscapeCube");
        WinScreen.gameObject.SetActive(false);
        PauseScreen.gameObject.SetActive(false);
        LooseScreen.gameObject.SetActive(false);
        StartCoroutine(LooseTimer());
        menubuttonActionReference.action.performed += Menubutton;

    }

    // Update is called once per frame

    private void Menubutton(InputAction.CallbackContext obj)
    {
        PauseScreen.gameObject.SetActive(true);
    }
    void Update()
    {

        if (!WinCube.active && !WinScreen.gameObject.active)
        {
            WinScreen.gameObject.SetActive(true);
        }
    }

    public void leave()
    {
        PhotonNetwork.LoadLevel("mainmenue");
        PhotonNetwork.LeaveRoom();
    }

    public void continueGame()
    {
        PauseScreen.gameObject.SetActive(false);
    }

    IEnumerator LooseTimer()
    {


        yield return new WaitForSeconds(1830);
        LooseScreen.gameObject.SetActive(true);
    }

}
