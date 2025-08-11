using System.Collections;
using UnityEngine;

public class Flash : MonoBehaviour
{
    [SerializeField] private Material shiterFlashMat;
    [SerializeField] private float restoreDefaulMatTime = 0.2f;

    private Material defaultMat;
    private SpriteRenderer spriteRenderer;
    private EnemyHealth enemyHealth;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        enemyHealth = GetComponent<EnemyHealth>();
        defaultMat = spriteRenderer.material;
    }

    public IEnumerator FlashRoutine()
    {
        spriteRenderer.material = shiterFlashMat;
        yield return new WaitForSeconds(restoreDefaulMatTime);
        spriteRenderer.material = defaultMat;
        enemyHealth.DectecDeath();
    }
}
