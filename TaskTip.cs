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
        taskText1.text = "[¡Ì]Sort a group of item";
    }

    public void OnSecondAward()
    {
        taskText2.text = "[¡Ì]Sort two groups of items";
    }

    public void OnThirdAward()
    {
        taskText3.text = "[¡Ì]Sort three groups of items";
    }

    public void OnAllAward()
    {
        taskText5.text = "[¡Ì]Finish sorting in two mins";
    }


    public void OnAlmostAllAward()
    {
        taskText5.text = "[¡Á]Finish sorting in two mins";
    }

    public void OnAccuracyAward()
    {
        taskText4.text = "[¡Ì]Not even an error !";
    }

}
