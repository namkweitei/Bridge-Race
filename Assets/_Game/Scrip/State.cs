using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{

    [SerializeField] List<Transform> pointSpawn;
    public List<Transform> PointSpawn { get { return pointSpawn; } }
    
    [SerializeField] List<EdibleBlock> bricks;
    public List<EdibleBlock> Bricks { get { return bricks; } set { bricks = value; } }
    [SerializeField] Transform door;
    public Transform Door { get { return door;} set { door = value; } }
    public void SpawnFirstBrick(ColorSkin colorSkin){
        foreach(Transform point in pointSpawn[(int)(colorSkin)]){
            EdibleBlock newBrick = BrickSpawner.Ins.Spawn(colorSkin).GetComponent<EdibleBlock>();
            newBrick.transform.SetPositionAndRotation(point.position, point.rotation);
            bricks.Add(newBrick);
        }
    }
    public void SpawnSecondBrick(ColorSkin colorSkin){
        Transform newBrick = BrickSpawner.Ins.Spawn(colorSkin);
    }
    public void Shuffle()
    {
        Bricks = Utilities.SortOrder(Bricks, Bricks.Count);
    }
}
