using UnityEngine;
using System.Collections;

public class skillshot : MonoBehaviour {

	public Transform target;

	// Use this for initialization
	void Start () {
		//target = GameObject.FindGameObjectWithTag ("enemy");
	}
	
	// Update is called once per frame
	void Update () {

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
