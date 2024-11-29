using UnityEngine;
using Vuforia;

public class ArCameraMoveController : MonoBehaviour
{
    public ObserverBehaviour targetObserver; // 目标图片对象（如 Image Target）
    private bool isTargetDetected = false;   // 用于记录目标是否已被检测到

    void Start()
    {
        // 检查目标是否已赋值
        if (targetObserver != null)
        {
            // 订阅目标状态变化事件
            targetObserver.OnTargetStatusChanged += OnTargetStatusChanged;
        }
    }

    void OnDestroy()
    {
        // 取消订阅事件，防止内存泄漏
        if (targetObserver != null)
        {
            targetObserver.OnTargetStatusChanged -= OnTargetStatusChanged;
        }
    }

    // 当目标状态发生变化时调用
    private void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus targetStatus)
    {
        // 检查目标状态是否为已跟踪
        if (targetStatus.Status == Status.TRACKED)
        {
            Debug.Log("目标已检测到");
            isTargetDetected = true;
        }
        else
        {
            Debug.Log("目标丢失");
            isTargetDetected = false;
        }
    }

    void Update()
    {
        if (isTargetDetected)
        {
            // 使用键盘控制 ARCamera 的位置
            float moveSpeed = 5f;
            float horizontal = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
            float vertical = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
            float upDown = Input.GetAxis("Jump") * moveSpeed * Time.deltaTime;

            // 控制相机的移动
            Vector3 moveDirection = new Vector3(horizontal, upDown, vertical);
            transform.Translate(moveDirection);
        }
    }
}
