using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShadow : MonoBehaviour
{
    private SpriteRenderer sprite;

    private void Update()
    {
        //transform.Rotate(Vector3.forward, 2000f * Time.deltaTime);
    }

    IEnumerator Appear(System.Action onCompleted)
    {
        float time = 0;

        sprite = GetComponent<SpriteRenderer>();
        Color temp = sprite.color;

        while (time < 0.5f)
        {
            sprite.color = new Color(temp.r, temp.g, temp.b, Mathf.Lerp(0.5f, 0f, time / 0.5f));
            transform.localScale = Vector2.Lerp(new Vector2(16, 16), Vector2.one, time / 0.5f);
            time += Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }

        onCompleted?.Invoke();
    }

    private void OnEnable()
    {
        StartCoroutine(Appear(DeactivateObject));
    }

    void DeactivateObject()
    {
        gameObject.SetActive(false);
    }
}
