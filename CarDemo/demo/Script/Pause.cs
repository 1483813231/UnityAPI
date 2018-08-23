using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

    private bool isFirst = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnButtonClick()
    {
        if (isFirst)
        {
            //游戏暂停
            Time.timeScale = 0;
            print("游戏暂停");
            isFirst = false;
        }
            
        else
        {
            //游戏恢复
            Time.timeScale = 1;
            print("游戏恢复");
            isFirst = true;
        }
    }
}
