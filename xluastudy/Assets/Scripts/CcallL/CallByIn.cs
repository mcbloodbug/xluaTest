using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class CallByIn : MonoBehaviour
{
    LuaEnv env = null;
    void Start()
    {
        env = new LuaEnv();

        env.AddLoader(HotFixScript.CustomMyLoader); 
        env.DoString("require 'CSLua2'"); 

        IGame gamelei = env.Global.Get<IGame>("ganlan");
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
    {//Ê©·ÅluaEnv
        env.Dispose();
    }
    [CSharpCallLua]
    public interface IGame { 
        string s1 { get; set; }
        string s2 { get; set; }
        string s3 { get; set; }
        string s4 { get; set; }

    }

}
