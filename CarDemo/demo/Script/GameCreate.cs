using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class GameCreate : MonoBehaviour
{
    public GameObject[] item;

    // Use this for initialization
    void Start()
    {
        //CreateCar();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void CreateCar(int carType, int carColor)
    {
        GameObject car;
        car = CreateItem(item[carType], new Vector3(-5, 2, -3), Quaternion.identity);
        SelectColor(car, (Color.carColor) carColor);
    }

    public void CreateCarColor(Color.carColor myCarColor)
    {
        //Color.SelectColor(myCarColor);
    }

    private GameObject CreateItem(GameObject createGameObject, Vector3 createVector3, Quaternion createQuaternion)
    {
        GameObject itemGo = Instantiate(createGameObject, createVector3, createQuaternion);
        return itemGo;
    }

    public void SelectColor(GameObject car, Color.carColor color)
    {
        switch (color)
        {
            case Color.carColor.red:
                car.GetComponent<MeshRenderer>().material.color = UnityEngine.Color.red;
                break;
            case Color.carColor.green:
                car.GetComponent<MeshRenderer>().material.color = UnityEngine.Color.green;
                break;
            case Color.carColor.blue:
                car.GetComponent<MeshRenderer>().material.color = UnityEngine.Color.blue;
                break;
        }
    }
}
