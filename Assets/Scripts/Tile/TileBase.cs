using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TileBase : MonoBehaviour
{
    [SerializeField] public bool isTouched;
    [SerializeField] protected Sprite OriginalSprite;
    [SerializeField] protected Sprite NewSprite;
    [SerializeField] protected float shakeIntensity = 0.1f;
    [SerializeField] protected float shakeDuration = 0.2f;
    [SerializeField] protected float fallSpeed = 5f;
    [SerializeField] protected ParticleSystem ParticleObject;
    protected SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ParticleObject = GetComponent<ParticleSystem>();
        SpriteCheckFirstly();
    }

    public virtual void ResetState()
    {
        isTouched = false;
        if (spriteRenderer != null && OriginalSprite != null)
        {
            spriteRenderer.sprite = OriginalSprite;
        }
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
        transform.localScale = Vector3.one;
    }

    protected virtual void TileMove() { }
    protected virtual void ChangeTheSprite() { }
    protected virtual void TileShake() { }

    private void SpriteCheckFirstly()
    {
        if (spriteRenderer.sprite != null && OriginalSprite != null && NewSprite != null)
        {
            Debug.Log("Sprite Had");
        }
        Debug.Log("Sprite Check Once Again");
    }
}

