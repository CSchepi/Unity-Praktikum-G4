using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using TMPro;

public class NetworkManager : MonoBehaviourPunCallbacks
{

    public Transform MainMenue;
    public Transform RoomMenue;

    public Button Create;
    public Button Join;

  
    public TextMeshProUGUI nicknameInpitField;
    public TextMeshProUGUI RoomIDInputField;
    public TextMeshProUGUI RoomIDDisplay;
    public TextMeshProUGUI P1Name;
    public TextMeshProUGUI P2Name;

    public readonly string Game_Version = "0.1ALPHA";


    private bool create = false;
    // Start is called before the first frame update
    void Start()
    {

        MainMenue.gameObject.SetActive(false);
        RoomMenue.gameObject.SetActive(false);
        PhotonNetwork.GameVersion = Game_Version;
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("Verbinde zum Maser");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Verbunden zum Maser");
        MainMenue.gameObject.SetActive(true);
        RoomMenue.gameObject.SetActive(false);
    }

    public void CreateRoom()
    {
        create = true;
        PhotonNetwork.NickName = (nicknameInpitField.text);
        PhotonNetwork.JoinLobby(TypedLobby.Default);
    }

    public void JoinExistingRoom()
    {
        if(nicknameInpitField.text == "") { nicknameInpitField.text = "Anonym"; }
        PhotonNetwork.NickName = (nicknameInpitField.text);
        PhotonNetwork.JoinLobby(TypedLobby.Default);
    }

    public override void OnJoinedLobby()
    {
        if (create)
        {
            RoomOptions roomops = new RoomOptions();
            roomops.MaxPlayers = 2;
            PhotonNetwork.CreateRoom(("#"+Random.RandomRange(1000, 9999)));
        }
        else
        {
            PhotonNetwork.JoinRoom(RoomIDInputField.text);
        }
    }

    public override void OnJoinedRoom()
    {
        RoomIDDisplay.text = PhotonNetwork.CurrentRoom.Name;
        MainMenue.gameObject.SetActive(false);
        RoomMenue.gameObject.SetActive(true);
        Debug.Log("Room beigetreten!");
        create = false;
        updatePlayers();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        updatePlayers();
    }

    private void updatePlayers()
    {
        int numP = PhotonNetwork.CurrentRoom.PlayerCount;
        for(int i = 1; i<= numP; i++)
        {
            Player player = PhotonNetwork.CurrentRoom.Players[i];
            string pname = player.NickName;
            if (player.IsLocal)
            {
                pname += " [you]";
            }
            Debug.Log(pname);
            if (i == 1)
            {
                P1Name.text = pname;
            }
            if (i == 2)
            {

                P2Name.text = pname;
            }
            else
            {
                Debug.Log("Zu viele Spieler");
            }
        }
    }

}
