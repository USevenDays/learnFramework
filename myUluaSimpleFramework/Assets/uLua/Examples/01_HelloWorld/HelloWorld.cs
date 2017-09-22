using UnityEngine;
using System.Collections;
using LuaInterface;

/// <summary>
/// c#执行lua代码
/// </summary>
public class HelloWorld : MonoBehaviour {

	// Use this for initialization
	void Start () {
        string sr = @"abcdefghijklm\nopqrstuvwxyz";//@使得转义字符\失效
        //print(sr);
        LuaState l = new LuaState(); //lua的解析器
        string str = "print('hello world 世界')";
        l.DoString(str);//在C#执行LUA代码
        LuaState lua = new LuaState();
        string lusstr = "for i = 1 , 10 do  if i == 6 then print('true') else print('false') end end";
        lua.DoString(lusstr);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
