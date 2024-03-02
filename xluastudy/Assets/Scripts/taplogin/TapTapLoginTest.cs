using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TapTap.Bootstrap;
using TapTap.Common;
using TapTap.Login;
using UnityEngine;
using UnityEngine.UI;

public class TapTapLoginTest : MonoBehaviour
{
    public Button btn1;
    public Button btn2;
    
    public Text t1;
    public Text t2;

    void Start()
    {

        btn1.onClick.AddListener(OnClick1);
        btn2.onClick.AddListener(OnClick2);
         

        var config = new TapConfig.Builder()
            .ClientID("8l5sazu7dtqvqkvsqz") // ���룬���������Ķ�Ӧ Client ID
            .ClientToken("zLCVz7lHHDDqkDciWwcmbXeYNMSwZzWHJ8LvivAA") // ���룬���������Ķ�Ӧ Client Token
            .ServerURL("https://8l5sazu7.cloud.tds1.tapapis.cn") // ���룬���������� > �����Ϸ > ��Ϸ���� > ������Ϣ > �������� > API
            .RegionType(RegionType.CN) // �Ǳ��룬CN ��ʾ�й���½��IO ��ʾ�������һ����
            .ConfigBuilder();
        TapBootstrap.Init(config);
    }

    public async Task GetAsync()
    {
        try
        {
            var accesstoken = await TapLogin.GetAccessToken();
            Debug.Log("�ѵ�¼");
            // ֱ�ӽ�����Ϸ
        }
        catch (Exception e)
        {
            Debug.Log("��ǰδ��¼");
            // ��ʼ��¼
        }

        // ��ȡ�û���Ϣ
        await TapLogin.GetProfile();

        // ��ȡʵʱ���µ��û���Ϣ
        await TapLogin.FetchProfile();
    }

    public async Task LoginAsync()
    {
        var currentUser = await TDSUser.GetCurrent();
        if (null == currentUser)
        {
            Debug.Log("��ǰδ��¼");
            try
            {
                // �� iOS��Android ϵͳ�»ỽ�� TapTap �ͻ��˻��� WebView ��ʽ���е�¼
                // �� Windows��macOS ϵͳ����ʾ��ά�루Ĭ�ϣ�����ת���ӣ������ã�
                var tdsUser = await TDSUser.LoginWithTapTap();
                Debug.Log($"login success:{tdsUser}");
                // ��ȡ TDSUser ����
                var objectId = tdsUser.ObjectId;     // �û�Ψһ��ʶ
                var nickname = tdsUser["nickname"];  // �ǳ�
                var avatar = tdsUser["avatar"];      // ͷ��
                t1.text = $"�ǳ�:{nickname}";
                Debug.Log(nickname + "11111111111111111111");
            }
            catch (Exception e)
            {
                if (e is TapException tapError)  // using TapTap.Common
                {
                    Debug.Log($"encounter exception:{tapError.code} message:{tapError.message}");
                    if (tapError.code == (int)TapErrorCode.ERROR_CODE_BIND_CANCEL) // ȡ����¼
                    {
                        Debug.Log("��¼ȡ��");
                    }
                }
            }
        }
        else
        {
            Debug.Log("�ѵ�¼");
            // ������Ϸ

            // ��ȡ TapTap Profile  ���Ի�õ�ǰ�û���һЩ������Ϣ���������ơ�ͷ��
            var profile = await TapLogin.FetchProfile();
            Debug.Log($"profile: {profile.ToJson()}");
        }

        t2.text = "�Ѿ���½";


    }
    public async Task OutAsync()
    {
        await TDSUser.Logout();
    }
     
    public void OnClick1()
    {
        LoginAsync();
    }
    public void OnClick2()
    {
        OutAsync();
        t1.text = "�û�����";
        t2.text = "�Ƿ��½";
    }
    public async void OnClick3()
    {
        await GetAsync();
    }

}
