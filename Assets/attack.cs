using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class attack : MonoBehaviour {

	public float maxHp = 200f;
	public float currHp;
	public float damage = 80f;
	Transform enemy;
	GameObject c;
	public GameObject coin;
	bool firing;
	public AudioSource audio;
	public AudioClip tin;
	public GameObject canvas;
	public Image mybar;

	// Use this for initialization
	void Start () {
		enemy = null;
		currHp = maxHp;
	}
	
	// Update is called once per frame
	void Update () {
		

		if (currHp <= 0) {
			audio.PlayOneShot (tin);
			currHp = 1;
			if (!firing) {
				firing = true;
				c=Instantiate (coin, canvas.transform.position, Quaternion.identity) as GameObject;
				StartCoroutine ("countdown");
			}
		}
	

		mybar.fillAmount = (float)(currHp/maxHp) ;
			

	}


	public void attackme (GameObject attacker, float hisdamage) {
		//Debug.Log ("im being attacked");
		if (currHp > 0) {
			currHp -= damage/2;
		} else {
			Debug.Log ("dead");
		}
	}

	IEnumerator countdown() {
		yield return new WaitForSeconds (0.5f);
		firing=false;
		DestroyObject (c);
		DestroyObject (this.gameObject);
	}


}
