using System.Collections;
using TMPro;
using UnityEngine;

public class ScorePopup : MonoBehaviour
{
    [Header("表示時間")]
    [SerializeField] private float displayTime = 1f;

    [Header("上に移動する速度")]
    [SerializeField] private float moveSpeed = 1f;

    private TextMeshPro text;

    private void Awake()
    {
        text = GetComponentInChildren<TextMeshPro>();
    }

    private void Start()
    {
        StartCoroutine(ShowPopup());
    }

    private IEnumerator ShowPopup()
    {
        float timer = 0f;

        Color startColor = text.color;

        while (timer < displayTime)
        {
            timer += Time.deltaTime;

            // 少し上に移動
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;

            // 徐々に透明にする
            float alpha = 1f - (timer / displayTime);

            text.color = new Color(
                startColor.r,
                startColor.g,
                startColor.b,
                alpha
            );

            yield return null;
        }

        // 1秒経過したら消す
        Destroy(gameObject);
    }
}