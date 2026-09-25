using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerDog : MonoBehaviour
{
    private enum PlayerState
    {
        Idle,
        Move,
        Jump,
        Action
    }

    [Header("Movement")]
    [SerializeField] private float moveSpeed = 30f;
    [SerializeField] private float jumpForce = 10f;

    [Header("Dog Action")]
    [SerializeField] private float actionDuration = 0.7f;
    [SerializeField] private float actionCooldown = 0.5f;
    [SerializeField] private float actionRadius = 1f;
    [SerializeField] private LayerMask actionTargetLayer;

    [Header("Debug")]
    [SerializeField] private PlayerState currentState;

    private Rigidbody2D rb;

    private bool isGrounded;
    private bool isAction;
    private bool isCooldown;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        currentState = PlayerState.Idle;
    }

    private void Update()
    {
        UpdateState();
        HandleInput();
    }

    private void UpdateState()
    {
        // アクション中はAction状態を維持
        if (isAction)
        {
            currentState = PlayerState.Action;
            return;
        }

        // 空中
        if (!isGrounded)
        {
            currentState = PlayerState.Jump;
            return;
        }

        // 地上
        if (Mathf.Abs(rb.linearVelocity.x) > 0.01f)
        {
            currentState = PlayerState.Move;
        }
        else
        {
            currentState = PlayerState.Idle;
        }
    }

    private void HandleInput()
    {
        Move();
        Jump();
        Action();
    }

    private void Move()
    {
        // アクション中は移動できない
        if (isAction)
        {
            rb.linearVelocity = new Vector2(
                0f,
                rb.linearVelocity.y
            );

            return;
        }

        float input = 0f;

        if (Keyboard.current.aKey.isPressed)
        {
            input = -1f;
        }
        else if (Keyboard.current.dKey.isPressed)
        {
            input = 1f;
        }

        rb.linearVelocity = new Vector2(
            input * moveSpeed,
            rb.linearVelocity.y
        );

        // 移動方向に向きを変更
        if (input != 0)
        {
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x) * Mathf.Sign(input);
            transform.localScale = scale;
        }
    }

    private void Jump()
    {
        // アクション中はジャンプ不可
        if (isAction)
        {
            return;
        }

        if (Keyboard.current.jKey.wasPressedThisFrame && isGrounded)
        {
            rb.linearVelocity = new Vector2(
                rb.linearVelocity.x,
                jumpForce
            );

            isGrounded = false;
        }
    }

    private void Action()
    {
        // Kキーを押した瞬間
        if (!Keyboard.current.kKey.wasPressedThisFrame)
        {
            return;
        }

        // 空中では使用不可
        if (!isGrounded)
        {
            return;
        }

        // クールタイム中は使用不可
        if (isCooldown)
        {
            return;
        }

        StartCoroutine(BarkAction());
    }

    private IEnumerator BarkAction()
    {
        isAction = true;

        // アクション開始時に速度を止める
        rb.linearVelocity = new Vector2(
            0f,
            rb.linearVelocity.y
        );

        Debug.Log("犬：吠える！");

        float timer = 0f;

        while (timer < actionDuration)
        {
            // 円形のアクション判定
            Collider2D[] targets = Physics2D.OverlapCircleAll(
                transform.position,
                actionRadius,
                actionTargetLayer
            );

            foreach (Collider2D target in targets)
            {
                DestructibleObject destructible =
                    target.GetComponent<DestructibleObject>();

                if (destructible != null)
                {
                    destructible.Break();
                }
            }

            timer += Time.deltaTime;

            yield return null;
        }

        isAction = false;

        // クールタイム開始
        StartCoroutine(ActionCooldown());
    }

    private IEnumerator ActionCooldown()
    {
        isCooldown = true;

        yield return new WaitForSeconds(actionCooldown);

        isCooldown = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Sceneビューで吠える範囲を表示
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(
            transform.position,
            actionRadius
        );
    }
}