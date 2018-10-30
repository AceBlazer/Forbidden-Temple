using UnityEngine;
using System.Collections;

public class q : MonoBehaviour {

	public GameObject proj;
	public GameObject hand;
	public float cool=6f;
	public float cool1;
	public bool firing=false;
	public float range = 10f;
	public AudioClip cantcast;
	public AudioSource audio;
	public AudioClip QVoice;
	public string enemytag;
	public Transform enemy;
	GameObject missile;


	// Use this for initialization
	void Start () {

	}
		
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown ("a")) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit) && hit.transform.tag == enemytag) {
				enemy = hit.transform;
				if (Vector3.Distance (this.transform.position, hit.transform.position) <= range) {
					if (!firing) {
							firing = true;


						GetComponent<RecievedMovementGalilei> ().newposition = this.transform.position;
						this.transform.LookAt (hit.transform.position);
						audio.PlayOneShot (QVoice);
						GetComponent<Animation> ().Stop();
						GetComponent<Animation> ().Play ("005_Jump");
	
						 missile=Instantiate (proj, hand.transform.position, hand.transform.rotation) as GameObject;
						missile.GetComponent<skillshot> ().target = enemy;
						StartCoroutine ("cooldown");
						

					}
					else {
						audio.PlayOneShot (cantcast);
					}
				} else {
					audio.PlayOneShot (cantcast);
				}
			}
			else {
				audio.PlayOneShot (cantcast);
			}
		}




	}

	IEnumerator cooldown() {
		for (int i = 0; i <= (int)cool; i++) {
			yield return new WaitForSeconds (1);
			cool1 = cool - i;
			//print (cool1);
		}
		firing = false;
	}
		



}
