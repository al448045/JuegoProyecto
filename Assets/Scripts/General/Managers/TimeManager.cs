using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private float remainingTime;

    private void Start()
    {

    }

    private void Update()
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
