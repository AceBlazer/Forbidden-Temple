using UnityEngine;
using System.Collections;

public class minionStats : MonoBehaviour {

	public GameObject gm;
	public GameObject lastHitter;
	public GameObject coin;

	string time;
	public int currHealth;
	public int maxHealth;
	public int level;
	public int armor;
	public int magicResist;


	public int baseAD;
	public int baseAP;
	public int penetAD;
	public int penetAP;


	// Use this for initialization
	void Start () {
		currHealth = maxHealth;
		level = 1;

	}
	
	// Update is called once per frame
	void Update () {
		gm = GameObject.FindGameObjectWithTag ("gamemgr");
		time=gm.GetComponent<gametime>().time;

		if (currHealth <= 0) {
			currHealth = 0;
			coin.SetActive (true);
			StartCoroutine ("countdown");
		}



		if (string.Equals (time, "10:00"))
			{
			//base ad ap attspeed ...
				maxHealth = maxHealth + 250;
				armor = armor + 10;
				magicResist = magicResist + 7;
			}
		if (string.Equals (time, "15:00"))
			{
				maxHealth = maxHealth + 300;
				armor = armor + 11;
				magicResist = magicResist + 8;
			}
		if (string.Equals (time, "30:00"))
			{
				maxHealth = maxHealth + 350;
				armor = armor + 12;
				magicResist = magicResist + 9;
			}
		if (string.Equals (time, "45:00"))
			{
				maxHealth = maxHealth + 400;
				armor = armor + 13;
				magicResist = magicResist + 10;
			}
		if (string.Equals (time, "59:59"))
			{
				maxHealth = maxHealth + 500;
				armor = armor + 20;
				magicResist = magicResist + 14;
			}



	}

	public void getHit(int baseAD1, int baseAP1, int bonusAD1, int bonusAP1, int penetAD1, int penetAP1, GameObject hitter) {
		currHealth = currHealth - (((baseAD1+bonusAD1)*penetAD1)/armor)+(((baseAP1+bonusAP1)*penetAP1)/magicResist);

		if (currHealth <= 0) {
			lastHitter = hitter;
			lastHitter.GetComponent<playerStats> ().gold += 18;


		}
	}

	IEnumerator countdown() {
		yield return new WaitForSeconds (2);
		Destroy (gameObject);
	}

	IEnumerator contdowncoin() {
		yield return new WaitForSeconds (1);
		coin.SetActive (false);
	}


		
}
