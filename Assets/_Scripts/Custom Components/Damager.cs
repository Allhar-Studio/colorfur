using UnityEngine;

public class Damager : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] DamagerType type;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
        if (damageable != null)
            damageable.TakeDamage(damage, transform.position, type);
    }
}
