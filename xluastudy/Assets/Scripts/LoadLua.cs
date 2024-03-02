using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class LoadLua : MonoBehaviour
{
    //public  bool isUpdateConfirmed = false;
    void Start()
    { 
        StartCoroutine(Load()); 
    }


    IEnumerator Load()
    {

        UnityWebRequest request = UnityWebRequest.Get(@"http://localhost:80/Test.lua.txt");
        yield return request.SendWebRequest();
        string str = request.downloadHandler.text;
        File.WriteAllText(@"D:\UNITY WORK\xluaTest\xluastudy\Assets\Lua\Test.lua.txt", str);

        UnityWebRequest request1 = UnityWebRequest.Get(@"http://localhost:80/LuaDispose.lua.txt");
        yield return request1.SendWebRequest();
        string str1 = request1.downloadHandler.text;
        File.WriteAllText(@"D:\UNITY WORK\xluaTest\xluastudy\Assets\Lua\LuaDispose.lua.txt", str1);

        SceneManager.LoadScene("game");

    }
    void Update()
    {
        
    }
}
