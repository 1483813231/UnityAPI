using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Color : MonoBehaviour
{
    public enum carColor
    {
        red,
        blue,
        green
    };
    //private GameObject car;


    // Use this for initialization
	void Start ()
	{
	    //car = GameObject.Find("Car");
	    //carColor color = carColor.red;
	    //SelectColor(color);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //public void SelectColor(carColor color)
    //{
    //    switch (color)
    //    {
    //        case carColor.red:
    //            gameObject.GetComponent<MeshRenderer>().material.color = UnityEngine.Color.red;
    //            break;
    //        case carColor.green:
    //            gameObject.GetComponent<MeshRenderer>().material.color = UnityEngine.Color.green;
    //            break;
    //        case carColor.blue:
    //            gameObject.GetComponent<MeshRenderer>().material.color = UnityEngine.Color.blue;
    //            break;
    //    }
        
        
    //}
}
