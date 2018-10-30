using UnityEngine;
using System.Collections;

public class gamemgr : MonoBehaviour {

	public GameObject[] blueSpawns;
	public GameObject[] redSpawns;
	public GameObject lobbycam;
	public GameObject standbyCamera;
	int state = 0;
	public int team;
	public GameObject spawnpos;

	void Start () {

	}

	void OnGUI () {

		switch (state) {
		case 0:

			if (GUI.Button(new Rect(40, 40, 200, 20), "PQ Chan")){
				team = Random.Range (1, 3);
				SpawnPlayer("PQchan1",team);
				state = 1;
			}

			if (GUI.Button(new Rect(40, 70, 200, 20), "Bloodseeker")){
				/*team = Random.Range (1, 2);
				SpawnPlayer("PQchan1",team);
				state = 1;*/
			}


			break;
		case 1:
			//ingame
			break;
		}

	}





	public void SpawnPlayer(string character, int team){

		if (team == 1) {
			spawnpos = blueSpawns [Random.Range (0, blueSpawns.Length)];
		} else {
			spawnpos = redSpawns [Random.Range (0, blueSpawns.Length)];
		}

		GameObject myplayer = PhotonNetwork.Instantiate (character, spawnpos.transform.position, spawnpos.transform.rotation, 0);

		myplayer.GetComponent<RecievedMovementGalilei> ().spawn = spawnpos;

		if (team == 1) {
			myplayer.tag= "BlueTeamTriggerTag";
		} else {
			myplayer.tag= "RedTeamTriggerTag";
		}


		lobbycam.SetActive (false);
		standbyCamera.SetActive (true);
		standbyCamera.GetComponent<rtsCamerac> ().target = GameObject.Find (character+"(Clone)");
		GetComponent<gametime> ().enabled = true;

		myplayer.GetComponent<Animation> ().enabled = true;
		myplayer.GetComponent<NavMeshAgent> ().enabled = true;
		myplayer.GetComponent<AudioSource> ().enabled = true;
		myplayer.GetComponent<playerbasic1> ().enabled = true;
		myplayer.GetComponent<playerStats> ().enabled = true;
		myplayer.GetComponent<minionStats> ().enabled = true;


		if(character == "PQchan1") {
			myplayer.GetComponent<RecievedMovementGalilei> ().enabled = true;
			myplayer.GetComponent<q> ().enabled = true;
			myplayer.GetComponent<w> ().enabled = true;
			myplayer.GetComponent<e> ().enabled = true;
			myplayer.GetComponent<r> ().enabled = true;
			myplayer.GetComponent<reactions> ().enabled = true;
			myplayer.GetComponent<timers> ().enabled = true;
			myplayer.GetComponent<playerStats> ().damage = 20f;
			if (team == 1) {
				myplayer.GetComponent<playerbasic1> ().enemytag = "RedTeamTriggerTag";
				myplayer.GetComponent<q> ().enemytag = "RedTeamTriggerTag";
			} else {
				myplayer.GetComponent<playerbasic1> ().enemytag = "BlueTeamTriggerTag";
				myplayer.GetComponent<q> ().enemytag = "BlueTeamTriggerTag";
			}
		}
			




	}


}