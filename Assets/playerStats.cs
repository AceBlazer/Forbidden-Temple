using UnityEngine;
using System.Collections;

public class playerStats : MonoBehaviour {

	public int gold;
	public GameObject gm;
	int interval = 1; 
	float nextTime = 0;
	string time;
	public float currHealth;
	public float maxHealth;
	public float damage;

	// Use this for initialization
	void Start () {
		gold = 0;
		currHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		gm = GameObject.FindGameObjectWithTag ("gamemgr");
		time= gm.GetComponent<gametime> ().time;

		if (Time.time >= nextTime) {

			if (string.Equals (time, "0:05")) {
				gold = gold + 2;
			}

			if (string.Equals (time, "0:15")) {
				gold = gold + 2;
			}

			if (string.Equals (time, "0:25")) {
				gold = gold + 2;
			}

			if (string.Equals (time, "0:35")) {
				gold = gold + 2;
			}

			if (string.Equals (time, "0:45")) {
				gold = gold + 2;
			}

			if (string.Equals (time, "0:55")) {
				gold = gold + 2;
			}


			nextTime += interval; 
		}


	}

	void OnGUI() {
		GUI.Label (new Rect (210,(Screen.height-30), 100, 20), gold.ToString());
	}
}
