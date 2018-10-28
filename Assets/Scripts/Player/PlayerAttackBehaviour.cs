using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackBehaviour : MonoBehaviour {

    private bool isAttacking;

    public BaseWeapon currentWeapon;

    public KeyCode attackKeyCode = KeyCode.Space;


	void Update () {
        if (Input.GetKeyDown(attackKeyCode))
        {
            foreach(RaycastHit hit in Physics.SphereCastAll(transform.position + transform.forward * 0.5f, 2, Vector3.forward))
            {
                if (hit.collider.CompareTag("Enemy"))
                    hit.collider.GetComponentInParent<BaseEnemy>().TakeDamage(currentWeapon.Damage);
            }
        }	
	}

    
}
