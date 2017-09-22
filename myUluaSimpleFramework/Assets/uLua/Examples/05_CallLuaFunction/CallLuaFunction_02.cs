using UnityEngine;
using System.Collections;
using LuaInterface;
using System;

public class CallLuaFunction_02 : MonoBehaviour {

    private string script = @"
            function luaFunc(num)                
                return num
            end
            function LuaTest(num)
                return num*num
            end
        ";

    LuaFunction func = null;

	// Use this for initialization
	void Start () {
        LuaScriptMgr mgr = new LuaScriptMgr();
        
        mgr.DoString(script);

        // Get the function object
        // 包装后实现的，拿到LUA中方法
        func = mgr.GetLuaFunction("LuaTest");

        //有 gc alloc
        object[] r = func.Call(666);        
        print(r[0]);

        // 无 gc alloc
        int num = CallFunc();
        print(num);
	}

    void OnDestroy()
    {
        if (func != null)
        {
            func.Release(); //释放
        }
    }

    int CallFunc()
    {
        int top = func.BeginPCall();
        IntPtr L = func.GetLuaState();
        LuaScriptMgr.Push(L, 123456);
        int num = (int)LuaScriptMgr.GetNumber(L, -1);
        func.EndPCall(top);
        return num;
    }
	
	// Update is called once per frame
	void Update () 
    {
        //func.Call(123456);
        //CallFunc();
	}
}
