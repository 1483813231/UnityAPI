using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public ButtonKind button;

    //public GameObject panel;
    public enum ButtonKind
    {
        BeginGame,
        LoadGame,
        LeaveGame,
        About
    };

    // Use this for initialization
    void Start()
    {
        this.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => ButtonClick(button));
        //panel = GameObject.Find("Panel");
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ButtonClick(ButtonKind button)
    {
        switch (button)
        {
            case ButtonKind.BeginGame:
                //切换场景，准备开始游戏
                print("开始游戏");
                //panel.SetActive(false);
                //if (panel == null)
                //    print("获取失败");
                //panel.SetActive(true);
                SceneManager.LoadScene(1);
                break;
            case ButtonKind.LoadGame:
                //加载游戏
                //暂未实现
                print("加载游戏");
                break;
            case ButtonKind.LeaveGame:
                //退出游戏
                print("离开游戏");
                Application.Quit();
                break;
            case ButtonKind.About:
                //关于
                print("关于");
                break;
            default:
                break;
        }
    }
}
