using UnityEngine;
using System.Collections;

public class playerbasic1 : MonoBehaviour {

	public int range ;
	public GameObject gun;
	public GameObject sample;
	public GameObject bullet;
	public int moveSpeed ;
	public RecievedMovementGalilei rm;
	public CharacterController controller;
	bool firing=false;
	bool canmove=true;
	Vector3 newposition;
	bool instantiated = false;
	GameObject cp;
	public Transform enemy;
	GameObject basic;
	public NavMeshAgent nav;
	public AudioSource audio;
	public AudioClip attacksound;
	public string enemytag;

	int baseAD;
	int baseAP;
	int bonusAD;
	int bonusAP;
	int penetAD;
	int penetAP;
	float damage;


	// Use this for initialization
	void Start () {
		rm = GetComponent<RecievedMovementGalilei> ();
		nav = GetComponent<NavMeshAgent> ();

		baseAD=GetComponent<minionStats>().baseAD;
		baseAP=GetComponent<minionStats>().baseAP;
		bonusAD = 0;
		bonusAP = 0;
		penetAD=GetComponent<minionStats>().penetAD;
		penetAP=GetComponent<minionStats>().penetAP;
		damage = GetComponent<playerStats> ().damage;
	}

	// Update is called once per frame
	void Update () {




		bool RMB = Input.GetMouseButtonDown(1);

		if (RMB) {

			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			if (Physics.Raycast (ray, out hit) && (hit.transform.tag == enemytag)) {

				enemy = hit.transform;

				if(Vector3.Distance (transform.position, enemy.transform.position) <= range){


					GetComponent<RecievedMovementGalilei> ().newposition = this.transform.position;
					transform.LookAt (enemy.transform.position);
					newposition = this.transform.position;
					GetComponent<Animation> ().Stop();
					GetComponent<Animation> ().Play ("005_Jump");
					attack ();


				}



				//RecievedMove (hit.point);

				if (Vector3.Distance (transform.position, enemy.transform.position) <= range) {
					if (!instantiated) {
						instantiated = true;
						cp = Instantiate (sample, enemy.transform.position, enemy.transform.rotation) as GameObject;
					}
					transform.LookAt (enemy.transform);

					attack (); 	
						
				}
				else {
					RecievedMove (hit.point); 

				}
			}
			if (Physics.Raycast (ray, out hit) && hit.transform.tag == "ground" && cp) {
				Destroy (cp);
				//	canmove = false;
				instantiated = false;
			}

		}

		if (enemy&&basic) {
				
			basic.transform.LookAt (enemy.transform.position);
			if (Vector3.Distance (basic.transform.position, enemy.transform.position) < 1f) {
				
				DestroyObject (basic);
				//Debug.Log ("im attacking him");
				enemy.GetComponentInParent<attack> ().attackme (this.gameObject ,damage);
			}
		}

		if (!enemy) {
			DestroyObject (basic);
		}




	}


	public void RecievedMove(Vector3 movePos){
		newposition = movePos;
		if (!instantiated ) {
			instantiated = true;
			cp = Instantiate (sample, enemy.transform.position, enemy.transform.rotation) as GameObject; 

			if (Vector3.Distance (transform.position, enemy.transform.position) <= range) {


				transform.LookAt (enemy.transform);

				attack (); 	
			}
			else {

				transform.LookAt (enemy.transform);
				rm.canmove = true;
				rm.newposition = enemy.transform.position;

			}

		}
	}

	public void attack() {

			if (!firing) {
				firing = true;
				StartCoroutine ("countdown");
				audio.PlayOneShot (attacksound);
				basic = Instantiate (bullet, gun.transform.position, gun.transform.rotation) as GameObject;
				basic.GetComponent<basicprojectileMinionc> ().target = enemy.transform;
		
			}
	}

	IEnumerator countdown() {
		yield return new WaitForSeconds (1);
		firing=false;
	}

}
