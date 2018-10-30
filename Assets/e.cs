using UnityEngine;
using System.Collections;

public class e : MonoBehaviour {

	public AudioClip cantcast;
	public AudioSource audio;
	public bool firing=false;
	public float cool=15f;
	public float range = 12f;
	public GameObject proj;
	public Vector3 newpos;
	public float cool1;
	public GameObject player;
	public float casttime=0.2f;
	public AudioClip EVoice;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		player = GameObject.FindGameObjectWithTag ("player1");

		if (Input.GetKeyDown ("e")) {
			StartCoroutine ("casting");
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit) && hit.transform.tag == "player1") {

				if (Vector3.Distance (this.transform.position, hit.point) <= range) {

					if (!firing) {
						firing = true;
						audio.PlayOneShot (EVoice);
						newpos = hit.point;
						Instantiate (proj, player.transform.position, Quaternion.identity);
						StartCoroutine ("cooldown");
					} else {
						audio.PlayOneShot (cantcast);
					}
				
				} else {
					audio.PlayOneShot (cantcast);
				}
			} else {
				audio.PlayOneShot (cantcast);
			}
		} else {
			if (Input.GetKeyDown (KeyCode.LeftShift) && Input.GetKeyDown (KeyCode.E)) {
						if (!firing) {
							firing = true;
							audio.PlayOneShot (EVoice);
							Instantiate (proj, player.transform.position, Quaternion.identity);
							StartCoroutine ("cooldown");
						} else {
							audio.PlayOneShot (cantcast);
						}
			}
		}
	}

	IEnumerator cooldown() {
		for (int i = 0; i <= (int)cool; i++) {
			yield return new WaitForSeconds (1);
			cool1 = cool - i;
		//	print (cool1);
		}
		firing = false;
	}


	IEnumerator casting() {
		yield return new WaitForSeconds (casttime);
		
	}

}
