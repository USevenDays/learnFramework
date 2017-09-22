using UnityEngine;
using System.Collections;
using LuaInterface;

public class CreateGameObject01 : MonoBehaviour {

    private string script = @"
            luanet.load_assembly('UnityEngine')
            GameObject = luanet.import_type('UnityEngine.GameObject')        
	        ParticleSystem = luanet.import_type('UnityEngine.ParticleSystem') 
            SphereCollider = luanet.import_type('UnityEngine.SphereCollider')
            local newGameObj = GameObject('NewObj')
            -- newGameObj:AddComponent(luanet.ctype(ParticleSystem))
            newGameObj:AddComponent(luanet.ctype(SphereCollider))
        ";

	//反射调用
	void Start () {
        //GameObject.CreatePrimitive(PrimitiveType.Quad);
        LuaState lua = new LuaState();
        lua.DoString(script);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
