using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private List<Enemy> enemyList;
    [SerializeField] private Renderer spawnArea;
    [SerializeField] private int maxEnemies = 10;
    [SerializeField] private int maxNumberOfEnemiesOnScreen = 5;
    [SerializeField] private float timeBetweenSpawn = 2f;
    [SerializeField] private Transform spawnedEnemies;

    private LevelManager levelManager;
    private Bounds bounds;
    private int kindsOfEnemies;
    private int numberOfEnemiesOnScreen = 0;
    private int enemiesLeft;
    
  
    
    public void Reset()
    {
        enemiesLeft = maxEnemies;
        numberOfEnemiesOnScreen = 0;
        DestroyAllEnemies();
    }
    
    //reset all numbers when replay;
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        bounds = spawnArea.bounds;
        kindsOfEnemies = enemyList.Count;
    }

    // Update is called once per frame
    void Update()
    {
        clearAllEnemiesCheck();
    }

    private void GetBoundCords()
    {
        Debug.Log(spawnArea.bounds.max);
        Debug.Log(spawnArea.bounds.min);
    }

    public void StartSpawning()
    {
        Reset();
        StartCoroutine(SpawnEnemies());
        
    }
    //called when enemy dead
    public void OneLessEnemyOnScreen()
    {
        numberOfEnemiesOnScreen--;
    }

    IEnumerator SpawnEnemies()
    {
        while (enemiesLeft > 0) // loop until all enemies spawned
        {
            
            if (numberOfEnemiesOnScreen < maxNumberOfEnemiesOnScreen) // control number of enemies on screen
            {
                Vector2 newLocation = new Vector2(Random.Range(bounds.max.x, bounds.min.x), Random.Range(bounds.max.y, bounds.min.y));
                Enemy thisThing = Instantiate(enemyList[Random.Range(0, kindsOfEnemies)], newLocation, new Quaternion(), spawnedEnemies);
                Renderer rendererOfThis = thisThing.GetComponent<Renderer>();
                rendererOfThis.sortingOrder = enemiesLeft; // each enemy should have unique render order in layer
                GameManager.instance.OnEnemySpawnParticle(new Vector3(newLocation.x, rendererOfThis.bounds.min.y));
                enemiesLeft--;
                numberOfEnemiesOnScreen++;
            }
            yield return new WaitForSeconds(timeBetweenSpawn);
        }

        
    }
    private void DestroyAllEnemies()
    {
        foreach (Transform child in spawnedEnemies)
        {
            Destroy(child.gameObject);
        }
    }
    
    public void clearAllEnemiesCheck()
    {
        if (!GameManager.instance.IsGameActive()) return;
        if(enemiesLeft == 0 && numberOfEnemiesOnScreen == 0)
        {
            ScoreManager.instance.Win();
            GameManager.instance.EndGame();
           
            //levelManager.LoadGameOverScene();
        }
    }

}
