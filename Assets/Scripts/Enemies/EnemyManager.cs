using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyManager : MonoBehaviour
{
    public List<Transform> allWayPoints;

    public Transform spawnPoint;

    public List<GameObject> enemyPrefab;

    public float spawnRate = 0;
    float actualTime = 0;

    private void Update()
    {
        actualTime += Time.deltaTime;

        if (actualTime >= spawnRate)
        {
            SpawnEnemy();
            actualTime = 0;
        }
    }

    void SpawnEnemy()
    {
        Enemy enemy = Instantiate(enemyPrefab[Random.Range(0, enemyPrefab.Count)], spawnPoint.position, spawnPoint.rotation).GetComponent<Enemy>();

        List<Vector3> wayPoints = allWayPoints.Select(e => e.position).ToList();

        enemy.SetWayPoints(wayPoints);
    }
}
