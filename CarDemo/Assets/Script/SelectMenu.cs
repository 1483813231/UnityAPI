using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
//using System.Diagnostics.Eventing.Reader;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectMenu : MonoBehaviour
{
    private bool isFirst = true;
    //private bool isFirst = true;
    public Dropdown carType;
    public Dropdown carColor;
    private GameObject gameCreate;
    private GameObject car;

    // Use this for initialization
    void Start()
    {
        gameCreate = GameObject.FindGameObjectWithTag("GameCreate");
        if (!gameCreate)
        {
            print("获取失败");
        }
        //SelectMenuObject=GameObject.Find("selectMenu");
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnButtonClick()
    {
        
        //print(carType.value);
        //print(carColor.value);
        if (isFirst)
        {
            gameCreate.GetComponent<GameCreate>().CreateCar(carType.value, carColor.value);
            car=GameObject.FindWithTag("Car");
            gameObject.SetActive(false);
            isFirst = false;
            print(isFirst);
        }
        else
        {
            Destroy(car);
            gameObject.SetActive(true);
            print(isFirst);
            isFirst = true;
        }

        print("完成");
    }

    public void GoBack()
    {
        SceneManager.LoadScene(0);
    }
}
