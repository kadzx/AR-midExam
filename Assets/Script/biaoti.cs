using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class biaoti : MonoBehaviour
{
    // Start is called before the first frame update

    
    public void onloginbuttonclick(int i)
    {
        SceneManager.LoadScene(i);
    }
}

