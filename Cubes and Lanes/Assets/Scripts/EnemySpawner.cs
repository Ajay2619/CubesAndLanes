using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    
    [SerializeField] private GameObject Enemy;
    [SerializeField] private float spawnInterval;
    public Transform[] Spawners;
    [SerializeField] private int enemyPoolSize = 20;
    private Queue<GameObject> EnemyPool;
    void Start()
    {
        EnemyPool = new Queue<GameObject>(); 
        for (int i = 0; i < enemyPoolSize; i++)
        {
            GameObject obj = Instantiate(Enemy);
            obj.SetActive(false);
            EnemyPool.Enqueue(obj); 
        }
        InvokeRepeating("RandomSpawn", 1f, spawnInterval);
    }
    void RandomSpawn()
    {
        //generating a random lane index for enemy to spawn in
        int randomLaneIndex = Random.Range(0,3);
        GameObject obj = EnemyPool.Dequeue();

        obj.transform.position = Spawners[randomLaneIndex].transform.position;
        obj.SetActive(true);
        obj.GetComponent<Enemy>().LaneIndex = randomLaneIndex;
        obj.GetComponent<Enemy>().canMoveHorizontally = true;

        EnemyPool.Enqueue(obj);
    }
}
