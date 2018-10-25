using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class EnemyManager : MonoBehaviour {

    public static EnemyManager instance;

    [SerializeField]
    private List<BaseEnemy> enemyPrefabs;

    private List<BaseEnemy> currentEnemies = new List<BaseEnemy>();

    private void Awake()
    {
        instance = this;
    }

    public void AddEnemy(BaseEnemy enemy)
    {
        currentEnemies.Add(enemy);
    }

    public void RemoveEnemy(BaseEnemy enemy)
    {
        currentEnemies.Remove(enemy);
    }

    public List<BaseEnemy> GetEnemiesInRange(Vector3 position, float range)
    {
        if (currentEnemies.Count == 0)
            return null;

        return currentEnemies.Where(enemy => Vector3.Distance(position, enemy.transform.position) < range).ToList();
    }
}
