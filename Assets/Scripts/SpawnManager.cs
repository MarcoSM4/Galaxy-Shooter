using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private GameObject[] powerups;

    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Level1")
        {
            StartCoroutine(EnemySpawn());
            StartCoroutine(PowerupSpawn());
        }

        if (scene.name == "Level3")
        {
            StartCoroutine(EnemySpawnlvl2());
            StartCoroutine(PowerupSpawnlvl2());
        }
    }

    void Update()
    {
        
    }

    IEnumerator EnemySpawn()
    {
        while (true)
        {
            Instantiate(enemyPrefab, new Vector2(Random.Range(-2.9f, 2.9f), 6.5f), Quaternion.identity);
            yield return new WaitForSeconds(3.0f);
        }
    }

    IEnumerator EnemySpawnlvl2()
    {
        while (true)
        {
            Instantiate(enemyPrefab, new Vector2(Random.Range(-2.9f, 2.9f), 6.5f), Quaternion.identity);
            yield return new WaitForSeconds(1.0f);
        }
    }

    IEnumerator PowerupSpawn()
    {
        while (true)
        {
            int randomPowerup = Random.Range(0, 1);
            Instantiate(powerups[randomPowerup], new Vector2(Random.Range(-2.9f, 2.9f), 6.5f), Quaternion.identity);
            yield return new WaitForSeconds(7.0f);
        }
    }

    IEnumerator PowerupSpawnlvl2()
    {
        while (true)
        {
            int randomPowerup = Random.Range(0, 2);
            Instantiate(powerups[randomPowerup], new Vector2(Random.Range(-2.9f, 2.9f), 6.5f), Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }
    }
}
