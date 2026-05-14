using UnityEngine;

public class arrowcat : MonoBehaviour
{
    public GameObject prehabAllow;   // 矢のプレハブ
    public float startInterval = 1.0f;   // 最初の発射間隔
    public float intervalDecrease = 0.02f; // 間隔の減る量（大きいほど速くなる）
    public float minInterval = 0.1f;      // 発射間隔の最小値

    public float startSpeed = 1.0f;   // 最初の矢スピード倍率（cspeed）
    public float speedIncrease = 0.05f; // 矢スピードの増加量

    private float timer = 0f;
    private float currentInterval;   // 現在の発射間隔
    private float currentSpeed;      // 現在の矢スピード倍率

    void Start()
    {
        currentInterval = startInterval;
        currentSpeed = startSpeed;
    }

    void Update()
    {
        timer += Time.deltaTime * 0.8f;

        if (timer >= currentInterval)
        {
            timer = 0f;

            // ランダム位置で矢を生成
            float x = Random.Range(-9.5f, 9.5f);
            GameObject obj = Instantiate(prehabAllow, new Vector3(x, 4.5f, 0), Quaternion.identity);

            // 生成した矢の速度(cspped)を設定
            arrow a = obj.GetComponent<arrow>();
            a.cspeed = currentSpeed;

            // 発射間隔を短くする（だんだん頻度アップ）
            currentInterval -= intervalDecrease;
            if (currentInterval < minInterval)
                currentInterval = minInterval;

            // 矢のスピードを上げる（どんどん速くなる）
            currentSpeed += speedIncrease;
        }
    }
}
