using UnityEngine;
using System.Collections;

public class gobacktosrc : MonoBehaviour {

	public GameObject target;
	public float time;
	public bool b=false;
	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag ("player1");

	}

	// Update is called once per frame
	void Update () {

		StartCoroutine ("cooldown");
		if (b) {
			transform.LookAt (target.transform);
			transform.Translate (Vector3.forward * 13 * Time.deltaTime);
			if (target) {
				if (Vector3.Distance (this.transform.position, target.transform.position) < 0.1f) {
					//Instantiate (impact, target.transform.position, target.transform.rotation);
					Destroy (gameObject);
				}
			}
		}

	}

	IEnumerator cooldown() {

		yield return new WaitForSeconds (time);
		b=true;
	}

	
}
