using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class arrow : MonoBehaviour
{
    public float speed = 2f;
    public float limy = -4f;
    public float cspeed;

    void Update()
    {
        Vector3 pos = transform.position;

        // 移動
        pos.y += cspeed * speed * Time.deltaTime;

        // ← これが絶対必要
        transform.position = pos;

        if (transform.position.y < limy)
        {
            // 画面外に出たら削除
            Destroy(gameObject);
        }
    }
}
