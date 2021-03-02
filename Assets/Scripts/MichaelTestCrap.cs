using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security;
using UnityEngine;

public class MichaelTestCrap : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //var p = new Process();
        //p.StartInfo.FileName = "cmd.exe";
        //p.Start();
        Process p = new Process();
        //p.StartInfo.RedirectStandardOutput = true;
        p.StartInfo.UseShellExecute = false;
        p.StartInfo.FileName = ("C:/Users/Michael/Desktop/test.bat");
        p.Start();
        //UnityEngine.Debug.Log(p.StandardOutput.ReadToEnd());
        //Process.Start("C:/Users/Michael/Desktop/fight.bat", "pause");
    }

    // Update is called once per frame
    void Update()
    {
    }
}
