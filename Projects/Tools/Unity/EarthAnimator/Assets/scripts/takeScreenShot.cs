using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takeScreenShot : MonoBehaviour {
	protected bool m_screenshotkeypressed = false;
	public int screenshotNumber = 0;
	public Transform rotationTransform;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// ...also rotate around the World's Y axis
		if (Input.GetKey (KeyCode.Return) && !m_screenshotkeypressed)
		{
			m_screenshotkeypressed = true;
			string rot = "";
			if (rotationTransform.transform.eulerAngles.y < 0.0f)
				rot = "_";
			if (rotationTransform)
				rot += "_" + (int)Mathf.Round(Mathf.Abs(rotationTransform.transform.eulerAngles.y));
			screenshotNumber++;
			string filename = "RENDERED/earthanim_" + screenshotNumber + rot+".png";
			ScreenCapture.CaptureScreenshot (filename);
			Debug.Log ("Screenshot taken: " + filename);
		}

		if (!Input.GetKey (KeyCode.Return))
			m_screenshotkeypressed = false;
	}
}
