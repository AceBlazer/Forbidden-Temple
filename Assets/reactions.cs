using UnityEngine;
using System.Collections;

public class reactions : MonoBehaviour {

	public AudioSource audio;
	public AudioClip laugh;
	public AudioClip taunt1;
	public AudioClip taunt2;
	bool b=false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown(KeyCode.F1)) {


			if (!b) {
				b = true;
				audio.PlayOneShot (taunt1);
				GetComponent<Animation> ().Stop ();
				GetComponent<Animation> ().Play ("204_AOQ_Hit");
				StartCoroutine ("cooldown");
			}
		}

		if (Input.GetKeyDown(KeyCode.F2)) {


			if (!b) {
				b = true;
				audio.PlayOneShot (taunt2);
				GetComponent<Animation> ().Stop ();
				GetComponent<Animation> ().Play ("202_AOQ_restB");
				StartCoroutine ("cooldown");
			}
		}

		if (Input.GetKeyDown(KeyCode.F3)) {


			if (!b) {
				b = true;
				GetComponent<Animation> ().Stop ();
				GetComponent<Animation> ().Play ("006_Pose");
				StartCoroutine ("cooldown");
			}
		}

		if (Input.GetKeyDown(KeyCode.F4)) {


			if (!b) {
				b = true;
				audio.PlayOneShot (laugh);
				GetComponent<Animation> ().Stop ();
				GetComponent<Animation> ().Play ("205_AOQ_glad");
				StartCoroutine ("cooldown");
			}
		}




	}

	IEnumerator cooldown() {
			yield return new WaitForSeconds (2);
		b = false;
	}
}
