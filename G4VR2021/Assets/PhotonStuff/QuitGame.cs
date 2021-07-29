using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class QuitGame : MonoBehaviourPunCallbacks
{

    public GameObject SureCard;

    public void QuittheGame()
    {
        Application.Quit();
    }
    public void QuitoLoby()
    {
        SceneManager.UnloadSceneAsync("SampleScene");
        SceneManager.LoadScene("MainMenue");
        PhotonNetwork.LeaveRoom(false);
    }

    public void Ups()
    {
        SureCard.gameObject.SetActive(false);
    }
    public void QuitPressed()
    {

        SureCard.gameObject.SetActive(true);
    }
}
