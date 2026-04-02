using UnityEngine;

public class CustomTimer
{
    public float timerAmount;

    public CustomTimer()
    {
        timerAmount = 1f;
    }

    public CustomTimer(float TimerAmount)
    {
        timerAmount = TimerAmount;
    }

    public void UpdateTimer()
    {
        timerAmount -= Time.deltaTime;
    }
}
