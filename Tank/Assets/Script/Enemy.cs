using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //属性
    private float moveSpeed = 3; //速度
    private Vector3 bulletEulerAngles; //子弹应当旋转的角度
    private float timeVal = 0; //子弹射出cd
    private float h;
    private float v=-1;
    private float changeDirection = 0;//转向时间间隔
    

    //引用
    private SpriteRenderer spriteRenderer;
    public Sprite[] TankSprites; //上 右 下 左
    public GameObject BulletPrefab; //子弹的引用
    public GameObject ExplosionPrefab; //爆炸特效的引用
    public GameObject DefendEffectPrefab; //无敌特效的引用

    // Use this for initialization
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); //获取SpriteRenderer组件
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //坦克攻击间隔
        if (timeVal >= 3)
        {
            Attack();
        }
        else
        {
            timeVal += Time.deltaTime;
            //timeVal += timeVal;
        }
    }

    //消除坦克碰撞时的抖动
    private void FixedUpdate() //固定物理帧 每一帧都是固定时间，两个物体互相受到的力也是固定的
    {
        PlayerMove();
    }

    private void HorizontalDirection(float h)
    {
        if (h < 0) //左
        {
            spriteRenderer.sprite = TankSprites[3];
            bulletEulerAngles = new Vector3(0, 0, 90);
        }
        else if (h > 0) //右
        {
            spriteRenderer.sprite = TankSprites[1];
            bulletEulerAngles = new Vector3(0, 0, -90);
        }
    } //判定水平方向上的输入

    private void VerticalDirection(float v)
    {
        if (v < 0) //下
        {
            spriteRenderer.sprite = TankSprites[2];
            bulletEulerAngles = new Vector3(0, 0, 180);
        }
        else if (v > 0) //上
        {
            spriteRenderer.sprite = TankSprites[0];
            bulletEulerAngles = new Vector3(0, 0, 0);
        }
    } //判定竖直方向的输入

    //坦克的移动方法
    private void PlayerMove()
    {
        if (changeDirection > 4)
        {
            int num = Random.Range(0, 8); //返回水平方向输入的值
            if (num >= 1 && num < 2)
            {
                h = -1;
                v = 0;
            }
            else if (num >= 2 && num < 4)
            {
                h = 1;
                v = 0;
            }
            else if (num ==0)
            {
                v = 1;
                h = 0;
            }
            else if (num >4)
            {
                v = -1;
                h = 0;

            }
            
            changeDirection = 0;
        }
        else
        {
            changeDirection += Time.deltaTime;
        }
        HorizontalDirection(h);
        transform.Translate(Vector3.right * h * moveSpeed * Time.fixedDeltaTime, Space.World); //以世界坐标为参照水平方向移动
        if (h != 0)
        {
            return;
        }
        VerticalDirection(v);

        transform.Translate(Vector3.up * v * moveSpeed * Time.fixedDeltaTime, Space.World); //以世界坐标为参照竖直方向移动
    }

    //坦克的攻击方法
    private void Attack()
    {
        if (timeVal > 3)
        {
            //子弹旋转的角度=子弹当前的角度+子弹应当旋转的角度
            //rotation在面板上显示的是欧拉角的度数，实际上他是一个四元数类型的变量
            //使用Quaternion.Euler()将欧拉角转换为四元数
            //Instantiate(BullectPrefab, transform.position, transform.rotation);
            Instantiate(BulletPrefab, transform.position,
                Quaternion.Euler(BulletPrefab.GetComponent<Transform>().eulerAngles + bulletEulerAngles));
            timeVal = 0;
        }
    }

    //坦克的死亡方法
    private void Die()
    {
        //播放死亡音效
        
        //产生死亡特效
        Instantiate(ExplosionPrefab, transform.position, transform.rotation);
        //游戏物体死亡
        Destroy(gameObject);
        PlayerManager.Instance.score++;
    }
}