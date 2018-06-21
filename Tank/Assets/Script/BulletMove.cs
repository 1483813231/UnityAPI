using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    //属性
    private float moveSpeed = 10;
    public bool isPlayerBullet = false;

    //private string Name;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //让子弹朝向自身的y轴方向发射
        transform.Translate(transform.up * moveSpeed * Time.deltaTime, Space.World);
        //transform.Translate(transform.up * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            //如果是墙，则销毁墙和子弹
            case "Wall":
                Destroy(gameObject);
                Destroy(collision.gameObject);
                break;
            //如果是坦克，判断是不是自己发出的子弹，如果不是则销毁坦克
            case "PlayerTank":
                if (!isPlayerBullet)
                {
                    collision.SendMessage("Die");
                    Destroy(gameObject);
                }

                //Destroy(gameObject);

                //collision.SendMessage("Die");
                break;
            //判断是否为敌人
            case "Enemy":
                if (isPlayerBullet)
                {
                    collision.SendMessage("Die");
                    Destroy(gameObject);
                }

                //Destroy(gameObject);
                break;
            //如果是老窝，则销毁老窝和子弹
            case "Hear":
                collision.SendMessage("Die");
                Destroy(gameObject);
                break;
            //如果是障碍物，则销毁子弹
            case "Barrier":
                Destroy(gameObject);
                break;
            default:
                break;
        }
    }
}
