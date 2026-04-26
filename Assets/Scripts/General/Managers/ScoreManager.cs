using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int Score;

    public void UpdateScore(int score)
    {
        Score += score;
    }

    public void UpdateScoreAtEndOfWave()
    {

    }

}
