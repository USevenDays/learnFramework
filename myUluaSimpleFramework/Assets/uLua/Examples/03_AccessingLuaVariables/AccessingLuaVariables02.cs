using UnityEngine;
using System.Collections;
using LuaInterface;


/// <summary>
/// lua中变量的访问LuaSpriteMgr
/// </summary>
public class AccessingLuaVariables02 : MonoBehaviour 
{
    //cstolua要求必须要先定义变量才能使用
    private string var = @"Objs2Spawn = 0";
    private string script = @"            
            particles = {}
            ParticleSystem = UnityEngine.ParticleSystem
            for i = 1, Objs2Spawn, 1 do
                local newGameObj = GameObject('NewObj' .. tostring(i))
                local ps = newGameObj:AddComponent(ParticleSystem.GetClassType())
                ps:Stop()

                table.insert(particles, ps)
            end

            var2read = 42
        ";

	// Use this for initialization
	void Start () {        
        LuaScriptMgr mgr = new LuaScriptMgr();
        mgr.Start();//
        // Assign to global scope variables as if they're keys in a dictionary (they are really)
        LuaState l = mgr.lua;
        l.DoString(var);//先定义
        l["Objs2Spawn"] = 6;//后改值
        l.DoString(script);//执行后面的方法

        // Read from the global scope the same way
        print("Read from lua: " + l["var2read"].ToString());

        // Get the lua table as LuaTable object
        LuaTable particles = (LuaTable)l["particles"];

        // Typical foreach over values in table
        foreach( ParticleSystem ps in particles.Values )
        {
            ps.Play();
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
