using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
using UnityEngine.UI;

/// <summary>
/// 定义的父类
/// </summary>

public class IsInvokedFather : MonoBehaviour
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
