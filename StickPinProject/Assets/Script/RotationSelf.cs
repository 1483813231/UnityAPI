using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationSelf : MonoBehaviour {

    private Transform startPoint;
    private Transform spawnPoint;

    public float speed = 140;
    // Use this for initialization
    void Start()
    {
        print("start");

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, -speed * Time.deltaTime));
    }
}
