using System.Collections;
using UnityEngine;

public class LightDecor : MonoBehaviour
{
    public static LightDecor Instance { get; private set; }
    private SpriteRenderer spriteRenderer;
    private Color defaultColor = new Color(1f, 1f, 1f, 0.588f);  
    private Color activeColor = new Color(1f, 1f, 1f, 1f); 
    private Coroutine blinkCoroutine; 

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer != null)
        {
            spriteRenderer.color = defaultColor; 
        }
    }

    public void ChangeLightContrast()
    {
        if (blinkCoroutine != null)
        {
            StopCoroutine(blinkCoroutine); 
        }

        blinkCoroutine = StartCoroutine(BlinkLight()); 
    }

    private IEnumerator BlinkLight()
    {
        if (spriteRenderer == null) yield break;
        spriteRenderer.color = activeColor;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = defaultColor;
        yield return new WaitForSeconds(0.2f);
    }
}
