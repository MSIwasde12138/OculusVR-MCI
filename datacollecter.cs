using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System;
using BNG;

public class datacollecter : MonoBehaviour
{

    public String[] strs = { };

    void Update()
    {

        //Debug.Log("faq");
        float scoreNormal = GameObject.FindGameObjectWithTag("Basket1").GetComponent<WeaponCollect>().collectleftScore;
        float scoreUnnormal = GameObject.FindGameObjectWithTag("Basket2").GetComponent<SquareCollect>().collectrightScore;

        string a1 = scoreNormal.ToString();
        string a2 = scoreUnnormal.ToString();




        string[] strs = new string[] { "常用物品:," + a1, "非常用物品:," + a2 };

        WriteCsv(strs, Application.dataPath + "/task1data.csv");

    }

    public void WriteCsv(string[] strs, string path)
    {
        if (!File.Exists(path))
        {
            File.Create(path).Dispose();
        }
        //UTF-8方式保存
        using (StreamWriter stream = new StreamWriter(path, false, Encoding.UTF8))
        {
            for (int i = 0; i < strs.Length; i++)
            {
                if (strs[i] != null)
                    stream.WriteLine(strs[i]);
            }
        }
    }

}
