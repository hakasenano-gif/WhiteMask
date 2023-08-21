using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Boss_time : MonoBehaviour
{
    public TextMeshProUGUI timerText;  // UIテキストの参照
    private float startTime; // 表示開始時刻

    private void Start()
    {
        startTime = Time.time;  // 表示開始時刻を記録
    }

    private void Update()
    {
        // 経過時間を計算し、UIテキストに表示
        float elapsedTime = Time.time - startTime;
        UpdateTimerText(elapsedTime);
    }

    private void UpdateTimerText(float time)
    {
        // 経過時間を秒単位で整形して表示
        int seconds = Mathf.FloorToInt(time);
        timerText.text = "Time: " + seconds.ToString() + "s";
    }
}
