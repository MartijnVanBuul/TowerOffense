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

public class BaseTower : MonoBehaviour {

    public E_TowerType TowerType;
    public bool IsActive;
    public bool CanAttack;
    public bool IsOnCooldown;
    public List<BaseEnemy> EnemiesInRange;

    public float TowerAttackRange;
    public float TowerVisionRange;
    public float TowerCost;
    public float TowerDamage;
    public int TowerLevel;
    public float TowerCooldown;

    private BaseEnemy targetEnemy;

    [Header("References")]
    public CircularLineRenderer TowerAttackRangeIndicator;
    public CircularLineRenderer TowerVisionRangeIndicator;

    public void Start()
    {
        if(TowerAttackRangeIndicator)
            TowerAttackRangeIndicator.UpdateCircle(TowerAttackRange);
        if (TowerVisionRangeIndicator)
            TowerVisionRangeIndicator.UpdateCircle(TowerVisionRange);
    }

    public void Update()
    {
        if (IsOnCooldown)
            return;

        if (EnemiesInRange.Count > 0)
            targetEnemy = DeterminePriority();

        if (targetEnemy)
            AttackEnemy(targetEnemy);
    }



    public void ChangeTowerAttackRange(float range)
    {
        TowerAttackRange = range;
        TowerAttackRangeIndicator.UpdateCircle(TowerAttackRange);
    }

    public void ChangeTowerVisionRange(float range)
    {
        TowerVisionRange = range;
        TowerVisionRangeIndicator.UpdateCircle(TowerVisionRange);
    }

    private BaseEnemy DeterminePriority()
    {
        return EnemiesInRange[0];
    }

    private void AttackEnemy(BaseEnemy target)
    {
        target.TakeDamage(TowerDamage);

        Invoke("ResetCooldown", TowerCooldown);
    }

    private void ResetCooldown()
    {
        IsOnCooldown = false;
    }
}
