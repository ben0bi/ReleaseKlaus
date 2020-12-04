using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startSequence : MonoBehaviour {
	protected bool m_started = false;
	protected float m_actualRotationInterval = 0.0f;
	protected int m_actualImageNumber = 0;
	protected float m_smallestSpeed = 0.0f;

	public Transform planet;
	public Transform clouds;
	public float planetSpeed = 6.0f;
	public float cloudSpeed = 3.0f;
	public string filePrefix ="planetanim_";

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.F4) && !m_started) 
		{
			Debug.Log ("Sequence start.");
			m_started = true;
			m_smallestSpeed = planetSpeed;
			if (cloudSpeed < m_smallestSpeed)
				m_smallestSpeed = cloudSpeed;
			m_actualRotationInterval = 0;
			m_actualImageNumber = 0;
		}

		if (m_started == true) 
		{
			if (planet)
				planet.transform.Rotate (Vector3.up * -planetSpeed);
			if (clouds)
				clouds.transform.Rotate (Vector3.up * -cloudSpeed);
			m_actualRotationInterval += m_smallestSpeed;
			m_actualImageNumber++;

			string filename = "RENDERED/" + filePrefix + m_actualImageNumber + ".png";//"_" + Mathf.Round (Mathf.Abs (m_actualRotationInterval))+".png";
			ScreenCapture.CaptureScreenshot (filename);
			Debug.Log("Screenshot "+m_actualImageNumber+": "+filename);
			if (m_actualRotationInterval >= 360.0f) 
			{
				Debug.Log ("Sequence end.");
				m_started = false;
			}
		}
	}
}
