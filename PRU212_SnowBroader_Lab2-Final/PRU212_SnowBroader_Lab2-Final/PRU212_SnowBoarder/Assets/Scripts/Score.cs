using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    Text scoreText;
    int score = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = 0;
        scoreText = GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
    }

    public void RemoveScore(int scoreToRemove)
    {
        score -= scoreToRemove;
    }
}
