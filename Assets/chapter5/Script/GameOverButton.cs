using UnityEngine;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;

public class GameOverButton : MonoBehaviour
{
    private static bool jsExists = false;

#if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")] private static extern int HasWindowFunctions();
    [DllImport("__Internal")] private static extern void NextButton();
    [DllImport("__Internal")] private static extern void BackButton();
#endif

    void Start()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        // JS が存在するかチェック
        jsExists = (HasWindowFunctions() == 1);
        Debug.Log("Unity WebGL: JS functions available = " + jsExists);
#endif
    }

    public void OnNextButtonClick()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        if (jsExists)
        {
            NextButton();
            return;
        }
#endif
        SceneManager.LoadScene("catstarttest");
    }

    public void OnBackButtonClick()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        if (jsExists)
        {
            BackButton();
            return;
        }
#endif
        SceneManager.LoadScene("catstarttest");
    }
}
