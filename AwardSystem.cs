using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;
using UnityEngine.UI;

public class AwardSystem : MonoBehaviour
{

    public TaskTip taskTip;
    public TimeTip timeTip;

    public GameObject patri1;
    public GameObject patri2;
    public GameObject patri3;

    // Update is called once per frame
    void Update()
    {
        float totalScore = GameObject.FindGameObjectWithTag("Basket1").GetComponent<WeaponCollect>().collectleftScore + GameObject.FindGameObjectWithTag("Basket2").GetComponent<SquareCollect>().collectrightScore;
        if (totalScore == 2)
        {
            taskTip.OnFirstAward();
            patri1.SetActive(true);
        }
        if (totalScore == 4)
        {
            taskTip.OnSecondAward();
            patri1.SetActive(true);
        }
        if (totalScore == 6)
        {
            taskTip.OnThirdAward();
            patri1.SetActive(false);
            patri1.SetActive(true);
            patri2.SetActive(true);
        }
        if (totalScore == 10)
        {
            taskTip.OnAccuracyAward();
            patri1.SetActive(false);
            patri2.SetActive(false);
            patri1.SetActive(true);
            patri2.SetActive(true);
            patri3.SetActive(true);
            if (timeTip.totalgameTime > 180)
            {
                taskTip.OnAllAward();
            }
            else
            {
                taskTip.OnAlmostAllAward();
            }
        }
        return;
    }
}
