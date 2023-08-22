using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix;
using Sirenix.OdinInspector;
using UnityEngine.UI;

public class LevelManager : Singleton<LevelManager>
{
    public StateManager[] levelPrefabs; 
    public int currentLevelIndex = 0; 
    [SerializeField] Transform  player;
    [SerializeField] Transform playerContainer;

    void Start()
    {
        GetUIPrefab();
        // LoadLevel(currentLevelIndex);

    }
    [Button]
    public void LoadCurrentLevel()
    {
        if (currentLevelIndex < levelPrefabs.Length)
        {
            LoadLevel(currentLevelIndex);
        }
        else
        {
            Debug.Log("All levels completed!");
        }
    }
    [Button]
    public void LoadNextLevel()
    {
        currentLevelIndex++;
        if (currentLevelIndex < levelPrefabs.Length)
        {
            LoadLevel(currentLevelIndex);
        }
        else
        {
            Debug.Log("All levels completed!");
        }
    }
    [Button]
    private void LoadLevel(int levelIndex)
    {
        BrickSpawner.Ins.DespawnAll();
        player.gameObject.SetActive(false);
        EnemyManager.Ins.DeActiveEnemy();
        if (levelIndex >= 0 && levelIndex < levelPrefabs.Length)
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
            // StateManager levelInstance = Instantiate(levelPrefabs[levelIndex], transform);
            // levelInstance.transform.position = Vector3.zero;
            StateManager levelInstance = Instantiate(levelPrefabs[levelIndex], transform);
            levelInstance.transform.position = Vector3.zero;
            EnemyManager.Ins.SetTarget(levelInstance.GetFinishPoint());
            StartCoroutine(IESpawn(levelIndex));
        }
        else
        {
            Debug.LogError("Invalid level index!");
        }
    }
    IEnumerator IESpawn( int levelIndex){
        yield return new WaitForSeconds(0.1f);
        player.gameObject.SetActive(true);
        EnemyManager.Ins.ActiveEnemy();
        player.position = playerContainer.position;
    }
    private void GetUIPrefab()
    {
        if (levelPrefabs.Length <= 0)
        {
            levelPrefabs = Resources.LoadAll<StateManager>("Level/");
        }
    }
    
}
