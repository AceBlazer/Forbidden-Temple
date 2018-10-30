using UnityEngine;
using System.Collections;

public class facecamtest : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Camera m_Camera=Camera.main;
		transform.LookAt(transform.position + m_Camera.transform.rotation * Vector3.back,
			m_Camera.transform.rotation * Vector3.up);
	}
}
