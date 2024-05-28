using UnityEngine;

public class Timer
{
    public float PassedTime { get; private set; }
    public float NeedTime { get; private set; }

    public Timer(float needTime)
    {
        NeedTime = needTime;
    }

    public void Reset()
    {
        PassedTime = 0;
    }

    public void TickTime()
    {
        PassedTime += Time.deltaTime;
    }

    public bool IsTimeAchieve()
    {
        return PassedTime >= NeedTime;
    }
}
