using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
using UnityEngine.SceneManagement;

public class NetworkManager : MonoBehaviourPunCallbacks, IOnEventCallback
{

    public static NetworkManager instance;
    RoomOptions roomOptions;
    public LoginScript loginScript;
    public int NextSceneNumber;
    private const byte LoadLevel = 1,SendPos = 2;
    // Start is called before the first frame update

    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
    }
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

    public bool isMaster()
    {
        return (PhotonNetwork.IsMasterClient);
    }
    public void OnJoinButtonClicked(string PlayerName)
    {
        PhotonNetwork.NickName = PlayerName;
        PhotonNetwork.JoinRandomOrCreateRoom(roomOptions: roomOptions);
    }

    #region OnEvent IoneventInterface
    public void OnEvent(EventData photonEvent)
    {
        byte eventCode = photonEvent.Code;
        if (eventCode == LoadLevel)
        {
            object[] data = (object[])photonEvent.CustomData;
            SceneManager.LoadSceneAsync((int)data[0]);
        }
        else if(eventCode == SendPos)
        {
            object[] data = (object[])photonEvent.CustomData;
            GameManager.instance.ReceivedBatPos((Vector3)data[0]);
        }

    }
    #endregion

    #region PhotonCallBacks
    private void OnConnectedToServer()
    {
      
    }

    public override void OnJoinedRoom()
    {
       
        if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
        {
            Debug.Log(PhotonNetwork.LocalPlayer.NickName + "  has  joined the room");
        }
        else if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
            Debug.Log(PhotonNetwork.LocalPlayer.NickName + "  has  joined the room");
            SceneManager.LoadScene(NextSceneNumber);
            SendLevelNo(NextSceneNumber);
        }
    }

    public void SendLevelNo(int LevelNo)
    {
        object[] data = new object[] { LevelNo };
        RaiseEventOptions raiseEventOptions;
        if (PhotonNetwork.IsMasterClient)
        {
            raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.Others };
        }
        else
        {
            raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.MasterClient };
        }
        PhotonNetwork.RaiseEvent(LoadLevel, data, raiseEventOptions, SendOptions.SendReliable);
    }
    public void SendBatPos(Vector3 Pos)
    {
        object[] data = new object[] { Pos};
        RaiseEventOptions raiseEventOptions;
        if (PhotonNetwork.IsMasterClient)
        {
            raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.Others };
        }
        else
        {
            raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.MasterClient };
        }
        PhotonNetwork.RaiseEvent(SendPos, data, raiseEventOptions, SendOptions.SendReliable);
    }

    #endregion


}
