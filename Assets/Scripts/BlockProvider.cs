using UnityEngine;

public class BlockProvider : MonoBehaviour
{
    [SerializeField]
    private GameObject BlockPrefab;

    /// <summary>
    /// ブロックの生成処理
    /// </summary>
    /// <returns></returns>
    public Block Create(Transform parent, Vector2 position)
    {
        var go = Instantiate(this.BlockPrefab, parent) as GameObject;
        var block = go.GetComponent<Block>();
        go.GetComponent<RectTransform>().anchoredPosition = position;

        return block;
    }
}
