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
            .ClientID("8l5sazu7dtqvqkvsqz") // 必须，开发者中心对应 Client ID
            .ClientToken("zLCVz7lHHDDqkDciWwcmbXeYNMSwZzWHJ8LvivAA") // 必须，开发者中心对应 Client Token
            .ServerURL("https://8l5sazu7.cloud.tds1.tapapis.cn") // 必须，开发者中心 > 你的游戏 > 游戏服务 > 基本信息 > 域名配置 > API
            .RegionType(RegionType.CN) // 非必须，CN 表示中国大陆，IO 表示其他国家或地区
            .ConfigBuilder();
        TapBootstrap.Init(config);
    }

    public async Task GetAsync()
    {
        try
        {
            var accesstoken = await TapLogin.GetAccessToken();
            Debug.Log("已登录");
            // 直接进入游戏
        }
        catch (Exception e)
        {
            Debug.Log("当前未登录");
            // 开始登录
        }

        // 获取用户信息
        await TapLogin.GetProfile();

        // 获取实时更新的用户信息
        await TapLogin.FetchProfile();
    }

    public async Task LoginAsync()
    {
        var currentUser = await TDSUser.GetCurrent();
        if (null == currentUser)
        {
            Debug.Log("当前未登录");
            try
            {
                // 在 iOS、Android 系统下会唤起 TapTap 客户端或以 WebView 方式进行登录
                // 在 Windows、macOS 系统下显示二维码（默认）和跳转链接（需配置）
                var tdsUser = await TDSUser.LoginWithTapTap();
                Debug.Log($"login success:{tdsUser}");
                // 获取 TDSUser 属性
                var objectId = tdsUser.ObjectId;     // 用户唯一标识
                var nickname = tdsUser["nickname"];  // 昵称
                var avatar = tdsUser["avatar"];      // 头像
                t1.text = $"昵称:{nickname}";
                Debug.Log(nickname + "11111111111111111111");
            }
            catch (Exception e)
            {
                if (e is TapException tapError)  // using TapTap.Common
                {
                    Debug.Log($"encounter exception:{tapError.code} message:{tapError.message}");
                    if (tapError.code == (int)TapErrorCode.ERROR_CODE_BIND_CANCEL) // 取消登录
                    {
                        Debug.Log("登录取消");
                    }
                }
            }
        }
        else
        {
            Debug.Log("已登录");
            // 进入游戏

            // 获取 TapTap Profile  可以获得当前用户的一些基本信息，例如名称、头像。
            var profile = await TapLogin.FetchProfile();
            Debug.Log($"profile: {profile.ToJson()}");
        }

        t2.text = "已经登陆";


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
        t1.text = "用户名：";
        t2.text = "是否登陆";
    }
    public async void OnClick3()
    {
        await GetAsync();
    }

}
