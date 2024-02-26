using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

/// <summary>
/// 官方推荐，用委托方式获取
/// </summary>

[CSharpCallLua]
public delegate void delAddingOut3(int num1,int num2,out int res1, out int res2, out int res3);

[CSharpCallLua]
public delegate void delAddingRef4(ref int num1,ref int num2, out int res1);


public class CallByDel : MonoBehaviour
{
    LuaEnv env = null;
    [CSharpCallLua]
    public delegate void delAdding(int num1,int num2);
    [CSharpCallLua]
    public delegate int delAdding2(int num1, int num2);
    Action act1 = null;
    delAdding act2= null;
    delAdding2 act3 = null;

    delAddingOut3 actout = null;
    delAddingRef4 actref = null;

    void Start()
    {
        env = new LuaEnv();
        env.AddLoader(HotFixScript.CustomMyLoader);
        env.DoString("require 'CSLua2'");
        //通过action映射
        act1 = env.Global.Get<Action>("MyFunc1");
       
        act2 = env.Global.Get< delAdding>("MyFunc2");
        act3 = env.Global.Get<delAdding2>("MyFunc3");

        act1.Invoke();
        act2(10, 20);
       int result = act3(10, 21);
        Debug.Log(result);

        int outres1 = 10;
        int outres2 = 20;
        int outres3 = 30;
        Debug.Log(string.Format("res1={0},res2={1},res3={2} ", outres1, outres2, outres3));

        //通过out关键字映射
        actout = env.Global.Get<delAddingOut3>("MyFunc4");
        actout(100, 200, out int outres4, out outres2, out outres3);
        //Debug.Log(string.Format("res1={0},res2={1},res3={2} ", outres4, outres2, outres3 ));
        //Debug.Log(outres1);

        int outref1 = 10;
        int outref2 = 20;
        int resultref = 0;
        //通过ref关键字映射
        actref = env.Global.Get<delAddingRef4>("MyFunc4");
        actref(ref outref1, ref outref2,   out resultref);
        Debug.Log(string.Format("ref1={0},ref2={1},ref3={2} ", outref1, outref2, resultref));
         
    }

    private void OnDestroy()
    {
        act3 = null; act2 = null; act1 = null;actout = null;actref = null;
        env.Dispose();

    }
}