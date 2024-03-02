using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class AndroidLoad : MonoBehaviour
{
    /*
    void Start()
    {
        StartCoroutine(Load());
    }

    IEnumerator Load()
    {
        string persistentDataPath = Application.persistentDataPath;
        string luaFolderPath = Path.Combine(persistentDataPath, "Lua");
        Directory.CreateDirectory(luaFolderPath); // 创建 Lua 文件夹

        string testLuaPath = Path.Combine(luaFolderPath, "Test.lua.txt");
        string disposeLuaPath = Path.Combine(luaFolderPath, "LuaDispose.lua.txt");

        UnityWebRequest request = UnityWebRequest.Get("http://localhost:80/Test.lua.txt");
        yield return request.SendWebRequest();
        string str = request.downloadHandler.text;
        File.WriteAllText(testLuaPath, str);

        UnityWebRequest request1 = UnityWebRequest.Get("http://localhost:80/LuaDispose.lua.txt");
        yield return request1.SendWebRequest();
        string str1 = request1.downloadHandler.text;
        File.WriteAllText(disposeLuaPath, str1);

        SceneManager.LoadScene("game");
    }
     */
}
