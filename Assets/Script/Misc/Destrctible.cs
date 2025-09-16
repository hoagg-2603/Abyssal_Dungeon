using UnityEngine;

public class Destrctible : MonoBehaviour
{
    [SerializeField] private GameObject destroyeVFX;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<DamageSource>())
        {
            Instantiate(destroyeVFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
