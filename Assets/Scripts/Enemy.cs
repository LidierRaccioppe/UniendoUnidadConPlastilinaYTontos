using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent pathfinder;
    private Transform target;
    
    public GameObject enemyPrefab;
    void Start()
    {
        pathfinder = GetComponent<NavMeshAgent>();
        target = GameObject.Find("Player").transform;
        InvokeRepeating("SpawnEnemy", 15f, 15f);
    }
    void Update()
    {
        pathfinder.SetDestination(target.position);
        Debug.Log(target.position);
        //awdawda
    }
    void SpawnEnemy()
    {
        // Instantiate a new enemy at the same position as the current one
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }
}
