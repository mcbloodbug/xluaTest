using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using XLua;

public class HotFixScript : MonoBehaviour
{
    private LuaEnv luaEnv1;
    private Dictionary<string, GameObject> prefabs =new Dictionary<string, GameObject>();
     
    private void Awake()
    {
        luaEnv1 = new LuaEnv();
        luaEnv1.AddLoader(MyLoader);
        luaEnv1.DoString("require 'Test'");

    }
    private byte[] MyLoader(ref string filePath)
    {
        string absPath = @"D:\UNITY WORK\xluaTest\xluastudy\Assets\Lua\" + filePath+ ".lua.txt";
        return System.Text.Encoding.UTF8.GetBytes(File.ReadAllText( absPath));
    
    }
    public  static byte[] CustomMyLoader(ref string fileName)
    {
        byte[] byArrayReture = null; //返回数据
        //定义lua路径
        string luaPath = Application.dataPath + "/Scripts/LuaScripts/" + fileName + ".lua";
        //读取lua路径中的文件
        string strLuaContent =File.ReadAllText(luaPath);
        //数据转化
        byArrayReture =System.Text.Encoding.UTF8.GetBytes(strLuaContent);
        return byArrayReture;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDisable()
    {
        luaEnv1.DoString("require 'LuaDispose'");
    }
    private void OnDestroy()
    {
        luaEnv1.Dispose();
    }

    [LuaCallCSharp]
    public void LoadResource(string resName,string filePath)
    {
        StartCoroutine( Load(resName,filePath));
    }

    IEnumerator Load(string  resName,string filePath)
    {
        UnityWebRequest request =UnityWebRequestAssetBundle.GetAssetBundle(@"http://localhost:80/AssetBundles/" + filePath);
        yield return request.SendWebRequest();
        AssetBundle ab =(request.downloadHandler as DownloadHandlerAssetBundle).assetBundle;

        GameObject go = ab.LoadAsset<GameObject>(resName);
        prefabs.Add(resName, go);
    }
    [LuaCallCSharp]
    public GameObject GetPrefab(string resName)
    {
        return prefabs[resName]; 
    }
}
