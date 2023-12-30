using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    public int damage = 1;
    public int rotation = 60;
    public int extension = 3;
    public float duration = 1;

    public void Init (int damage, Sprite sprite, int rotation, int extension, float duration)
    {
        this.damage = damage;
        this.duration = duration;
        this.rotation = rotation;
        this.extension = extension;
        if (sprite != null) GetComponent<SpriteRenderer>().sprite = sprite;
    }
    
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