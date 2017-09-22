using UnityEngine;
using System.Collections;
using LuaInterface;

/// <summary>
/// lua中协程
/// </summary>
public class LuaCoroutines : MonoBehaviour 
{
    private string script = @"                                   
            function fib(n)
                local a, b = 0, 1
                while n > 0 do
                    a, b = b, a + b
                    n = n - 1
                end

                return a
            end

            function CoFunc()
                print('Coroutine started')
                local i = 0
                for i = 0, 10, 1 do
                    print(fib(i))                    
                    coroutine.wait(1) -- 暂停，填写秒数
                end
                print('Coroutine ended')
            end

            function myFunc() -- 协程开始
                coroutine.start(CoFunc)
            end
        ";

    private LuaScriptMgr lua = null;

	void Awake () 
    {
        lua  = new LuaScriptMgr();
        lua.Start();//启动
        lua.DoString(script);
        LuaFunction f = lua.GetLuaFunction("myFunc");
        f.Call();//执行
        f.Release();//释放
	}
	
	// Update is called once per frame
	void Update () 
    {        
        lua.Update();//模拟多线程，时间的增加等
	}

    void LateUpdate()
    {
        lua.LateUpate();//模拟多线程，时间的增加等
    }

    void FixedUpdate()
    {
        lua.FixedUpdate();//模拟多线程，时间的增加等
    }
}
