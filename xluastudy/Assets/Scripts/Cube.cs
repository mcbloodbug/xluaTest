using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

[Hotfix]
public class Cube : MonoBehaviour
{
    private Rigidbody cubeRigidbody;

    private void Start()
    {
        // 获取Cube对象的刚体组件
        cubeRigidbody = GetComponent<Rigidbody>();

        if (cubeRigidbody == null)
        {
            Debug.LogError("Cube对象上没有挂载刚体组件！");
        }
    }

    [LuaCallCSharp]
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            cubeRigidbody.AddForce(Vector3.up * 500);
        }
    }
}
