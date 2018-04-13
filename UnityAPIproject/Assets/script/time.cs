using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class time : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	    Debug.Log("Time.deltaTime" + Time.deltaTime);
	    Debug.Log("Time.deltaTime" + Time.fixedDeltaTime);
        Debug.Log("Time.frameCount" + Time.frameCount);
        Debug.Log("Time.fixedTime" + Time.fixedTime);
        Debug.Log("Time.realtimeSinceStartup" + Time.realtimeSinceStartup);
        Debug.Log("Time.smoothDeltaTime" + Time.smoothDeltaTime);
        Debug.Log("Time.time" + Time.time);
        Debug.Log("Time.timeScale" + Time.timeScale);
        Debug.Log("Time.timeSinceLevelLoad" + Time.timeSinceLevelLoad);
        Debug.Log("Time.timeSinceLevelLoad" + Time.timeSinceLevelLoad);
	}
}
