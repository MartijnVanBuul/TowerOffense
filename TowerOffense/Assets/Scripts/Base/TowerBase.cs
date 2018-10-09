using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum E_TowerType
{
    Ranged,
    Mage,
    Melee,
    Default
}

public class TowerBase : MonoBehaviour {

    public E_TowerType TowerType;
    public bool IsActive;
    public bool CanAttack;
    public bool IsOnCooldown;
    public List<EnemyBase> EnemiesInRange;

    public float TowerAttackRange;
    public float TowerVisionRange;
    public float TowerCost;
    public float TowerDamage;
    public int TowerLevel;
    public float TowerCooldown;

    private EnemyBase targetEnemy;

    private void Update()
    {
        if (IsOnCooldown)
            return;

        if (EnemiesInRange.Count > 0)
            targetEnemy = DeterminePriority();

        if (targetEnemy)
            AttackEnemy(targetEnemy);
    }

    private EnemyBase DeterminePriority()
    {
        return EnemiesInRange[0];
    }

    private void AttackEnemy(EnemyBase target)
    {
        target.TakeDamage(TowerDamage);

        Invoke("ResetCooldown", TowerCooldown);
    }

    private void ResetCooldown()
    {
        IsOnCooldown = false;
    }
}
