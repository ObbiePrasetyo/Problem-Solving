using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public Vector3 maxSizeAnimation = new Vector3(2, 2, 1);
    public float maxRotateSpeed = 100f;

    private float rotateSpeed;

    private SpriteRenderer sprite;
    private BoxCollider2D boxCollider;

    private float minSize = 0.5f;
    private float maxSize = 1.3f;

    private bool isAnimating;
    
    void RandomizeShape()
    {
        sprite = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();

        float width = Random.Range(minSize, maxSize);
        float height = Random.Range(minSize, maxSize);
        float rRandom = Random.Range(150, 250)/255f;
        float gRandom = Random.Range(150, 250)/255f;
        float bRandom = Random.Range(150, 250)/255f;

        int colorFilter = Random.Range(0, 2);

        switch (colorFilter)
        {
            case 0:
                rRandom = 0f;
                break;

            case 1:
                gRandom = 0f;
                break;

            case 2:
                bRandom = 0f;
                break;
        }


        sprite.size = new Vector2(width, height);
        boxCollider.size = new Vector2(width, height);
        sprite.color = new Color(rRandom, gRandom, bRandom);
    }

    private void Update()
    {
        transform.Rotate(Vector3.forward, rotateSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isAnimating)
            return;

        if (collision.gameObject.tag == "Player")
        {
            ScoreManager.Instance.IncrementScore();

            if (FindObjectOfType<AudioManager>() != null)
                AudioManager.Instance.Play("Scored");

            StartCoroutine(BoxDissappear(DeactivateObject));
        }
    }

    private void OnEnable()
    {
        RandomizeShape();
        RandomizeRotateSpeed();

        if (FindObjectOfType<AudioManager>() != null) 
            AudioManager.Instance.Play("BoxAppear");

        StartCoroutine(BoxAppear());
    }

    IEnumerator BoxAppear()
    {
        isAnimating = true;
        ToggleCollider();
        float time = 0;
        Vector3 originalSize = transform.localScale;

        while (time < 0.2)
        {
            transform.localScale = Vector3.Lerp(maxSizeAnimation, Vector3.one, time / 0.2f);
            Color _tempColor = sprite.color;
            GetComponent<SpriteRenderer>().color = new Color(_tempColor.r, _tempColor.g, _tempColor.b, Mathf.Lerp(0, 1, time / 0.2f));
            time += Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }
        ToggleCollider();
        isAnimating = false;
    }

    IEnumerator BoxDissappear(System.Action onCompleted)
    {
        isAnimating = true;
        ToggleCollider();
        float time = 0;
        Vector3 originalSize = transform.localScale;

        while (time < 0.5f)
        {
            transform.localScale = Vector3.Lerp(Vector3.one, maxSizeAnimation, time / 0.5f);
            Color _tempColor = sprite.color;
            GetComponent<SpriteRenderer>().color = new Color(_tempColor.r, _tempColor.g, _tempColor.b, Mathf.Lerp(1,0, time / 0.5f));
            time += Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }
        ToggleCollider();
        isAnimating = false;
        onCompleted?.Invoke();
    }

    void DeactivateObject()
    {
        this.gameObject.SetActive(false);
    }

    void ToggleCollider()
    {
        boxCollider.enabled = !boxCollider.enabled;
    }

    void RandomizeRotateSpeed()
    {
        rotateSpeed = Random.Range(-maxRotateSpeed, maxRotateSpeed);
    }
}
