using UnityEngine;
using System.Collections;
using LuaInterface;

/// <summary>
/// 调用LUA中方法
/// </summary>
public class CallLuaFunction_01 : MonoBehaviour {

    private string script = @"
            function luaFunc(message)
                print(message)
                return 42
            end
        ";

	void Start () {
        LuaState l = new LuaState();

        // First run the script so the function is created
        // 首先运行脚本，以便创建函数
        l.DoString(script);

        // Get the function object
        // 得到函数对象
        LuaFunction f = l.GetFunction("luaFunc");

        // Call it, takes a variable number of object parameters and attempts to interpet them appropriately
        // 调用它，获取可变数量的对象参数并尝试适当地插入它们
        object[] r = f.Call("I called a lua function!");

        // Lua functions can have variable returns, so we again store those as a C# object array, and in this case print the first one
        // Lua函数可以有变量返回，因此我们再次将它们存储为c#对象数组，在这种情况下打印第一个得到的返回值
        print(r[0]);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
