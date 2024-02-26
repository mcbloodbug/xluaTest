using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
using static UnityEditor.Progress;

public class CallByRef : MonoBehaviour
{
    LuaEnv env = null; 

    void Start()
    {
        env = new LuaEnv(); 
        env.AddLoader(HotFixScript.CustomMyLoader);
        env.DoString("require 'CSLua2'");
        
        LuaTable tab1 = env.Global.Get<LuaTable>("ganlan");
        Debug.Log(tab1.Get<string>("s1"));

        LuaTable tab2 = env.Global.Get<LuaTable>("gameUser");
        Debug.Log(tab2.Get<string>("name"));

        LuaFunction funS = tab2. Get<LuaFunction>("Speak");
        funS.Call();

        LuaFunction funC = tab2.Get<LuaFunction>("culate");
        object[] objArray = funC.Call(tab2,5, 2);
        Debug.Log(objArray[0]);
    }

    private void OnDestroy()
    {
        env.Dispose();
    }
}