using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public SpriteRenderer sr;//heart的精灵渲染
    public Sprite breakHeart;//破坏后
    public GameObject ExplosionPrefab;//爆炸特效

    // Use this for initialization
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame

    void Die()
    {
        PlayerManager.Instance.isGameOver = true;
        Instantiate(ExplosionPrefab, transform.position, transform.rotation);
        //Destroy(ExplosionPrefab,0.167f);
        sr.sprite = breakHeart;
    }

}
