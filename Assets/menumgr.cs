using UnityEngine;
using System.Collections;

public class menumgr : MonoBehaviour {

	public int state = 0;
	public GUIStyle SubText;
	public GUIStyle Header;

	public string battleForgeLevelName;


	void Start () {

	}

	void OnJoinedLobby(){
		state = 2;
	}

	void OnJoinedLobbyFailed(){
		state = 0;
	}

	void OnPhotonRandomJoinFailed(){
		PhotonNetwork.CreateRoom (null);
	}

	void OnJoinedRoom(){
		state = 4;
	}

	void OnGUI () {

		switch (state) {
		case 0:
			// MENU

			GUI.Label(new Rect(10, 10, 200, 30), "Forbidden Temple", SubText);
			GUI.Label(new Rect(10, 30, 200, 30), "JS Studios 2018 (c)", SubText);
			GUI.Label(new Rect(10, 80, 200, 30), "No Updates Avaiilable.", SubText);
			GUI.Label(new Rect(10, 100, 200, 30), "Server Status: Online.", SubText);

			if (GUI.Button(new Rect((Screen.width / 2) - 25, 70, 100, 30), "Play")){
				state = 1;
				PhotonNetwork.ConnectUsingSettings("1.0");
			}
			break;

		case 1:
			// Connect to Server

			GUI.Label(new Rect((Screen.width / 2) - 50, Screen.height / 2, 100, 40), "Connecting to Server...", SubText);

			break;

		case 2:
			// Pick Game Type

			if (GUI.Button(new Rect((Screen.width / 2) - 100, Screen.height / 2, 200, 30), "5V5 - BattleForge Island")){
				state = 3;
				PhotonNetwork.JoinRandomRoom();
			}

			if (GUI.Button(new Rect((Screen.width / 2) - 100, (Screen.height / 2) - 40, 200, 30), "3V3 - BattleForge Island")){
				state = 3;
				PhotonNetwork.JoinRandomRoom();
			}

			break;
		case 3:
			// Search for 5v5 Game

			GUI.Label(new Rect((Screen.width / 2) - 50, Screen.height / 2, 100, 40), "Searching for Players...", SubText);

			break;
		case 4:
			//Game Found, Waiting for Full Lobby

			if (PhotonNetwork.playerList.Length == 1 & PhotonNetwork.isMasterClient == true){
				this.GetComponent<PhotonView>().RPC ("StartGame", PhotonTargets.All);
			}

			break;
		case 5:
			// In-Game

			break;
		}

	}

	[PunRPC]
	public void StartGame(){
		state = 5;
		Application.LoadLevel(battleForgeLevelName);
	}
}