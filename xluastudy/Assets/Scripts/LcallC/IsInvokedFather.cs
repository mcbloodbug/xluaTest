using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
using UnityEngine.UI;

/// <summary>
/// ����ĸ���
/// </summary>

public class IsInvokedFather : MonoBehaviour
{
    LuaEnv env=null;
    void Start()
    {
        env = new LuaEnv();
        env.AddLoader(HotFixScript.CustomMyLoader);
        env.DoString("require 'LuaCallC'");

       // GameObject obj = new GameObject();//����C#��������ʵ���ķ���
        

    }
     
    void Update()
    {
        
    }
}
