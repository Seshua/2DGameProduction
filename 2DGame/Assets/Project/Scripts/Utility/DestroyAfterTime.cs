using System.Collections;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    [field:SerializeField, Tooltip("This is just here to have a quick visual of how much time until this gameobect gets destroyed, it works for both coroutine and update.")]
    private float countDownUntilDestroyed;

    [SerializeField, Tooltip("How many seconds until this gameobject gets destroyed.")]
    private float secondsToDestroy;


    [field: SerializeField, Tooltip("Should the coroutine use WaitForSecondsRealTime() or just WaitForSeconds().")]
    public bool UseRealTime { get; set; } = false;

    [field:SerializeField, Tooltip("If true: Uses a coroutine as a timer\nIf false: Uses Update()")]
    public bool UseCoroutine { get; set; }

    public bool MarkedForDestroy { get; set; }

    private void Start()
    {
        // Private variable that is used to see in the inspector how long until the object gets removed.
        countDownUntilDestroyed = secondsToDestroy;

        if (UseCoroutine)
        {
            StartCoroutine(DestroyRoutine(secondsToDestroy));
        }
        else
        {
            MarkedForDestroy = true;
        }

        // Test
        Time.timeScale = 0.1f;
    }

    private void Update()
    {
        if (MarkedForDestroy)
        {
            if (countDownUntilDestroyed > 0)
            {
                countDownUntilDestroyed -= UseRealTime ? Time.unscaledDeltaTime : Time.deltaTime;
                if (countDownUntilDestroyed <= 0)
                {
                    if (!UseCoroutine) Destroy(gameObject);
                    return;
                }
            }
        }
    }

    private IEnumerator DestroyRoutine(float timer)
    {
        MarkedForDestroy = true;
        if (UseRealTime) yield return new WaitForSecondsRealtime(timer);
        else yield return new WaitForSeconds(timer);
        Destroy(gameObject);
    }
}
