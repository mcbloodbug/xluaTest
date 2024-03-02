using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XLua;

[Hotfix]
public class ButtonControl : MonoBehaviour
{
    public HotFixScript scc;
    public Button button1;
    public Button button2;
    public Button button3;
    public Cube cube1;
    private Rigidbody a; 
    private void Start()
    {
        a = cube1.gameObject.GetComponent<Rigidbody>(); 
        
        button1.onClick.AddListener(OnButtonClick1);
        button2.onClick.AddListener(OnButtonClick2);
        button3.onClick.AddListener(OnButtonClick3);
    }
    [LuaCallCSharp]
    private void OnButtonClick1()
    {  
          a .AddForce(Vector3.up * 500);
    }
    [LuaCallCSharp]
    private void OnButtonClick2()
    {
        Debug.Log("C#°´Å¥2");
    }
    [LuaCallCSharp]
    private void OnButtonClick3()
    {
        Debug.Log("C#°´Å¥3");
    }
}
