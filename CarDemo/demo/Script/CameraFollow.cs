using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    public Transform target; //目标物体  
    public float distance = 10; //距离  
    public float height = 5; //高度  
    public float heightDamping = 2; //高度的阻尼系数  
    public float rotationDamping = 3; //旋转的阻尼系数  

    void LateUpdate()
    {
        //如果场景中有Player物体  
        if (GameObject.FindWithTag("Car"))
        {
            //print("以获取");
            //如果目标物体为空  
            if (!target)
                //重新取得目标物体  
                target = GameObject.FindWithTag("Car").transform;
            //摄像机最终旋转的角度  
            float wantedRotationAngle = target.eulerAngles.y;
            //摄像机最终的高度  
            float wantedHeight = target.position.y + height;
            //摄像机当前的角度  
            float currentRotationAngle = transform.eulerAngles.y;
            //摄像机当前的高度  
            float currentHeight = transform.position.y;
            currentRotationAngle =
                Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);
            currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);
            //相机当前的旋转  
            Quaternion currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);
            //相机的实际位置 = 目标位置 - 相机当前的正方向位置*距离   
            Vector3 pos = target.position - currentRotation * Vector3.forward * distance;
            //相机实际位置的高度  
            pos.y = currentHeight;
            //最后把实际位置赋值给相机  
            transform.position = pos;
            //摄像机始终朝向目标位置  
            transform.LookAt(target);
        }
    }
}
