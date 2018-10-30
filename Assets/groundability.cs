using UnityEngine;
using System.Collections;

public class groundability : MonoBehaviour {


	public float time;
	public bool b=false;
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		
	
			StartCoroutine ("cooldown");
			if (b) {
				Destroy (gameObject);
			}

	}

	IEnumerator cooldown() {

		yield return new WaitForSeconds (time);
		b=true;
	}
}
