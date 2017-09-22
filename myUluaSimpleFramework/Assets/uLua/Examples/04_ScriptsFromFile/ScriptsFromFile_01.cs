using UnityEngine;
using System.Collections;
using LuaInterface;

/// <summary>
/// 在c#执行lua脚本  *.text
/// </summary>
public class ScriptsFromFile_01 : MonoBehaviour
{

    public TextAsset scriptFile;

    // Use this for initialization
    void Start()
    {
        LuaState l = new LuaState();
        l.DoString(scriptFile.text);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
