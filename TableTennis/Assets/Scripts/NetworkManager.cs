using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;

public class NetworkManager : MonoBehaviourPunCallbacks, IOnEventCallback
{
    // Start is called before the first frame update
    void Start()
    {
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

    public void OnJoinButtonClicked()
    {
        PhotonNetwork.JoinRandomOrCreateRoom(roomOptions: roomOptions);
    }
    public void OnEvent(EventData photonEvent)
    {


    }

    #region PhotonCallBacks
    private void OnConnectedToServer()
    {
        Debug.Log(" connected to server");
    }
    #endregion
}
