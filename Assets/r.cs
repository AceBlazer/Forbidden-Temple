using UnityEngine;
using System.Collections;

public class r : MonoBehaviour {

	public GameObject proj;
	//public GameObject hand;
	public float cool;
	bool firing=false;
	public float range = 18f;
	public AudioClip cantcast;
	public AudioClip RVoice;
	public AudioSource audio;
	public Vector3 newpos;
	public float cool1;
	public GameObject sample;



	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown ("r")) {

				RaycastHit hit;
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

				if (Physics.Raycast (ray, out hit) && (hit.transform.tag == "enemy" || hit.transform.tag == "ground")) {

					if (Vector3.Distance (this.transform.position, hit.point) <= range) {

					Instantiate (sample, hit.point, hit.transform.rotation);
				
					if (!firing ) {
							firing = true;

						this.transform.LookAt (hit.transform.position);
						GetComponent<Animation> ().Stop();
						audio.PlayOneShot (RVoice);
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
				} else {
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
		Instantiate (proj, newpos+new Vector3(2,0,-3), Quaternion.identity);
		Instantiate (proj, newpos+new Vector3(2,0,3), Quaternion.identity);
		Instantiate (proj, newpos+new Vector3(4,0,-3), Quaternion.identity);
		Instantiate (proj, newpos+new Vector3(4,0,3), Quaternion.identity);
		Instantiate (proj, newpos+new Vector3(6,0,0), Quaternion.identity);

	}
		

}
