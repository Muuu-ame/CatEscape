using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class Buttonslide : MonoBehaviour
{
    public float speed = 2f;
    public Button rightButton;
    public Button leftButton;

    // ★ 移動範囲
    public float minX = -3f; // 左端
    public float maxX = 3f; // 右端

    private Coroutine moveRoutine;

    // 追加：どのトリガーにどのエントリを追加したか保持する
    private readonly List<(EventTrigger trigger, EventTrigger.Entry entry)> addedEntries
        = new List<(EventTrigger, EventTrigger.Entry)>();

    void Start()
    {
        AddHold(rightButton, 1);
        AddHold(leftButton, -1);
    }

    void AddHold(Button btn, int dir)
    {
        if (btn == null) return;

        var trigger = btn.GetComponent<EventTrigger>() ?? btn.gameObject.AddComponent<EventTrigger>();

        // PointerDown: 開始
        var entryDown = new EventTrigger.Entry { eventID = EventTriggerType.PointerDown };
        entryDown.callback.AddListener((data) => {
            if (moveRoutine == null) moveRoutine = StartCoroutine(Move(dir));
        });
        trigger.triggers.Add(entryDown);
        addedEntries.Add((trigger, entryDown));

        // PointerUp: 停止
        var entryUp = new EventTrigger.Entry { eventID = EventTriggerType.PointerUp };
        entryUp.callback.AddListener((data) => { StopMove(); });
        trigger.triggers.Add(entryUp);
        addedEntries.Add((trigger, entryUp));

        // PointerExit: 停止
        var entryExit = new EventTrigger.Entry { eventID = EventTriggerType.PointerExit };
        entryExit.callback.AddListener((data) => { StopMove(); });
        trigger.triggers.Add(entryExit);
        addedEntries.Add((trigger, entryExit));
    }

    IEnumerator Move(int dir)
    {
        while (true)
        {
            // 現在位置を取得
            Vector3 pos = transform.position;

            // 移動
            pos.x += dir * speed * Time.deltaTime;

            // ★ 移動範囲を制限
            pos.x = Mathf.Clamp(pos.x, minX, maxX);

            // 位置を反映
            transform.position = pos;

            yield return null;
        }
    }

    void StopMove()
    {
        if (moveRoutine != null)
        {
            try { StopCoroutine(moveRoutine); }
            catch { }
            moveRoutine = null;
        }
    }

    void OnDestroy()
    {
        StopMove();

        // 登録した EventTrigger のエントリをすべて削除
        foreach (var pair in addedEntries)
        {
            var trigger = pair.trigger;
            var entry = pair.entry;

            if (trigger != null && trigger.triggers != null && trigger.triggers.Contains(entry))
            {
                trigger.triggers.Remove(entry);
            }
        }
        addedEntries.Clear();
    }
}

