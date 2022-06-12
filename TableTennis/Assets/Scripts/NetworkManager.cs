using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;

public class NetworkManager : MonoBehaviourPunCallbacks, IOnEventCallback
{
    RoomOptions roomOptions;
    public LoginScript loginScript;
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        LoginScript.instance.LoginClicked += OnJoinButtonClicked;
        roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;
        roomOptions.IsOpen = true;
        if (!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnJoinButtonClicked(string PlayerName)
    {
        PhotonNetwork.NickName = PlayerName;
        PhotonNetwork.JoinRandomOrCreateRoom(roomOptions: roomOptions);
    }
    public void OnEvent(EventData photonEvent)
    {


    }

    #region PhotonCallBacks
    private void OnConnectedToServer()
    {
      
    }

    public override void OnJoinedRoom()
    {
        Debug.Log( PhotonNetwork.LocalPlayer.NickName+   "  has  joined the room");
    }

        #endregion
    }
