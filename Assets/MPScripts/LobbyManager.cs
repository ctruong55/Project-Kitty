using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    public TMP_InputField createInput;
    public TMP_Text roomName;
    public GameObject lobby;
    public GameObject room;

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.JoinLobby();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickCreate() {
        if (createInput.text.Length >= 1)
        {
            PhotonNetwork.CreateRoom(createInput.text, new RoomOptions() { MaxPlayers = 3 });
        }
    }

    public override void OnJoinedRoom()
    {
        lobby.SetActive(false);
        room.SetActive(true);
        roomName.text = "Room Name: " + PhotonNetwork.CurrentRoom.Name;
        PhotonNetwork.LoadLevel("Multiplayer");
    }
}
