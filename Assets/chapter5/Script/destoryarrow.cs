using UnityEngine;

public class destoryarrow : MonoBehaviour
{
    GameObject player;

    // プレイヤー当たり判定（長方形）
    public float halfWidth = 0.7f;   // 左右
    public float halfHeight = 1.0f;  // 上下

    void Start()
    {
        player = GameObject.Find("player_0");
    }

    void Update()
    {
        Vector2 arrowPos = transform.position;
        Vector2 playerPos = player.transform.position;

        // 長方形範囲に入ったか？
        if (Mathf.Abs(arrowPos.x - playerPos.x) < halfWidth &&
            Mathf.Abs(arrowPos.y - playerPos.y) < halfHeight)
        {
            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().DecreaseHP();

            Destroy(gameObject);
        }
    }
}
