using UnityEngine;
using System.Collections;

public class callescmenu : MonoBehaviour {
	public GameObject escmenu;
	bool en=false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			escmenu.SetActive (!en);
			en = !en;
		}
	}
}
