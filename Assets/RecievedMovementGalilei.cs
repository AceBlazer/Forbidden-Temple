using UnityEngine;
using System.Collections;

public class RecievedMovementGalilei : MonoBehaviour {


	public Vector3 newposition;
	public float speed;
	public float walkRange;
	public NavMeshAgent nav;
	public GameObject graphics;
	public GameObject sample;
	public bool canmove=true;
	public GameObject recallpart;
	public GameObject spawn;
	//public GameObject gm;

	void Start () {
		nav = GetComponent<NavMeshAgent>();
		newposition = this.transform.position;
		//spawn = gm.GetComponent<gamemgr> ().spawnpos; 
	}


	void Update () {

		bool RMB = Input.GetMouseButtonDown(1);

		if (RMB)
		{

			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast (ray, out hit) && hit.transform.tag == "ground") {
				RecievedMove (hit.point);
			}


		}

		//&& newposition != null

		if (nav.destination != newposition) {
			
			nav.destination = newposition;
			GetComponent<Animation> ().CrossFade ("004_Run");
				

		} 

		if (Vector3.Distance (nav.destination, transform.position) <= 0.5f) {
			GetComponent<Animation> ().CrossFade ("001_Stand");
		} else {
			
				transform.LookAt (newposition);
				GetComponent<Animation> ().CrossFade ("004_Run");
			
		}


		if (Input.GetKeyDown ("s")) {
			nav.Stop();
			newposition = this.transform.position;
			GetComponent<Animation> ().CrossFade ("001_Stand");
		}

		if (Input.GetKeyDown ("b")) {
			nav.Stop();
			newposition = this.transform.position;
			GetComponent<Animation> ().Stop ();
			GetComponent<Animation> ().CrossFade ("001_Stand");	
			Instantiate (recallpart, this.transform.position, Quaternion.Euler(new Vector3(-90,0,0)));
			StartCoroutine ("recallcountdown");


		}
	

	}


	public void RecievedMove(Vector3 movePos){
		if (canmove == true ) {
			nav.Resume ();
			newposition = movePos;
			Instantiate (sample, newposition, Quaternion.identity);

		}
	}

	IEnumerator recallcountdown() {
		yield return new WaitForSeconds (5);

		this.transform.position = spawn.transform.position;
		nav.Stop();
		newposition = this.transform.position;
		GetComponent<Animation> ().CrossFade ("001_Stand");
	
	}


}
