using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text ScoreText { get; private set; }
    public int Score { get; private set; }

    void Awake()
    {
        this.ScoreText = GameObject.Find("ScoreArea").GetComponentInChildren<Text>();
    }

    public void UpdateScore(int score)
    {
        this.Score += score;
        this.ScoreText.text = $"Score: {this.Score}";
    }
}
