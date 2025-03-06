using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int score;
    public static int highestScore = 0;
    [SerializeField] private TextMeshProUGUI scoreText;

    public static int Flag = 0; // Default to 0


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateScore();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void AddScore(int points)
    {
        score += points;
        UpdateScore();
    }
    public void UpdateScore()
    {
        scoreText.text = "Score: " + score.ToString();
        highestScore = Mathf.Max(score, highestScore);
    }
}
