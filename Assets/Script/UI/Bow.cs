using UnityEngine;

public class Bow : MonoBehaviour, IWeapon
{
    [SerializeField] private WeaponInfo weaponInfo;
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private Transform arrowSpamPoint;

    readonly int FIRE_HASH = Animator.StringToHash("Fire");
    private Animator myAnimator;

    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
    }

    public void Attack()
    {
        myAnimator.SetTrigger(FIRE_HASH);
        GameObject newArrow = Instantiate(arrowPrefab, arrowSpamPoint.position, ActiveWeapon.Instance.transform.rotation);
    }

    public WeaponInfo GetWeaponInfo()
    {
        return weaponInfo;
    }
}
