using UnityEngine;

public class DestructibleObject : MonoBehaviour
{
    [Header("Score")]
    [SerializeField] private int score = 50;

    [Header("Sprite")]
    [SerializeField] private Sprite brokenSprite;

    [Header("Score Popup")]
    [SerializeField] private GameObject scorePopupPrefab;
    private bool isBroken = false;

    private SpriteRenderer spriteRenderer;
    private Collider2D col;

    private void Awake()
    {
        // 子オブジェクト「Sprite」からSpriteRendererを取得
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        // 親のColliderを取得
        col = GetComponent<Collider2D>();
    }

    public void Break()
    {
        if (isBroken) return;

        isBroken = true;

        Debug.Log(gameObject.name + " が破壊されました！");

        // 壊れた画像に変更
        if (brokenSprite != null && spriteRenderer != null)
        {
            spriteRenderer.sprite = brokenSprite;
        }

        // 当たり判定を無効化
        if (col != null)
        {
            col.enabled = false;
        }

        // スコア加算
        GameManager.Instance.AddScore(score);

        // スコア表示
        if (scorePopupPrefab != null)
        {
            Instantiate(
                scorePopupPrefab,
                transform.position + Vector3.up * 1f,
                Quaternion.identity
            );
        }
    }
}