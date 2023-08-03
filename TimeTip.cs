using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BNG;

public class TimeTip : MonoBehaviour
{

    public int totalgameTime;
    public Text timeText;
    private int minute;
    private int second;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(startTime());
    }

    public IEnumerator startTime()
    {
        WaitForSeconds waitTime = new WaitForSeconds(1);
        while (totalgameTime >= 0)
        {
            yield return waitTime;
            totalgameTime--;
            timeText.text = " £”‡ ±º‰£∫" + totalgameTime;

            if (totalgameTime <= 0)
            {
                Debug.Log("—µ¡∑Ω· ¯");
            }

            minute = totalgameTime / 60;
            second = totalgameTime % 60;
            string length = minute.ToString();
            if (second >= 10)
            {
                timeText.text = "0" + minute + ":" + second;
            }
            else
                timeText.text = "0" + minute + ":0" + second;
        }
    }

}
