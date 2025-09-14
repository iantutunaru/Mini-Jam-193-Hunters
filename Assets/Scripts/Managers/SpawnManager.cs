using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject enemyToSpawn;
    [SerializeField] private int numberOfEnemies = 10;
    [SerializeField] private float spawnInterval = 10f;
    [SerializeField] private Transform player;
    
    private List<GameObject> _enemies;

    private float _timerBetweenSpawns = 0f;

    private void Awake()
    {
        _enemies = new List<GameObject>();
    }

    private void FixedUpdate()
    {
        if (_timerBetweenSpawns > spawnInterval)
        {
            SpawnEnemy();
            
            _timerBetweenSpawns = 0f;
        }
        else
        {
            _timerBetweenSpawns += Time.fixedDeltaTime;
        }
    }

    private void SpawnEnemy()
    {
        var spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        
        var enemy = Instantiate(enemyToSpawn, spawnPoint.position, Quaternion.identity).GetComponent<AITarget>();
        
        enemy.SetTarget(player);
        
        _enemies.Add(enemy.gameObject);
    }
}
