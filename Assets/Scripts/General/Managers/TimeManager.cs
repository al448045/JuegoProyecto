using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float remainingTime { get; private set; }
    public bool TimeStarted = false;

    private void Update()
    {
        if (TimeStarted)
        {
            UpdateTimer();
        }
    }

    private void UpdateTimer()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }

        else if (remainingTime < 0)
        {
            remainingTime = 0;
        }

        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);

        UIHandler.Instance.ChangeTimer(minutes, seconds);
    }

    public void SetTimer(float timerAmount)
    {
        remainingTime = timerAmount;
    }
}
