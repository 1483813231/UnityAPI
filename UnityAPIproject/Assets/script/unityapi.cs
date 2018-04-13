using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unityapi : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        //开始时执行一次
        Debug.Log("Start");
    }

    // Update is called once per frame
    //void Update()
    //{
    //    //每秒都会执行很多次
    //    Debug.Log("Update");
    //}

    void Reset()
    {
        Debug.Log("Reset");
    }

    void Awake()
    {
        //激活唤醒
        Debug.Log("Awake");
    }

    void OnEnable()
    {
        //开启
        Debug.Log("OnEnable");
    }

    void FixedUpdate()
    {
        //固定刷新的次数
        Debug.Log("FixedUpdata");
    }

    void Update()
    {
        //每秒刷新的次数，跟运行环境有关
        Debug.Log("Update");
    }

    void LateUpdate()
    {
        //每秒刷新的次数，在update之后执行
        Debug.Log("LateUpdate");
    }

    void OnApplicationPause()
    {
        //暂停时调用
        Debug.Log("OnApplicationPause");
    }
}
