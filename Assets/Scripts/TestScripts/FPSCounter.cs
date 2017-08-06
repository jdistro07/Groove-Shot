using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCounter : MonoBehaviour {

	//public int frames = 60;

	void Awake () {
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = 60;
	}
}
