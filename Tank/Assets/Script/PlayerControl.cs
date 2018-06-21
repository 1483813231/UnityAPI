using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    //属性
    private float moveSpeed = 5; //速度
    private Vector3 bulletEulerAngles; //子弹应当旋转的角度
    private float timeVal; //子弹射出cd
    private float defendTimeval = 3; //无敌时间
    private bool isDefended = true; //无敌状态

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
        //复活无敌时间
        if (isDefended)
        {
            print("无敌");
            DefendEffectPrefab.SetActive(true); //开启无敌特效
                defendTimeval -= Time.deltaTime;
            if (defendTimeval <= 0)
            {
                DefendEffectPrefab.SetActive(false); //关闭无敌特效
                isDefended = false;
                print("无敌关闭");
            }
        }

        //坦克攻击cd
        
    }

    //消除坦克碰撞时的抖动
    private void FixedUpdate() //固定物理帧 每一帧都是固定时间，两个物体互相受到的力也是固定的
    {
        if (PlayerManager.Instance.isGameOver)
        {
            return;
        }
        PlayerMove();
        if (timeVal >= 0.4f)
        {
            Attack();
        }
        else
        {
            timeVal += Time.fixedDeltaTime;
        }
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
    }

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
    }

    //坦克的移动方法
    private void PlayerMove()
    {
        //Vector3.right   x
        //Vector3.up      y
        //Vector3.forward z
        //
        float h = Input.GetAxisRaw("Horizontal"); //返回水平方向输入的值
        HorizontalDirection(h);
        transform.Translate(Vector3.right * h * moveSpeed * Time.fixedDeltaTime, Space.World); //以世界坐标为参照水平方向移动
        if (h != 0)
        {
            return;
        }

        float v = Input.GetAxisRaw("Vertical"); //返回垂直方向输入的值
        VerticalDirection(v);
        transform.Translate(Vector3.up * v * moveSpeed * Time.fixedDeltaTime, Space.World); //以世界坐标为参照竖直方向移动
        //bug 物体左右朝向时，物体还是可以上下移动 
        //if (spriteRenderer.sprite == TankSprites[1] || spriteRenderer.sprite == TankSprites[3])
        //{
        //    transform.Translate(Vector3.right * h * moveSpeed * Time.fixedDeltaTime, Space.World);//以世界坐标为参照水平方向移动
        //}
        //if (spriteRenderer.sprite == TankSprites[0] || spriteRenderer.sprite == TankSprites[2])
        //{
        //    transform.Translate(Vector3.up * v * moveSpeed * Time.fixedDeltaTime, Space.World);//以世界坐标为参照竖直方向移动
        //}
    }

    //坦克的攻击方法
    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
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
        if (isDefended)
        {
            return;
        }

        
        //产生死亡特效
        Instantiate(ExplosionPrefab, transform.position, transform.rotation);
        //游戏物体死亡
        Destroy(gameObject);
        PlayerManager.Instance.isDie = true;
    }
}

