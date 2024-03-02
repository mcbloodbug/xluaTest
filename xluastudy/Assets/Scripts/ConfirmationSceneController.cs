using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ConfirmationSceneController : MonoBehaviour
{ 
    public Button button1;
    public Button button2;

    private void Start()
    {

        button1.onClick.AddListener(LoadScene1);
        button2.onClick.AddListener(LoadScene2);
    }
    public void LoadScene1()
    {
        SceneManager.LoadScene("Load");

        Debug.Log("选择更新");
    }

    public void LoadScene2()
    {
        SceneManager.LoadScene("game");
        Debug.Log("直接游戏");
    }
}