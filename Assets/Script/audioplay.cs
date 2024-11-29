using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource; // 需要将AudioSource拖到此变量
    public Button toggleButton;      // 需要将Button拖到此变量

    void Start()
    {
        // 为按钮添加点击事件监听
        toggleButton.onClick.AddListener(ToggleAudio);
    }

    void ToggleAudio()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop(); // 如果音频正在播放，则暂停
        }
        else
        {
            audioSource.Play(); // 如果音频未播放，则开始播放
        }
    }
}
