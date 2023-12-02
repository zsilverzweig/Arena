using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Debug.Log("OnTriggerEnter2D");
        if (!collision.isTrigger) // Ensure the collider is not a trigger
        {
            // Debug.Log("Not a trigger");
            Healthy healthy = collision.gameObject.GetComponentInParent<Healthy>();
            var isAttacking = transform.GetComponentInParent<Attacker>().status == "attacking";
            if (healthy != null && isAttacking)
            {
                Debug.Log("Someone hit a Healthy thing");
                healthy.DoDamage(damage);
            }
        }
    }
}