using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class MichaelTestCrap : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //var p = new Process();
        //p.StartInfo.FileName = "cmd.exe";
        //p.Start();
        Process.Start("cmd.exe", "pause");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
