using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text textArea;
    private bool stopTimer;


    // Start is called before the first frame update
    void Start()
    {
        stopTimer = false;

    }

    // Update is called once per frame
    void Update()
    {
        float time = 600 - Time.time;
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time - minutes * 60);
        string textTime = string.Format("{0:00}:{1:00}", minutes, seconds);
        if(stopTimer == false)
        {
            textArea.text = textTime;
        }

        if(time <= 0 )
        {
            stopTimer = true;
            Application.LoadLevel("GameOver");     
        }
        

    }
}
