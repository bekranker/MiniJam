using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class DayNightCycle : MonoBehaviour
{
    [Header("Phase Durations")]
    [SerializeField] private float morningDuration = 90f;
    [SerializeField] private float afterMorningDuration = 30f;
    [SerializeField] private float nightDuration = 30f;
    [SerializeField] private float midNightDuration = 15f;

    [Header("Phase Events")]
    public UnityEvent onMorningEnd;
    public UnityEvent onAfterMorningEnd;
    public UnityEvent onNightEnd;
    public UnityEvent onMidNightEnd;

    public int DayCount { get; private set; } = 0;

    private void Start()
    {
        StartCoroutine(DayNightCycleCoroutine());
    }

    private IEnumerator DayNightCycleCoroutine()
    {
        while (true)
        {
            // Morning Phase
            yield return new WaitForSeconds(morningDuration);
            onMorningEnd?.Invoke();

            // After Morning Phase
            yield return new WaitForSeconds(afterMorningDuration);
            onAfterMorningEnd?.Invoke();

            // Night Phase
            yield return new WaitForSeconds(nightDuration);
            onNightEnd?.Invoke();

            // MidNight Phase
            yield return new WaitForSeconds(midNightDuration);
            onMidNightEnd?.Invoke();
        }
    }

    public void IncrementDayCount()
    {
        DayCount++;
        Debug.Log("Day " + DayCount + " has ended.");
    }
}
