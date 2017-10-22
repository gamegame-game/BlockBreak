using System.Linq;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UniRx.Triggers;

public class GameManager : MonoBehaviour
{
    public BlockProvider BlockProvider { get; private set; }
    public GameObject BlocksArea { get; private set; }
    public ScoreManager ScoreManager { get; private set; }
    public GameObject Ground { get; private set; }

    void Start()
    {
        this.BlockProvider = GetComponent<BlockProvider>();
        this.BlocksArea = GameObject.Find("Blocks");
        this.ScoreManager = GetComponent<ScoreManager>();
        this.Ground = GameObject.Find("Ground");

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

                // ブロックが壊れたときの処理を登録
                block.OnBroken.Subscribe(
                    score => this.ScoreManager.UpdateScore(score)
                    ).AddTo(block);
            }
        }

        // 全ブロックが壊れたらクリア
        var stream = blocks.Select(blcok => blcok.OnBroken);
        Observable.WhenAll(stream).Subscribe(_ => GameClear());

        // ゲームオーバー判定
        this.Ground.OnTriggerEnter2DAsObservable()
            .Subscribe(
                collider =>
                {
                    // ぶつかったものを消してゲームオーバー
                    Destroy(collider.gameObject);
                    GameOver();
                }
            );
    }

    /// <summary>
    /// クリア時の処理
    /// </summary>
    private void GameClear()
    {
        Debug.Log("ゲームクリア ...");
    }

    /// <summary>
    /// ゲームオーバー処理
    /// </summary>
    private void GameOver()
    {
        Debug.Log("ゲームオーバー ...");
    }
}
