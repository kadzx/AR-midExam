using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextComeUp : MonoBehaviour
{
    public GameObject text;
    private bool isTure;
    // Start is called before the first frame update
    void Start()
    {
        isTure = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TextCome() {

        text.SetActive(isTure);
        isTure = !isTure;
    
    }
}
