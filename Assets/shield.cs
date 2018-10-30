using UnityEngine;
using System.Collections;

public class shield : MonoBehaviour {

	GameObject target;
	public float time;
	public bool b=false;
	// Use this for initialization
	void Start () {
		//target = GetComponent<e> ().player;
	}

	// Update is called once per frame
	void Update () {
		target = GameObject.FindGameObjectWithTag ("player1");
		this.transform.position = target.transform.position;

		StartCoroutine ("cooldown");
		if (b) {
			Destroy (gameObject);
		}
	

	}

	IEnumerator cooldown() {

		yield return new WaitForSeconds (time);
		b=true;
	}
}
