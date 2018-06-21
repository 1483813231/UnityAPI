using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinHead : MonoBehaviour
{
    // Use this for initialization
    private void OnTriggerEnter2D(Collider2D collion)
    {
        //print("OnTriggerEnter2D");
        //if (collion.tag == "PinHead")
        //{
        //    print("OnTriggerEnter2D");
        //    GameObject.Find("GameManager").GetComponent<Manager>().GameEnd();
        //}
        print("OnTriggerEnter2D");
        GameObject.Find("GameManager").GetComponent<Manager>().GameEnd();
    }
}
