using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public int attackDamage = 10;
    public Vector2 knockback = Vector2.zero;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // See if it can be hit
        Damageable damageable= other.GetComponent<Damageable>();
        if (damageable != null)
        {
            Vector2 deliveredKnockback = transform.parent.localScale.x > 0 ? knockback : new Vector2(-knockback.x, knockback.y);
            // Hit the target
            if(damageable.Hit(attackDamage, deliveredKnockback))
            {
                Debug.Log(other.name + " hit for " + attackDamage);
            }
        }
    }
}
