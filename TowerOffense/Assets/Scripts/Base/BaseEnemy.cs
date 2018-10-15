﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour {

    public float Health;
    public float MaxHealth;

    public void Start()
    {
        if (EnemyManager.instance)
            EnemyManager.instance.AddEnemy(this);
    }

    public bool TakeDamage(float damage)
    {
        Health = Mathf.Clamp(Health - damage, 0, MaxHealth);

        return Health == 0;
    }
}
