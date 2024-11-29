using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    // 获取点击位置并转换成射线
    private int Num;
    private Vector3 normalVolum;
    private float previousDistance = 0f;
    // Start is called before the first frame update
    void Start()
    {
        normalVolum = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {

        MoveAndZoom();

    }

     public void ChooseOne() {

       
                
            
        
    }

    void MoveAndZoom() {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                float rotationSpeed = 0.1f;
                float rotationAmountY = touch.deltaPosition.x * rotationSpeed;

                // 绕 y 轴旋转模型
                transform.Rotate(0, -rotationAmountY, 0);
            }
        }

        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            if (touchZero.phase == TouchPhase.Moved || touchOne.phase == TouchPhase.Moved)
            {
                // 获取当前两触点的距离
                float currentDistance = (touchZero.position - touchOne.position).magnitude;

                // 如果 previousDistance 为 0，表示是刚开始检测，直接赋值为当前距离
                if (previousDistance == 0)
                {
                    previousDistance = currentDistance;
                }

                // 计算距离变化量
                float distanceDelta = currentDistance - previousDistance;
                float zoomFactor = 0.01f;
                float scaleChange = distanceDelta * zoomFactor;

                // 更新模型的缩放
                transform.localScale += new Vector3(scaleChange, scaleChange, scaleChange);

                // 更新 previousDistance
                previousDistance = currentDistance;
            }
        }
        else
        {
            // 如果没有双指触控，重置 previousDistance
            previousDistance = 0f;
        }

        // 限制缩放范围
        transform.localScale = Vector3.ClampMagnitude(transform.localScale, 1.5f);
    }

}



