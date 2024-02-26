using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class CallByInComp : MonoBehaviour
{
    LuaEnv env = null;
    void Start()
    {
        env = new LuaEnv();

        env.AddLoader(HotFixScript.CustomMyLoader);
        env.DoString("require 'CSLua2'");

        IGameUser gamelei = env.Global.Get<IGameUser>("gameUser");
        Debug.Log(gamelei.name);
        Debug.Log(gamelei.age);
        Debug.Log(gamelei.ID);

        gamelei.name = "tuzi";
        gamelei.Speak();
        gamelei.walking();
        int temp = gamelei.culate(30,21);
        Debug.Log(temp);
        Debug.Log(gamelei.name);
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
    public interface IGameUser
    {
        string name { get; set; }
        int age { get; set; }
        string ID { get; set; }

        void Speak();
        void walking();
        int culate(int num1,int num2);

    }
}
