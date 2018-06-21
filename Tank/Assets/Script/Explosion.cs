using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, 0.167f);//在0.167秒后（动画播放完成后）销毁爆炸特效
    }

    // Update is called once per frame
    void Update()
    {
    }
}
