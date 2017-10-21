using UnityEngine;

public class Ball : MonoBehaviour
{
    private void Start()
    {
        // このオブジェクトのRigidbody
        var body = gameObject.GetComponent<Rigidbody2D>();

        // 親のCanvas
        var canvas = GetComponentInParent<Canvas>();

        // 右上の方向に一定の強さで飛んでいくように
        var direction = new Vector2(Random.value, 1).normalized;
        body.velocity = direction * 640 * canvas.transform.localScale.x;
    }
}
