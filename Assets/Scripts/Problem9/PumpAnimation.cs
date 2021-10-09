using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpAnimation : MonoBehaviour
{
    public float scalingRate = 1.1f;
    public float maxSize = 2f;
    public float animationTime = 2f;

    private void OnEnable()
    {
        Process();
    }

    void Process()
    {
        StartCoroutine(ScaleAnimation(Process));
    }

    IEnumerator ScaleAnimation(System.Action onCompleted)
    {
        float time = 0;
        Vector3 originalSize = transform.localScale;

        while (time < animationTime)
        {
            transform.localScale = Vector3.Lerp(originalSize, new Vector3(maxSize, maxSize, 1f), time/animationTime);
            time += Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }

        time = 0;

        while (time < animationTime)
        {
            transform.localScale = Vector3.Lerp(new Vector3(maxSize, maxSize, 1f), originalSize, time / animationTime);
            time += Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }

        onCompleted?.Invoke();
    }
}
