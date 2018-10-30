using UnityEngine;
using System.Collections;

public class shop : MonoBehaviour {

	public Texture2D menu;
	public Texture2D container;
	public Texture2D potion;

	// Use this for initialization
	void Start () {

	}


	// Update is called once per frame
	void OnGUI () {

		GUI.DrawTexture (new Rect ((Screen.width/2)-240, (Screen.height/2)-320, 480, 640), menu);

		GUI.DrawTexture (new Rect ((Screen.width/2)-220, (Screen.height/2)-300, 40, 40), container);
		GUI.DrawTexture (new Rect ((Screen.width/2)-220, (Screen.height/2)-300, 40, 40), potion);
		GUI.Label (new Rect ((Screen.width/2)-205, (Screen.height/2)-260, 20, 20), "50");

		if (GUI.Button (new Rect ((Screen.width/2)-50 , (Screen.height/2)+200 , 100, 30), "Buy")) {
			
		}

	}
}
