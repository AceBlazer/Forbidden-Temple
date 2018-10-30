using UnityEngine;
using System.Collections;

public class showping : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnGUI () {
		
		GUI.Label(new Rect(Screen.width-50,0,50,30), PhotonNetwork.GetPing ().ToString()+" ms");
	}
}
