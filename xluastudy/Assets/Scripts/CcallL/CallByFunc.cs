using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
public class CallByFunc : MonoBehaviour
{
    LuaEnv env = null;
    void Start()
    {
        env = new LuaEnv();
        env.AddLoader(HotFixScript.CustomMyLoader);
        env.DoString("require 'CSLua2'");
        //通过LuaFunction来映射Lua中的函数
        LuaFunction luaFun1 = env.Global.Get<LuaFunction>("MyFunc1"); 
        LuaFunction luaFun2 = env.Global.Get<LuaFunction>("MyFunc2"); 
        LuaFunction luaFun3 = env.Global.Get<LuaFunction>("MyFunc3");
        //调用具有多个返回值的函数
        LuaFunction luaFun4 = env.Global.Get<LuaFunction>("MyFunc4");

        luaFun1.Call();
        luaFun2 .Call(10,20);
        object[] obj1 = luaFun3 .Call(20,30);
        Debug.Log(string.Format("3的结果是={0}", obj1[0]));

        object[] obj2 = luaFun4 .Call(30,40); 
        Debug.Log(string.Format("测试多个返回值res1={0},res2={1},res3={2}", obj2[0], obj2[1], obj2[2]));



    }
     
    void Update()
    {
        
    }
}
