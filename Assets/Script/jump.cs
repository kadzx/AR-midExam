using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class jump : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void sandieji()
    {
        SceneManager.LoadScene(3);
    }
    public void zhuluoji()
    {
        SceneManager.LoadScene(4);
    }
    public void baieji()
    {
        SceneManager.LoadScene(5);
    }
}