using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileNameMgr : SingletonMonoBehaviorNoDestroy<FileNameMgr>
{
    public List<Context> fileNames = new List<Context>();
    public Movement movement = null;
    public string s = null;

    public void CheckFileNames(List<Context> names,int x,int y)
    {
        fileNames.Clear();
        foreach (var item in names)
        {
            s = "null";
            fileNames.Add(item);
            switch (item.type)
            {
                case "txt":
                s = "text";
                    switch (item.name)
                    {
                        case "move.":
                            movement.canMoveSK = true;
                            s += "move.";
                            break;
                        case "jump.":
                            movement.wallJumpedSK = true;
                            s += "jump.";
                            break;
                        default:
                        s = item.name;
                            break;
                    }
                    break;
                default:
                    break;
            }
        }
    }
    private void OnGUI()
    {
        GUILayout.Label(movement.canMoveSK.ToString());
        GUILayout.Label(s);
    }
}
