using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BNG;

public class TaskTip : MonoBehaviour
{

    public Text taskText1;
    public Text taskText2;
    public Text taskText3;
    public Text taskText4;
    public Text taskText5;

    public void OnFirstAward()
    {
        taskText1.text = "[��]Sort a group of item";
    }

    public void OnSecondAward()
    {
        taskText2.text = "[��]Sort two groups of items";
    }

    public void OnThirdAward()
    {
        taskText3.text = "[��]Sort three groups of items";
    }

    public void OnAllAward()
    {
        taskText5.text = "[��]Finish sorting in two mins";
    }


    public void OnAlmostAllAward()
    {
        taskText5.text = "[��]Finish sorting in two mins";
    }

    public void OnAccuracyAward()
    {
        taskText4.text = "[��]Not even an error !";
    }

}
