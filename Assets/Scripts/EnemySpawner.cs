using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // This script spawns enemy waves

    // Enemy types to spawn 
    [SerializeField] Enemy enemyDefault;
    [SerializeField] Enemy enemyHeavy;
    [SerializeField] Enemy enemyFast;

    // Available paths
    //[SerializeField] EnemyPath path;
    //[SerializeField] EnemyPath pathB;

    [SerializeField] List<EnemyPath> paths;

    // Settings
    //[SerializeField] float spawnDelay = 1.0f;

    [SerializeField] int wave01Enemies = 10; 

    [SerializeField] float randomDelayMin = .1f;
    [SerializeField] float randomDelayMax = 2.0f;






    private void Start()
    {
        // Begin the spawner timer
        StartCoroutine(Wave01());
    }
    



    private void SpawnEnemy(Enemy enemyToSpawn, EnemyPath chosenPath)
    {
        // Instantiate enemyToSpawn at transform.position with no rotation and set its path
        Instantiate(enemyToSpawn, transform.position, Quaternion.identity).SetPath(chosenPath);
    }

    IEnumerator Wave01()
    {
        //start 1t 0, count up to 10, step size is 1
        //for(int i = 0; i<wave01Enemies; i++)
        //{


        //    SpawnEnemy(enemyDefault, paths[(int)Random.Range(0, paths.Count)]);
        //    yield return new WaitForSeconds(Random.Range(randomDelayMin, randomDelayMax));

        //} 

        //to block comments hit CTRL + K, CTRL + C
        //to unblock hit CTRL + K, CTRL U


        SpawnEnemy(enemyDefault, paths[(int)Random.Range(0, paths.Count)]);
        yield return new WaitForSeconds(Random.Range(randomDelayMin, randomDelayMax));

        SpawnEnemy(enemyDefault, paths[(int)Random.Range(0, paths.Count)]);
        yield return new WaitForSeconds(Random.Range(randomDelayMin, randomDelayMax));

        SpawnEnemy(enemyDefault, paths[(int)Random.Range(0, paths.Count)]);
        yield return new WaitForSeconds(Random.Range(randomDelayMin, randomDelayMax));

        SpawnEnemy(enemyDefault, paths[(int)Random.Range(0, paths.Count)]);
        yield return new WaitForSeconds(2f);

        SpawnEnemy(enemyHeavy, paths[(int)Random.Range(0, paths.Count)]);
        yield return new WaitForSeconds(Random.Range(randomDelayMin, randomDelayMax));

        SpawnEnemy(enemyHeavy, paths[(int)Random.Range(0, paths.Count)]);
        yield return new WaitForSeconds(Random.Range(randomDelayMin, randomDelayMax));

        SpawnEnemy(enemyDefault, paths[(int)Random.Range(0, paths.Count)]);
        yield return new WaitForSeconds(2f);

        SpawnEnemy(enemyFast, paths[(int)Random.Range(0, paths.Count)]);
        yield return new WaitForSeconds(Random.Range(randomDelayMin, randomDelayMax));




    }







}
