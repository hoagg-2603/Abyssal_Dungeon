using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TransparentDetection : MonoBehaviour
{
    [Range(0, 1)]
    [SerializeField] private float transparencyAmount = 0.8f;
    [SerializeField] private float fadeTime  = 0.4f;

    private SpriteRenderer spriteRenderer;
    private Tilemap tilemap;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        tilemap = GetComponent<Tilemap>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       if(other.gameObject.GetComponent<PlayerController>())
       {
            if (spriteRenderer)
            {
                StartCoroutine(FadeRoutine(spriteRenderer,fadeTime, spriteRenderer.color.a, transparencyAmount));
            }
            else if (tilemap)
            {
                StartCoroutine(FadeRoutine(tilemap, fadeTime, tilemap.color.a,transparencyAmount));
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            if (spriteRenderer)
            {
                StartCoroutine(FadeRoutine(spriteRenderer, fadeTime, spriteRenderer.color.a, 1f));
            }
            else if (tilemap)
            {
                StartCoroutine(FadeRoutine(tilemap, fadeTime, tilemap.color.a, 1f));
            }
        }
    }

    private IEnumerator FadeRoutine(SpriteRenderer sr, float time, float start, float targetTransparentcy)
    {
        float elapsed = 0f;
        while(elapsed < time)
        {
            elapsed += Time.deltaTime;
            float newAlpha = Mathf.Lerp(start, targetTransparentcy, elapsed / time);
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, newAlpha);
            yield return null;
        }

    }

    private IEnumerator FadeRoutine(Tilemap tm, float time, float start, float targetTransparentcy)
    {
        float elapsed = 0f;
        while (elapsed < time)
        {
            elapsed += Time.deltaTime;
            float newAlpha = Mathf.Lerp(start, targetTransparentcy, elapsed / time);
            tm.color = new Color(tm.color.r, tm.color.g, tm.color.b, newAlpha);
            yield return null;
        }
    }
}
