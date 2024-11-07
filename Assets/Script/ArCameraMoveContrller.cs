using UnityEngine;
using Vuforia;

public class ArCameraMoveController : MonoBehaviour
{
    public ObserverBehaviour targetObserver; // Ŀ��ͼƬ������ Image Target��
    private bool isTargetDetected = false;   // ���ڼ�¼Ŀ���Ƿ��ѱ���⵽

    void Start()
    {
        // ���Ŀ���Ƿ��Ѹ�ֵ
        if (targetObserver != null)
        {
            // ����Ŀ��״̬�仯�¼�
            targetObserver.OnTargetStatusChanged += OnTargetStatusChanged;
        }
    }

    void OnDestroy()
    {
        // ȡ�������¼�����ֹ�ڴ�й©
        if (targetObserver != null)
        {
            targetObserver.OnTargetStatusChanged -= OnTargetStatusChanged;
        }
    }

    // ��Ŀ��״̬�����仯ʱ����
    private void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus targetStatus)
    {
        // ���Ŀ��״̬�Ƿ�Ϊ�Ѹ���
        if (targetStatus.Status == Status.TRACKED)
        {
            Debug.Log("Ŀ���Ѽ�⵽");
            isTargetDetected = true;
        }
        else
        {
            Debug.Log("Ŀ�궪ʧ");
            isTargetDetected = false;
        }
    }

    void Update()
    {
        if (isTargetDetected)
        {
            // ʹ�ü��̿��� ARCamera ��λ��
            float moveSpeed = 5f;
            float horizontal = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
            float vertical = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
            float upDown = Input.GetAxis("Jump") * moveSpeed * Time.deltaTime;

            // ����������ƶ�
            Vector3 moveDirection = new Vector3(horizontal, upDown, vertical);
            transform.Translate(moveDirection);
        }
    }
}
