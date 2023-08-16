using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{

    [SerializeField] List<Transform> pointSpawn;
    public List<Transform> PointSpawn { get { return pointSpawn; } }
    
    [SerializeField] List<Transform> bricks;
    public List<Transform> Bricks { get { return bricks; } set { bricks = value; } }

    public void SpawnFirstBrick(ColorSkin colorSkin){
        foreach(Transform point in pointSpawn[(int)(colorSkin)]){
            Transform newBrick = BrickSpawner.Instance.Spawn(colorSkin);
            newBrick.SetPositionAndRotation(point.position, point.rotation);
            bricks.Add(newBrick);
        }
    }
    public void SpawnSecondBrick(ColorSkin colorSkin){
        Transform newBrick = BrickSpawner.Instance.Spawn(colorSkin);
    }
}
