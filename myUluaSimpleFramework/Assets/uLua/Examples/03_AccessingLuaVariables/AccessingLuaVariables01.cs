using UnityEngine;
using System.Collections;
using LuaInterface;

/// <summary>
/// lua中变量的访问LuaState
/// </summary>
public class AccessingLuaVariables01 : MonoBehaviour {

    private string script = @"
            luanet.load_assembly('UnityEngine')
            GameObject = luanet.import_type('UnityEngine.GameObject')
            ParticleSystem = luanet.import_type('UnityEngine.ParticleSystem') 
            particles = {}
            --local Objs2Spawn = 3
            for i = 1, Objs2Spawn, 1 do
                local newGameObj = GameObject('NewObj' .. tostring(i))
                local ps = newGameObj:AddComponent(luanet.ctype(ParticleSystem))
                ps:Stop()

                table.insert(particles, ps)
            end

            var2read = 42
        ";

	void Start () {
        LuaState l = new LuaState();
        // Assign to global scope variables as if they're keys in a dictionary (they are really)
        // 对lua中全局变量Objs2Spawn 赋值，这里可以直接外部赋值同时定义这个变量
        l["Objs2Spawn"] = 5;
        l.DoString(script);

        // Read from the global scope the same way
        // 读取lua中的全局变量到C#
        print("读取LUA中的值: " + l["var2read"].ToString());

        // Get the lua table as LuaTable object
        // 获取lua中的table，将lua表作为可LuaTable对象
        LuaTable particles = (LuaTable)l["particles"];

        // 表中值的遍历，设置粒子特效为播放
        foreach ( ParticleSystem ps in particles.Values )
        {
            ps.Play();
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
