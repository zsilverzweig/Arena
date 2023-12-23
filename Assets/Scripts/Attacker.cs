using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    public GameObject weapon;
    public string status = "done";
    
    [Header("UI Variables")]
    public float duration = 1;
    public int rotation = 60;
    public int extension = 3;
    public Sprite attackingSprite;
    
    private Time _startTime;
    private Vector3 _attackDirection = Vector3.right;
    
    private SpriteRenderer _spriteRenderer;
    private Mover _mover;
    private SpriteRenderer _bodySprite;
    private Sprite _initialSprite; // This is nice in case we want to update sprites with damage.
    private bool _animateAttack; 

    public void Start()
    {
        if (attackingSprite != null) _animateAttack = true;

        if (_animateAttack)
        {
            Body body = transform.GetComponentInChildren<Body>();
            _bodySprite = body.transform.GetComponent<SpriteRenderer>();
        }
        
        _mover = transform.GetComponent<Mover>();
        
        
        //Debug.Log("Found sprite renderer: " + spriteRenderer.name);
    }
    
    public void Attack()
    {
        
        _attackDirection = _mover.facing == "right" ? Vector3.right : Vector3.left;  
        if (status != "attacking")
        {
            status = "attacking";
            if (_animateAttack)
            {
                _initialSprite = _bodySprite.sprite;
                Debug.Log("I'm attacking you with an animation");
                _bodySprite.sprite = attackingSprite;
            }
            
            weapon.transform.Rotate(Vector3.forward,-rotation);
            weapon.transform.position += _attackDirection / extension;
            StartCoroutine(ReturnToReadyPosition());    
        }
        
    } 
    
    private IEnumerator ReturnToReadyPosition()
    {
        yield return new WaitForSeconds(duration); // Wait for one second
        weapon.transform.Rotate(Vector3.forward, rotation);
        weapon.transform.position -= _attackDirection / extension;
        if (_animateAttack)
        {
            _bodySprite.sprite = _initialSprite;
        }
        status = "done";
    }
    
}

public interface ICharacter
{
    void TakeDamageEffects(int damage);
    void Die();
    void AddHealthEffects(int amount);
}
