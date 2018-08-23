using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TimeText : MonoBehaviour
{
    private Text selfText;

    //计时器
    private float timer;

    private bool isEnd=true;

    // Use this for initialization
    void Start()
    {
        selfText = this.GetComponent<Text>();
        //计时器初始值为0
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isEnd)
        {
            BeginTime();
        }
    }

    public void Init()
    {
        isEnd = false;
        timer = 0;
    }
    public void BeginTime()
    {
        //逐帧增长
        timer += Time.deltaTime;
        TimeSpan tempTimeSpan = new TimeSpan(0, 0, (int) timer);
        //显示时间
        selfText.text = tempTimeSpan.Hours + ":" + tempTimeSpan.Minutes + ":" + tempTimeSpan.Seconds;
    }

    public void EndTime()
    {
        isEnd = true;
    }
}
