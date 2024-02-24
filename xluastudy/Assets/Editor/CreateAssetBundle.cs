using UnityEditor;
using System.IO;
public class CreateAssetBundle  
{
    [MenuItem("Assets/Build AssetBundles")]
    static void BuildAssetBundles()
    {
        string dir = "AssetBundles";
        if (Directory.Exists(dir) ==false)
        {
            Directory.CreateDirectory(dir);
        }

        BuildPipeline.BuildAssetBundles(dir, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);
    }
    
}
