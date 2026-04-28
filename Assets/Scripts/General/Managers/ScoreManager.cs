using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int Score;

    private void Start()
    {
        Score = 0;
        UIHandler.Instance.ChangeScore(Score);
    }
    public void UpdateScore(int score)
    {
        Score += score;
        UIHandler.Instance.ChangeScore(Score);
    }

    public void UpdateScoreAtEndOfWave()
    {
        int remainingTimeToScore = Mathf.FloorToInt(GameManager.Instance.timeManager.remainingTime);
        Score += remainingTimeToScore;
    }
}
