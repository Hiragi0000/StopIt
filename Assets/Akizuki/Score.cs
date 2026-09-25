using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public int score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;

    void Start()
    {
        UpdateScoreText();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            DataKeep.keep.score += 10;
            Debug.Log("ポイントが加算されません");
        }
    }

    public void AddScore()
    {
        score += DataKeep.keep.score;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }
    }
}