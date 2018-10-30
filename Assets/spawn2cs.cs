using UnityEngine;
using System.Collections;

public class spawn2cs : MonoBehaviour {


	public Transform  node1;
	public GameObject  minionPrefab;
	public bool  spawn;
	public bool  did = false;
	public int  sec;
	public string time;
	public GameObject  gm;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		sec= gm.GetComponent<gametime>().intsec;
		time= gm.GetComponent<gametime>().time;
		if (time=="0:45") {
			if (!did) {
				spawnMinion ();
				did = true;
			}
		}
	}


	public void spawnMinion() {
		var i = 0;
		do {
			StartCoroutine("countdown");
			i++;
			Instantiate (minionPrefab, node1.position, Quaternion.identity);
		} while(i < 7);

		StartCoroutine ("countdown2");
		did=false;
	}


	public IEnumerator countdown () {
		yield return new WaitForSeconds(1.5f);
	}

	public IEnumerator countdown2 () {
		yield return new WaitForSeconds(30);
	}

}
