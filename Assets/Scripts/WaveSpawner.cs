using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private List<Enemy> enemyList;
    [SerializeField] private Renderer spawnArea;
    [SerializeField] private int numberOfEnemiesThisWave = 10;
    [SerializeField] private int maxNumberOfEnemiesOnScreen = 5;
    [SerializeField] private float timeBetweenSpawn = 2f;

    private LevelManager levelManager;
    
    private Bounds bounds;
    private int kindsOfEnemies;
    private int numberOfEnemiesOnScreen = 0;
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        bounds = spawnArea.bounds;
        kindsOfEnemies = enemyList.Count;
        StartCoroutine(SpawnEnemies());
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

    //called when enemy dead
    public void OneLessEnemyOnScreen()
    {
        numberOfEnemiesOnScreen--;
    }

    IEnumerator SpawnEnemies()
    {
        while (numberOfEnemiesThisWave > 0) // loop until all enemies spawned
        {
            if (numberOfEnemiesOnScreen < maxNumberOfEnemiesOnScreen) // control number of enemies on screen
            {
                Vector2 newLocation = new Vector2(Random.Range(bounds.max.x, bounds.min.x), Random.Range(bounds.max.y, bounds.min.y));
                Enemy thisThing = Instantiate(enemyList[Random.Range(0, kindsOfEnemies)], newLocation, new Quaternion());
                Renderer rendererOfThis = thisThing.GetComponent<Renderer>();
                rendererOfThis.sortingOrder = numberOfEnemiesThisWave; // each enemy should have unique render order in layer
                GameManager.instance.OnEnemySpawnParticle(new Vector3(newLocation.x, rendererOfThis.bounds.min.y));
                numberOfEnemiesThisWave--;
                numberOfEnemiesOnScreen++;
            }
            yield return new WaitForSeconds(timeBetweenSpawn);
        }

        
    }
    
    public void clearAllEnemiesCheck()
    {
        if(numberOfEnemiesThisWave == 0 && numberOfEnemiesOnScreen == 0)
        {
            ScoreManager.instance.Win();
            levelManager.LoadGameOverScene();
        }
    }

}
