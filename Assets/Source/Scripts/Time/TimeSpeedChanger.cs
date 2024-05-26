using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

public class TimeSpeedChanger
{
    private CancellationTokenSource _cancellationTokenSource;

    public async void ChangeTime(float newTimeScale,float timeChangeSpeed)
    {
        _cancellationTokenSource?.Cancel();

        _cancellationTokenSource?.Dispose();

        _cancellationTokenSource = new CancellationTokenSource();

        await UniTask.Create(() => TimeChangeCoroutine(newTimeScale, timeChangeSpeed, _cancellationTokenSource.Token));
    }

    private async UniTask TimeChangeCoroutine(float newTimeScale,float timeChangeSpeed, CancellationToken cancellationToken)
    {
        while (Mathf.Abs(Time.timeScale - newTimeScale) > 0.01f)
        {
            Time.timeScale = Mathf.MoveTowards(Time.timeScale, newTimeScale, timeChangeSpeed * Time.unscaledDeltaTime);

            if (cancellationToken.IsCancellationRequested)
                break;

            await UniTask.Yield();
        }

        Time.timeScale = newTimeScale;
    }
}
