using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    //private Transform startPoint;
    private Transform spawnPoint;
    private Pin currenPin;
    private bool isGameEnd = false;
    private int score = 0;
    private Text scoreText;
    private Camera mainCamera;
    private float animationSpeed=3;
    public GameObject pinPrefab;
    //public GameObject scoreText;
    
	// Use this for initialization
	void Start ()
	{
	    //startPoint = GameObject.Find("StartPoint").transform;
	    spawnPoint = GameObject.Find("SpawnPoint").transform;
        
	    scoreText = GameObject.Find("Text").GetComponent<Text>();
        //if (scoreText == null)
        //{
        //    print("scoreText == null");
        //}
	    mainCamera = Camera.main;
        SpawnPin();

	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (isGameEnd) return;
	    if (Input.GetMouseButtonDown(0))
	    {
            currenPin.StartFly();
            SpawnPin();
	        //score++;
	        score = Pin.GetScore();
            print(score);
	        scoreText.text = score.ToString();
	        //设置ui中text的属性
	        //scoreText.GetComponent<Text>().text = score.ToString();
	        //print(scoreText.GetComponent<Text>().text);
	    }
	}

    void SpawnPin()
    {
        currenPin = GameObject.Instantiate(pinPrefab, spawnPoint.position, pinPrefab.transform.rotation).GetComponent<Pin>();
    }

    public void GameEnd()
    {
        print("GameEnd");
        if (isGameEnd) return;
        GameObject.Find("Circle").GetComponent<RotationSelf>().enabled=false;
        //开启协程
        StartCoroutine(GameEndAnimation());
        Pin.ResetScore();
        isGameEnd = true;
    }

    IEnumerator GameEndAnimation()
    {
        while (true)
        {
            //
            mainCamera.backgroundColor = Color.Lerp(mainCamera.backgroundColor,Color.red,animationSpeed*Time.deltaTime);
            mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize,4,animationSpeed*Time.deltaTime);
            if (Mathf.Abs(mainCamera.orthographicSize - 4) < 0.01f)
            {
                break;
            }
            yield return 0;

        }

        yield return new WaitForSeconds(1);//等待一秒
        //重新加载当前场景
        //SceneManager.LoadScene("Main");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
