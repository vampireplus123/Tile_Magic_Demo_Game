using System.Collections;
using UnityEngine;

public class ShortTile : TileBase, ITilePoint
{
    [SerializeField] private int Point;
    private float spawnTime;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        OriginalSprite = spriteRenderer.sprite;
        spawnTime = Time.time; 
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
        if (isTouched) return;

        isTouched = true;

        float reactionTime = Time.time - spawnTime;

        TileShake();
        ChangeTheSprite();
        ScoreManager.Instance.AddScore(Point, reactionTime);
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
