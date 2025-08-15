using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int startingHealth = 3;
    [SerializeField] private GameObject deathVFX;
    [SerializeField] private float knockBackThrust = 15f;

    private int currentHealth;
    private KnockBack knockBack;
    private Flash flash;
    
    private void Awake()
    {
        flash = GetComponent<Flash>();
        knockBack = GetComponent<KnockBack>();
    }

    private void Start()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        knockBack.GetKnockedBack(PlayerController.Instance.transform,knockBackThrust);
        StartCoroutine(flash.FlashRoutine());
        StartCoroutine(CheckDetecDeathRoutine());
    }

    private IEnumerator CheckDetecDeathRoutine()
    {
        yield return new WaitForSeconds(flash.GetRestoreMatTime());
        DectecDeath();
    }
    public void DectecDeath()
    {
        if (currentHealth <= 0)
        {
            Instantiate(deathVFX, transform.position, Quaternion.identity);
            Destroy(gameObject);

        }
    }
}
