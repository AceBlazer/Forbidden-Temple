using UnityEngine;
using System.Collections;

public class gamemanager1 : Photon.MonoBehaviour {
	public GameObject[] blueSpawns;
	public GameObject[] redSpawns;
	public GameObject cam; // to locate it in base


	void Start () {
		spawn (0, "PQchan1");
	}
	

	void Update () {

	}



	void spawn(int team, string character) {
		cam.SetActive(true);

		GameObject myspawn = blueSpawns [Random.Range (0, blueSpawns.Length)];
		GameObject myplayer = PhotonNetwork.Instantiate (character,myspawn.transform.position,myspawn.transform.rotation, 0);

		myplayer.GetComponent<Animation> ().enabled = true;
		myplayer.GetComponent<NavMeshAgent> ().enabled = true;
		myplayer.GetComponent<AudioSource> ().enabled = true;
		myplayer.GetComponent<RecievedMovementGalilei> ().enabled = true;
		myplayer.GetComponent<q> ().enabled = true;
		myplayer.GetComponent<w> ().enabled = true;
		myplayer.GetComponent<e> ().enabled = true;
		myplayer.GetComponent<r> ().enabled = true;
		myplayer.GetComponent<reactions> ().enabled = true;
		myplayer.GetComponent<timers> ().enabled = true;
		myplayer.GetComponent<playerStats> ().enabled = true;
		myplayer.GetComponent<playerbasic1> ().enabled = true;

		if (character == "PQchan1") {
			cam.GetComponent<rtsCamerac> ().target = GameObject.Find ("PQchan1(Clone)");
		}
	}
}
