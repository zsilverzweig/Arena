using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    public string status = "done";
    
    private float _attackDuration;
    private Weapon _weapon;
    private Body _body;
    private Mover _mover;
    private Sprite _attackingSprite;
    private Sprite _initialSprite; // This is nice in case we want to update sprites with damage.
     
    private bool _animateAttack = false;
    private Vector3 _attackDirection = Vector3.right;

    
    public void Init(Sprite initialSprite, Sprite attackingSprite, Weapon weapon, Body body, float attackDuration)
    {
        _mover = transform.GetComponent<Mover>();
        _attackDuration = attackDuration;
        _initialSprite = initialSprite;
        _attackingSprite = attackingSprite;
        _weapon = weapon;
        _body = body;
        
        if (attackingSprite != null && _weapon == null) _animateAttack = true;
    }
    
    public void Attack()
    {
        _attackDirection = _mover.facing == "right" ? Vector3.right : Vector3.left;  
        if (status != "attacking")
        {
            status = "attacking";
            if (_animateAttack)
            {
                Debug.Log("I'm attacking you with an animation");
                _body.SetSprite(_attackingSprite);
            }

            if (_weapon != null)
            {
                _weapon.transform.Rotate(Vector3.forward,-_weapon.rotation);
                _weapon.transform.position += _attackDirection * _weapon.extension / 100;

            }
            StartCoroutine(ReturnToReadyPosition());    
        }
        
    } 
    
    private IEnumerator ReturnToReadyPosition()
    {
        yield return new WaitForSeconds(_attackDuration);
        if (_weapon != null)
        {
            _weapon.transform.Rotate(Vector3.forward, _weapon.rotation);
            _weapon.transform.position -= _attackDirection * _weapon.extension / 100;
        }

        if (_animateAttack)
        {
            _body.SetSprite(_initialSprite);
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
