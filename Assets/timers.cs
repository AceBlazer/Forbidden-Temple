using UnityEngine;
using System.Collections;

public class timers : MonoBehaviour {

	public float coolQ;
	public float coolW;
	public float coolE;
	public float coolR;
	public Texture2D QtextureActive;
	public Texture2D QtextureInctive;

	public Texture2D WtextureActive;
	public Texture2D WtextureInctive;

	public Texture2D EtextureActive;
	public Texture2D EtextureInctive;

	public Texture2D RtextureActive;
	public Texture2D RtextureInctive;



	void Start () {

	}

	// Use this for initialization
	void Update () {

		coolQ=GetComponent<q>().cool1;
		coolW=GetComponent<w>().cool1;
		coolE=GetComponent<e>().cool1;
		coolR=GetComponent<r>().cool1;

	}

	void OnGUI() {
		if (coolQ > 0f) {
			GUI.DrawTexture (new Rect((Screen.width/2)-90,Screen.height-35,30,30),QtextureInctive);
		} else {
			GUI.DrawTexture (new Rect((Screen.width/2)-90,Screen.height-35,30,30),QtextureActive);
		}

		if (coolW > 0f) {
			
		} else {
			GUI.DrawTexture (new Rect((Screen.width/2)-50,Screen.height-35,30,30),WtextureActive);
		}

		if (coolE > 0f) {
			GUI.DrawTexture (new Rect((Screen.width/2)+30,Screen.height-35,30,30),RtextureInctive);
		} else {
			GUI.DrawTexture (new Rect((Screen.width/2)-10,Screen.height-35,30,30),EtextureActive);
		}

		if (coolR > 0f) {
			GUI.DrawTexture (new Rect((Screen.width/2)+30,Screen.height-35,30,30),RtextureInctive);
		} else {
			GUI.DrawTexture (new Rect((Screen.width/2)+30,Screen.height-35,30,30),RtextureActive);
		}




		GUI.Label (new Rect((Screen.width/2)-80,Screen.height-30,30,30),coolQ.ToString());
		GUI.Label (new Rect((Screen.width/2)-40,Screen.height-30,30,30),coolW.ToString());
		GUI.Label (new Rect((Screen.width/2),Screen.height-30,30,30),coolE.ToString());
		GUI.Label (new Rect((Screen.width/2)+40,Screen.height-30,30,30),coolR.ToString());


	}
}
