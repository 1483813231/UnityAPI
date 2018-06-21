using System.Collections;
using System.Collections.Generic;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.XR.WSA;

public class Pin : MonoBehaviour
{
    private float speed = 30;
    private bool isFly = false;
    private bool isCome = false;
    public Transform startPoint;
    public Transform circle;
    private Vector3 target;
    private static int score = 0;
    public Text scoreText;


    // Use this for initialization
    void Start()
    {
        startPoint = GameObject.Find("StartPoint").transform;
        circle = GameObject.Find("Circle").transform;
        target = new Vector3(circle.position.x, circle.position.y - 2.2f, circle.position.z);
        //scoreText = GameObject.Find("Canvas").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFly == false)
        {
            if (isCome == false)
            {
                transform.position =
                    Vector3.MoveTowards(transform.position, startPoint.position, speed * Time.deltaTime);
                if (Vector3.Distance(transform.position, startPoint.position) < 0.05f)
                {
                    isCome = true;
                }
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, target) < 0.05f)
            {
                transform.position = target;
                transform.parent = circle; //将组件的父亲设置为circle，针就会跟着小球转动
                isFly = false;
                score++;

                //设置ui中text的属性
                //scoreText.GetComponent<Text>().text = score.ToString();
                //scoreText = GameObject.Find("Canvas").GetComponent<Text>();
                //scoreText.text = score.ToString();
            }
        }
    }

    public void StartFly()
    {
        isFly = true;
        isCome = true;
    }

    public static int GetScore()
    {
        return score;
    }

    public static void ResetScore()
    {
        score = 0;
    }
}
