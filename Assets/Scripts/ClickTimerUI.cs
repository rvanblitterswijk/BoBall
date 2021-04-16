using System.Collections;
using UnityEngine;

public class ClickTimerUI : MonoBehaviour
{
    private RectTransform rectTransform;
    private float maxBarSize;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        maxBarSize = rectTransform.localScale.x;
    }

    public void StartCount(float time)
    {
        StartCoroutine(Count(time));
    }

    private IEnumerator Count(float maxTime)
    {
        var elapsedTime = 0f;

        while (elapsedTime < maxTime)
        {
            var fillPercentage = (elapsedTime / maxTime) * maxBarSize;
            elapsedTime += Time.deltaTime;
            rectTransform.localScale = new Vector3(fillPercentage, rectTransform.localScale.y, rectTransform.localScale.z);
            yield return null;
        }

        yield break;
    }
}
