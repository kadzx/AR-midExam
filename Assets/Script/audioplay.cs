using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource; // ��Ҫ��AudioSource�ϵ��˱���
    public Button toggleButton;      // ��Ҫ��Button�ϵ��˱���

    void Start()
    {
        // Ϊ��ť��ӵ���¼�����
        toggleButton.onClick.AddListener(ToggleAudio);
    }

    void ToggleAudio()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop(); // �����Ƶ���ڲ��ţ�����ͣ
        }
        else
        {
            audioSource.Play(); // �����Ƶδ���ţ���ʼ����
        }
    }
}
