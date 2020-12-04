using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateOnKeyPress : MonoBehaviour {

	protected bool m_rotatekeypressed = false;
	public float m_DegreesPerKeyPress = 5.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// Rotate the object about some degrees on space press.
		if (Input.GetKey (KeyCode.Space) && !m_rotatekeypressed) 
		{
			transform.Rotate (Vector3.up * -m_DegreesPerKeyPress);
			m_rotatekeypressed = true;
		}

		if (!Input.GetKey (KeyCode.Space))
			m_rotatekeypressed = false;
	}
}
