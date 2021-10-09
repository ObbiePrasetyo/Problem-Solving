using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private SpriteRenderer sprite;
    private BoxCollider2D boxCollider;

    private float minSize = 0.2f;
    private float maxSize = 1.0f;

    void RandomizeShape()
    {
        sprite = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();

        float width = Random.Range(minSize, maxSize);
        float height = Random.Range(minSize, maxSize);

        sprite.size = new Vector2(width, height);
        boxCollider.size = new Vector2(width, height);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ScoreManager.Instance.IncrementScore();
            this.gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        RandomizeShape();
    }
}
