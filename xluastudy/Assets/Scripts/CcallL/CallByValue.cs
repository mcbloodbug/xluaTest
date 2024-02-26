using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class CallByValue : MonoBehaviour
{
    LuaEnv env = null;
    void Start()
    {
        env = new LuaEnv();

        env.AddLoader(HotFixScript.CustomMyLoader);
        env.DoString("require 'CSLua2'");
        Dictionary<string, object> ga = env.Global.Get<Dictionary<string, object>>("ganlan");
        Dictionary<string, object> ga2 = env.Global.Get<Dictionary<string, object>>("gameUser");


        //foreach(var item in ga.Keys)
        //{ 
        //    Debug.Log("���key��"+item+"��ֵ�ǣ�"+ ga[item]);
        //    Debug.Log("............");    
        //} 

        foreach (var item in ga2.Keys)
        {
            Debug.Log("���key��" + item + "��ֵ�ǣ�" + ga2[item]);
            Debug.Log("............");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnDestroy()
    {//ʩ��luaEnv
        env.Dispose();
    }


}
