using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using XLua;

/// <summary>
/// 调用lua全局变量
/// </summary>
public class CallByGlobal : MonoBehaviour
{
    LuaEnv env = null;
    void Start()
    {
        env = new LuaEnv();

        env.AddLoader(HotFixScript.CustomMyLoader);
        env.DoString("require 'FileText'");
        env.DoString("require 'CSLua'");
        env.DoString("require 'CSLua2'");
        string a = env.Global.Get<string>("str");
        int n = env.Global.Get<int>("num");
        Debug.Log(a + n);

        GameLanguage gamelei = env.Global.Get<GameLanguage>("ganlan");
        Debug.Log(gamelei.s1);
        Debug.Log(gamelei.s2);
        Debug.Log(gamelei.s3);
        Debug.Log(gamelei.s4);

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnDestroy()
    {//施放luaEnv
        env.Dispose();
    }
    public class GameLanguage{
        public string s1;
        public string s2;
        public string s3;
        public string s4; 
    }

}
