using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
//using System.Management.Instrumentation;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    //属性
    public int score = 0;                       //分数
    public int lifeValue = 3;                   //生命
    public bool isDie = false;                  //是否死亡
    public bool isGameOver = false;             //游戏是否结束
    private static PlayerManager instance;      //实例
    //引用
    public GameObject born;
    public Text ScoreText;
    public Text LifeText;
    public GameObject gameOverUI;

    public static PlayerManager Instance        //单例模式
    {
        get { return instance; }
        set { instance = value; }
    }

    void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
        {
            gameOverUI.SetActive(true);
            return;
        }

        if (isDie)
        {
            Recover();
        }

        ScoreText.text = score.ToString();
        LifeText.text = lifeValue.ToString();
    }

    private void Recover()
    {
        if (lifeValue <= 0)
        {
            //游戏结束
            isGameOver = true;
        }
        else
        {
            if (isDie)
            {
                print("复活");
                lifeValue--;
                GameObject go = Instantiate(born, new Vector3(-2, -8, 0), Quaternion.identity);
                go.GetComponent<Born>().isPlayerTank = true;
                isDie = false;
            }
        }
    }
}
