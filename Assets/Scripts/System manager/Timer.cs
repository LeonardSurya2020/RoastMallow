using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI stopwatchText;
    public TextMeshProUGUI CompletestopwatchText;

    public TextMeshProUGUI fastestTime;

    public float val;

    public float fastTime = 200f;

    public bool start;
    // Start is called before the first frame update
    void Start()
    {
        val = 0;
        start = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(start == true)
        {
            val += Time.deltaTime;
        }
        stopwatchText.text = val.ToString("0.00");
    }

    public void stopTime()
    {
        start = false;
    }

    public void continueTime()
    {
        start = true;
    }

    public void completeTime()
    {
        start = false;
        CompletestopwatchText.text = stopwatchText.text;
    }

    //public void setFastestTime()
    //{
    //    start = false;
    //    if(val < fastTime)
    //    {
    //        fastTime = val;
    //        fastestTime.text = val.ToString();
    //        PlayerPrefs.SetString("fastestTime", fastestTime.text);
    //    }
    //    else
    //    {
    //        fastestTime.text = val.ToString();
    //        PlayerPrefs.SetString("fastestTime", fastestTime.text);
    //    }
    //}


}
