using UnityEngine;
using System.Collections;

public class w : MonoBehaviour {

	public GameObject proj;
	//public GameObject hand;
	public float cool=8;
	bool firing=false;
	public float range = 12f;
	public AudioClip cantcast;
	public AudioSource audio;
	public Vector3 newpos;
	public float cool1;
	public AudioClip WVoice;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown ("z")) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit) && (hit.transform.tag == "enemy" || hit.transform.tag == "ground" )) {
				
				if (Vector3.Distance (this.transform.position, hit.point) <= range) {
				 
					if (!firing) {
						firing = true;

						this.transform.LookAt (hit.transform.position);
						audio.PlayOneShot (WVoice);
						GetComponent<Animation> ().Stop();
						GetComponent<Animation> ().Play ("005_Jump");

						position (hit.point);
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
		//	print (cool1);
		}
		firing = false;
	}

	void position (Vector3 pos) {
		newpos = pos;
		Instantiate (proj, newpos, Quaternion.identity);
	}

}
