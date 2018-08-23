using System.Collections;
using System.Collections.Generic;
//using NUnit.Framework.Internal.Filters;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Car : MonoBehaviour
{
    public enum CarType
    {
        Car1,
        Car2,
        Car3,
        Car4
    };

    //public GameObject rig;
    public float maxSpeed = 5;          //行驶的最大速度
    public float angularSpeed = 25;     //转弯的角速度
    public float force = 0.5f;          //加速度
    private float v = 0;                //x轴的返回值
    private float h = 0;                //z轴的返回值
    public CarType myCarType;           //赛车的种类
    private bool isOneBegin = true;     //是否第一次经过起点
    private bool isOneEnd = true;       //是否是第一次经过终点
    public GameObject endText;                //结束标语
    public GameObject timeText;

    // Use this for initialization
    void Start()
    {
        endText = GameObject.FindWithTag("EndText");
        timeText = GameObject.FindWithTag("TimeText");
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //CarMove();
    }

    //消除抖动和穿墙现象
    private void FixedUpdate()
    {
        CarMove();
    }

    private void CarMove()
    {
        v = Input.GetAxis("Vertical"); //返回z轴方向输入（向前 向后）

        //print(v);
        h = Input.GetAxis("Horizontal"); //返回x轴上的输入 (向左 向右)
        VerticalDirection(v);
    }

    //private void CarWheel() //赛车的转向
    //{
    //    h = Input.GetAxis("Horizontal");
    //    HorizontalDirection(h);
    //}

    private void HorizontalDirection(float h) //转向
    {
        if (h < 0) //左
        {
            transform.Rotate(new Vector3(0, -angularSpeed * Time.fixedDeltaTime * -h, 0));
        }
        else if (h > 0) //右
        {
            transform.Rotate(new Vector3(0, angularSpeed * Time.fixedDeltaTime * h, 0));
        }
    }

    private void VerticalDirection(float v)
    {
        if (v < 0) //向后行驶和转向
        {
            HorizontalDirection(-h);
            transform.Translate(Vector3.forward * v * maxSpeed * Time.fixedDeltaTime);
        }
        else if (v > 0) //向前行驶和转向
        {
            if (v > 0 && v < 0.95f)
            {
                //transform.Translate(Vector3.forward * v * maxSpeed * Time.fixedDeltaTime /* Mathf.Lerp(1,5,a)*a*/);
                //print(Mathf.Lerp(1, 5, a));
                gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * force);
            }

            HorizontalDirection(h);
            transform.Translate(Vector3.forward * v * maxSpeed * Time.fixedDeltaTime /* 3f*a*/);
        }
    }

    /*public void SelectCarType(CarType carType)
    {
        switch (carType)
        {
            case CarType.Car1:

                break;
            case CarType.Car2:
                break;
            case CarType.Car3:
                break;
            case CarType.Car4:
                break;
            default:
                break; 
        }
    }*/

    //起点和终点的判定
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "begin")
        {
            if (isOneBegin)
            {
                //开始计时
                print("开始计时");
                
                isOneBegin = false;
                timeText.GetComponent<TimeText>().Init();
            }
        }
        else if (other.tag == "end")
        {
            if (isOneEnd)
            {
                //结束计时，关闭游戏，返回主菜单
                print("结束计时，关闭游戏，返回主菜单");
                isOneEnd = false;
                timeText.GetComponent<TimeText>().EndTime();
                if (Time.timeScale == 1)
                {
                    Time.timeScale = 0;
                }
                
                //endText.SetActive(false);
                //SceneManager.LoadScene(0); 
            }
        }
    }
}
