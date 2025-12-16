using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private float spawnRate = 1f;
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(spawnRate); //Wait 1 sec

        Vector2 pivot = transform.position;

        Vector2 randomPos = new Vector2(pivot.x + Random.Range(-1.4f,1.4f) , pivot.y);

        Instantiate(enemy, randomPos, Quaternion.identity); // Spawn enemy

        StartCoroutine(SpawnEnemy()); // Repeat
    }
}
