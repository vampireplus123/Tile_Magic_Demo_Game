using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongTile : TileBase, ITilePoint
{
    [SerializeField] int Point;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        OriginalSprite = spriteRenderer.sprite;
    }
    void Update()
    {
        TileMove();
    }

    protected override void TileMove()
    {
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
    }
    void OnMouseDown()
    {
        if (isTouched)
        {
            return;
        }
        isTouched = true;
        TileShake();
        ChangeTheSprite();
        ReturnTilePoint();
        Debug.Log($"Point: {ReturnTilePoint()}");
    }

    protected override void ChangeTheSprite()
    {
        if (spriteRenderer.sprite == OriginalSprite)
        {
            spriteRenderer.sprite = NewSprite;
        }
    }

    protected override void TileShake()
    {
        StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {
        Vector3 originalPos = transform.position;
        float elapsed = 0f;

        while (elapsed < shakeDuration)
        {
            float x = Random.Range(-1f, 1f) * shakeIntensity;
            float y = Random.Range(-1f, 1f) * shakeIntensity;
            transform.position = originalPos + new Vector3(x, y, 0);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = originalPos;
    }
    public int ReturnTilePoint()
    {
        return Point;
    }
}