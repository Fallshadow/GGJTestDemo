using System.Text.RegularExpressions;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using B83.Win32;

public struct Context
{
    public string name;
    public string type;
    public override string ToString()
    {
        return name + "  " + type;
    }
}



public class FileDragAndDrop : MonoBehaviour
{
    //List<string> log = new List<string>();
    void OnEnable ()
    {
        // must be installed on the main thread to get the right thread id.
        UnityDragAndDropHook.InstallHook();
        UnityDragAndDropHook.OnDroppedFiles += OnFiles;
    }
    void OnDisable()
    {
        UnityDragAndDropHook.UninstallHook();
    }

    public Context getContent(string input)
    {
        Context c= new Context();
        string pattern = @"\w+\.";
        c.name = Regex.Match(input, pattern).Value;

        string pattern1 = @"\w+$";
        c.type = Regex.Match(input, pattern1).Value;
        return c;
    }
    void OnFiles(List<string> aFiles, POINT aPos)
    {
        List<Context> context = new List<Context>();

        foreach (string s in aFiles)
        {
            context.Add(getContent(s));
        }

        FileNameMgr.instance.CheckFileNames(context,aPos.x,aPos.y);
        // do something with the dropped file names. aPos will contain the
        // mouse position within the window where the files has been dropped.
        // string str = "Dropped " + aFiles.Count + " files at: " + aPos + "\n\t" +
        //     aFiles.Aggregate((a, b) => a + "\n\t" + b);
        // Debug.Log(str);
        // log.Add(str);
    }

    // private void OnGUI()
    // {
    //     if (GUILayout.Button("clear log"))
    //         log.Clear();
    //     foreach (var s in log)
    //         GUILayout.Label(s);
    // }
}
