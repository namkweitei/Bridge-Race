using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : Singleton<EnemyManager>
{
   [SerializeField] Enemy enemyPrefabs;
   [SerializeField] List<Enemy> enemy;
   [SerializeField] List<ColorSkin> colorSkins;
   public void OnInit(){
        for(int i = 0; i < colorSkins.Count; i++){
            Enemy newEnemy = Instantiate(enemyPrefabs, new Vector3(i-1,1,-1), Quaternion.identity);
            newEnemy.ChangeColor(colorSkins[i]);
            newEnemy.gameObject.SetActive(false);
            enemy.Add(newEnemy);
        }
   }
    public void ActiveEnemy(){
        for(int i = 0; i < enemy.Count; i++){
            enemy[i].transform.position = new Vector3(i-1,1,-1);
            enemy[i].gameObject.SetActive(true);
            enemy[i].OnInit();
        }
    }
    public void DeActiveEnemy(){
        for(int i = 0; i < enemy.Count; i++){
            enemy[i].gameObject.SetActive(false);
            enemy[i].ClearBrick();
        }
    }
    public void SetTarget(Transform target){
        for(int i = 0; i < enemy.Count; i++){
            enemy[i].finishTarget = target;
        }
    }
}