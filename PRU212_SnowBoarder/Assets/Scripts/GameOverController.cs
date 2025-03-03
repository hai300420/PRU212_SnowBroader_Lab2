using TMPro;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highestScoreText;
    private GameManager gameManager;
    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText.text = "SCORE: " + GameManager.score.ToString();
        highestScoreText.text = "HIGHEST SCORE: " + GameManager.highestScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
