using UnityEngine;

public class Bar : MonoBehaviour
{
    public Rigidbody2D Body { get; private set; }
    public RectTransform RectTransform { get; private set; }

    void Awake()
    {
        this.Body = gameObject.GetComponent<Rigidbody2D>();
        this.RectTransform = gameObject.GetComponent<RectTransform>();
    }

    void Update()
    {
        // 左右ボタンが押下されているとバーを移動させる
        // ただし動かせる範囲からはみ出ないように調整
        var currentX = this.RectTransform.localPosition.x;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            // 右に15動かす
            // ただし230以上なら230で止める
            var newX = Mathf.Min(currentX + 15, 230);
            var pos = new Vector3(newX, this.RectTransform.localPosition.y, 0);
            this.RectTransform.localPosition = pos;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            // 左に15動かす
            // ただし-230以下なら-230で止める
            var newX = Mathf.Max(currentX - 15, -230);
            var pos = new Vector3(newX, this.RectTransform.localPosition.y, 0);
            this.RectTransform.localPosition = pos;
        }
    }
}
