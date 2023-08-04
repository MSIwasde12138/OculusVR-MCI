using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System;
using BNG;

public class UIData : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        float spatialScore = GameObject.FindGameObjectWithTag("data").GetComponent<UI1>().ui1Score; string ss = spatialScore.ToString();
        float logicScore = GameObject.FindGameObjectWithTag("data2").GetComponent<UI2>().ui2Score; string ls = logicScore.ToString();
        //string uianswer = Path.Combine(ui1.ToString(), ui2.ToString());
        string[] strs = new string[] { "线索寻路收集：," + ss, "推理：," + ls };
        WriteCsv(strs, Application.dataPath + "/task4.csv");
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
