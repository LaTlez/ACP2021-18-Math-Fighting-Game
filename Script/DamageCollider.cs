using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour {

    public float damage;
    public string punchName;
    public Fighter fighter; // อ้างอิงของเรา = 1,2

    private void OnTriggerEnter(Collider other)
    {
        Fighter enemy = other.GetComponent<Fighter>();
        if (fighter.attacking)
        {
            if (enemy != null && enemy != fighter)
            {
                enemy.takeDamage(damage);
            }
        }
    }
}
