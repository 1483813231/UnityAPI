using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Born : MonoBehaviour
{
    public GameObject Tank;

    public bool isPlayerTank = false;

    public GameObject[] EnemyTankList;
    // Use this for initialization
    void Start()
    {
        Invoke("BornTank",1f);
        Destroy(gameObject,1);//一秒之后销毁出生效果
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void BornTank()
    {
        if (isPlayerTank)
        {
            Instantiate(Tank, transform.position, transform.rotation);
        }
        else
        {
            int num=Random.Range(0,2);
            Instantiate(EnemyTankList[num], transform.position, transform.rotation);
        }
    }
}
