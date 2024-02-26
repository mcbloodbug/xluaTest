using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XLua;

[Hotfix]
public class ButtonControl : MonoBehaviour
{
    public Button button;
    public Cube cube1;
        private Rigidbody a;
    private void Start()
    {
        a = cube1.gameObject.GetComponent<Rigidbody>(); 
        button.onClick.AddListener(OnButtonClick);
    }
    [LuaCallCSharp]
    private void OnButtonClick()
    {  
          a .AddForce(Vector3.up * 500);
    }
}
