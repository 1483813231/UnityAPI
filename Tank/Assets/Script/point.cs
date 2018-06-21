using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using UnityEngine;
using UnityEngine.SceneManagement;

public class point : MonoBehaviour
{
    private int change = 1;
    public Transform pos1;
    public Transform pos2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.W))
	    {
	        change = 1;
	        transform.position = pos1.position;
	    }
	    else if(Input.GetKeyDown(KeyCode.S))
	    {
	        change = 2;
	        transform.position = pos2.position;
	    }

	    if (change==1&&Input.GetKeyDown(KeyCode.Space))
	    {
	        SceneManager.LoadScene(1);
	    }
	}
}
