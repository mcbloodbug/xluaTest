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
        // ��ȡCube����ĸ������
        cubeRigidbody = GetComponent<Rigidbody>();

        if (cubeRigidbody == null)
        {
            Debug.LogError("Cube������û�й��ظ��������");
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
