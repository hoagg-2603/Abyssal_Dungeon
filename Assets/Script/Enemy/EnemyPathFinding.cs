using UnityEngine;

public class EnemyPathFinding : MonoBehaviour
{
    [SerializeField] private float speed = 2f;

    private Rigidbody2D rb;
    private Vector2 moveDir;
    private KnockBack knockBack;

    private void Awake()
    {
        knockBack = GetComponent<KnockBack>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (knockBack.GettingKnockedBack)
            return; 
        rb.MovePosition(rb.position + moveDir * speed * Time.fixedDeltaTime);
    }

    public void MoveTo(Vector2 targetPosition)
    {
        moveDir = targetPosition;
    }
}
