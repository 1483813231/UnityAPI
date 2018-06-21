using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using NUnit.Framework.Constraints;
using UnityEditor;
using UnityEngine;

public class MapCreate : MonoBehaviour
{
    //0出生效果 1空气墙 2障碍物 3草 4家 5河流 6墙 
    public GameObject enemy;
    public GameObject playerTankBorn;
    public GameObject[] item;
    public List<Vector3> itemPosition = new List<Vector3>(); //已经占用的位置
    private void Awake()
    {
        InitCreateEnemy();
        InvokeRepeating("CreateEnemy", 4, 3);
        CreateAirWall();
        CreatePlayer();
        CreateHeart();
        CreateWall();
        
        
    }

    private void Update()
    {
        
    }


    //private void Create
    private void CreateItem(GameObject createGameObject, Vector3 createVector3, Quaternion createQuaternion)
    {
        GameObject itemGo = Instantiate(createGameObject, createVector3, createQuaternion);
        itemGo.transform.SetParent(gameObject.transform);
        itemPosition.Add(createVector3); //将变量加入以创建位置
    }

    private void CreateWall()
    {
        for (int i = 0; i < 20; i++)//障碍
        {
            CreateItem(item[2], CreateRandomPosition(), Quaternion.identity);
        }

        for (int i = 0; i < 20; i++)//草
        {
            CreateItem(item[3], CreateRandomPosition(), Quaternion.identity);
        }

        for (int i = 0; i < 20; i++)//河流
        {
            CreateItem(item[5], CreateRandomPosition(), Quaternion.identity);
        }

        for (int i = 0; i < 30; i++)//墙
        {
            CreateItem(item[6], CreateRandomPosition(), Quaternion.identity);
        }
    }
    private void CreateHeart()//创建基地
    {

        CreateItem(item[4], new Vector3(0, -8, 0), Quaternion.identity);
        CreateItem(item[6], new Vector3(-1, -8, 0), Quaternion.identity);
        CreateItem(item[6], new Vector3(1, -8, 0), Quaternion.identity);
        for (int i = -1; i < 2; i++)
        {
            CreateItem(item[6], new Vector3(i, -7, 0), Quaternion.identity);
        }
    }

    //产生随机位置
    private Vector3 CreateRandomPosition()
    {
        while (true)
        {
            Vector3 randRomVector3 = new Vector3(Random.Range(-10, 11), Random.Range(-8, 9));
            if (isNullPosition(randRomVector3))
            {
                return randRomVector3;
            }
        }
    }

    private bool isNullPosition(Vector3 randRomVector3)//判断位置是否重复
    {
        for (int i = 0; i < itemPosition.Count; i++)
        {
            if (itemPosition[i].Equals(randRomVector3))
            {
                return false;
            }
        }

        return true;
    }

private void CreateAirWall()
    {
        //左边空气墙 x=10.8 y=8 -8
        for (float i = -8; i < 9; i++)
        {
            CreateItem(item[1], new Vector3(11.8f, i, 0), Quaternion.identity);
        }

        //右边空气墙
        for (float i = -8; i < 9; i++)
        {
            CreateItem(item[1], new Vector3(-11.8f, i, 0), Quaternion.identity);
        }

        //上方
        for (float i = -10.8f; i < 11.8; i++)
        {
            CreateItem(item[1], new Vector3(i, 9, 0), Quaternion.identity);
        }

        //下方
        for (float i = -10.8f; i < 11.8; i++)
        {
            CreateItem(item[1], new Vector3(i, -9, 0), Quaternion.identity);
        }
    }

    private void InitCreateEnemy()
    {
        enemy.GetComponent<Born>().isPlayerTank = false;
        CreateItem(enemy, new Vector3(-10.8f, 8, 0), Quaternion.identity);
        CreateItem(enemy, new Vector3(0, 8, 0), Quaternion.identity);
        CreateItem(enemy, new Vector3(10.8f, 8, 0), Quaternion.identity);
    }
    private void CreateEnemy()//产生敌人
    {
        //for (int i = 0; i < 10; i++)
        //{
        //    //int num = Random.Range(0, 2);
        //    
        //    CreateItem(enemy, CreateRandomPosition(), Quaternion.identity);
        //}
        enemy.GetComponent<Born>().isPlayerTank = false;
        int num = Random.Range(0, 3);
        Vector3 EnemyPosition=new Vector3();
        if (num ==0)   
        {
            EnemyPosition=new Vector3(-10.8f,8,0);
        }
        else if (num==1)
        {
            EnemyPosition = new Vector3(0, 8, 0);
        }
        else if (num==2)
        {
            EnemyPosition = new Vector3(10.8f, 8, 0);
        }
        CreateItem(enemy, EnemyPosition, Quaternion.identity);

    }

    private void CreatePlayer()//生成玩家
    {
        Vector3 playerTankPosition = new Vector3(-2, -8, 0);
        playerTankBorn.GetComponent<Born>().isPlayerTank = true;
        CreateItem(playerTankBorn, playerTankPosition, Quaternion.identity);
        
    }

}
