using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    private float hp_limit;
    GameObject hpgauge;

    // ▼ タイマー用
    private float timer = 60f;    // 60秒（1分）
    public Text timerText;        // UIにタイマーを表示したいとき（不要なら消してOK）

    void Start()
    {
        this.hpgauge = GameObject.Find("hpGauge");
        hp_limit = 10;

        // ClearSceneへ行くまで時間をカウントする
        timer = 45f;
    }

    void Update()
    {
        // ▼ タイマーのカウントダウン
        timer -= Time.deltaTime;

        // ▼ 0秒になったら ClearScene へ
        if (timer <= 0f)
        {
            SceneManager.LoadScene("ClearScene");
        }

        // ▼ （表示用）タイマーUI更新
        if (timerText != null)
        {
            timerText.text = "Time: " + Mathf.Ceil(timer).ToString();
        }
    }

    // HP減少処理
    public void DecreaseHP()
    {
        this.hpgauge.GetComponent<Image>().fillAmount -= 0.2f;
        hp_limit -= 2;

        if (hp_limit <= 0)
        {
            SceneManager.LoadScene("escapecattest");
        }
    }
}
