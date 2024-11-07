using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    // ��ȡ���λ�ò�ת��������
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

                // �� y ����תģ��
                transform.Rotate(0, -rotationAmountY, 0);
            }
        }

        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            if (touchZero.phase == TouchPhase.Moved || touchOne.phase == TouchPhase.Moved)
            {
                // ��ȡ��ǰ������ľ���
                float currentDistance = (touchZero.position - touchOne.position).magnitude;

                // ��� previousDistance Ϊ 0����ʾ�Ǹտ�ʼ��⣬ֱ�Ӹ�ֵΪ��ǰ����
                if (previousDistance == 0)
                {
                    previousDistance = currentDistance;
                }

                // �������仯��
                float distanceDelta = currentDistance - previousDistance;
                float zoomFactor = 0.01f;
                float scaleChange = distanceDelta * zoomFactor;

                // ����ģ�͵�����
                transform.localScale += new Vector3(scaleChange, scaleChange, scaleChange);

                // ���� previousDistance
                previousDistance = currentDistance;
            }
        }
        else
        {
            // ���û��˫ָ���أ����� previousDistance
            previousDistance = 0f;
        }

        // �������ŷ�Χ
        transform.localScale = Vector3.ClampMagnitude(transform.localScale, 1.5f);
    }

}



