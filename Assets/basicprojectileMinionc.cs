using UnityEngine;
using System.Collections;

public class basicprojectileMinionc : MonoBehaviour {



	public Transform target;
	public int speed = 2;
	 GameObject player;
	public GameObject impact;

	void Start () {
		

	}
	
	void Update () {
		//player = GameObject.FindGameObjectWithTag ("player1");
		//target = player.GetComponent<playerbasic1> ().enemy ;
		//transform.LookAt (target);
		transform.Translate (Vector3.forward * 10 * Time.deltaTime);
		if (target) {
			if (Vector3.Distance (this.transform.position, target.transform.position) < 0.5f) {
				
				Destroy (gameObject);
			}
			if (Vector3.Distance (this.transform.position, target.transform.position) < 1.1f) {
				inst ();
			}
		}
	}

	public void inst () {
		Instantiate (impact, target.transform.position, target.transform.rotation);
	}
}



