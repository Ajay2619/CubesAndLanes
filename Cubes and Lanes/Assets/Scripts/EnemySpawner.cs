using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject Enemy;
    [SerializeField] private float spawnInterval;
    [SerializeField] private Transform[] Spawners;
    [SerializeField] private int poolSize = 20;
    private Queue<GameObject> EnemyPool;
    void Start()
    {
        EnemyPool = new Queue<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(Enemy);
            obj.SetActive(false);
            EnemyPool.Enqueue(obj);
        }
        InvokeRepeating("RandomSpawn", 1f, spawnInterval);
    }
    void RandomSpawn()
    {
        int randomLaneIndex = Random.Range(0,3);
        for (int i = 0; i < 3; i++)
        {
            if(i == randomLaneIndex)
                continue;
                
            GameObject obj = EnemyPool.Dequeue();
            obj.transform.position = Spawners[i].transform.position;
            obj.SetActive(true);
            EnemyPool.Enqueue(obj);
        }
    }
}
