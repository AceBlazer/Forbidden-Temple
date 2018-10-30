using UnityEngine;
using System.Collections;

public class escmenu : MonoBehaviour {

	public Texture2D menu;

	// Use this for initialization
	void Start () {
	
	}
		
	
	// Update is called once per frame
	void OnGUI () {
		
		GUI.DrawTexture (new Rect ((Screen.width/2)-240, (Screen.height/2)-320, 480, 640), menu);
		

		if (GUI.Button (new Rect ((Screen.width/2) , (Screen.height/2) , 200, 30), "Exit Game")) {
				Application.Quit ();
			}

	}
}
