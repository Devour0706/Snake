using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    int score;
    public int finalScore = 0;
    void Start()
    {

    }

    void Update()
    {

    }

    public void ResetScore()
    {
        score = 0;
        scoreText.text = score.ToString();
    }

    public void AddScore()
    {
        score++;
        finalScore = score;
        scoreText.text = score.ToString();
    }

    public void FinalScore()
    {
        scoreText.text = finalScore.ToString();
    }
}
