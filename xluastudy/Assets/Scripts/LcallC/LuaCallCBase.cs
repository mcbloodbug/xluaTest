using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
using UnityEngine.UI;

/// <summary>
/// lua调用C的入口类，通过这个类与lua代码桥接
/// </summary>

public class LuaCallCBase : MonoBehaviour
{
    LuaEnv env=null;
    void Start()
    {
        env = new LuaEnv();
        env.AddLoader(HotFixScript.CustomMyLoader);
        env.DoString("require 'LuaCallC'");

       // GameObject obj = new GameObject();//这是C#创建对象实例的方法
        

    }
     
    void Update()
    {
        
    }
}
