using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public BlockProvider BlockProvider { get; private set; }
    public GameObject BlocksArea { get; private set; }

    void Start()
    {
        this.BlockProvider = GetComponent<BlockProvider>();
        this.BlocksArea = GameObject.Find("Blocks");

        // 配置の初期化
        InitializeStage();
    }

    /// <summary>
    /// ブロック配置の初期化
    /// </summary>
    private void InitializeStage()
    {
        var blocks = new List<Block>();

        // 開始位置とブロックのサイズ
        var startPosX = -200;
        var startPosY = -80;
        var width = 100;
        var height = 20;

        // 5*5 の25ブロックを生成
        // 各ブロックのポジションは開始位置からブロックサイズ分右下にずらす
        for (int i = 0; i < 5; i++)
        {
            var posY = startPosY - height * i;
            for (int j = 0; j < 5; j++)
            {
                var posX = startPosX + width * j;
                var position = new Vector2(posX, posY);
                var block = BlockProvider.Create(this.BlocksArea.GetComponent<RectTransform>(), position);
                blocks.Add(block);
            }
        }
    }
}
