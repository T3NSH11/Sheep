using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class RandomSheepSpawner : EditorWindow
{
    float numberToSpawn = 1f;
    GameObject Sheep;
    float spawnRadius;
    int maxSheepSize;
    [MenuItem("Leens Tools/Sheep spawner")]
    

    public static void ShowWindow()
    {
        GetWindow(typeof(RandomSheepSpawner));

    }
    private void OnGUI()
    {
        GUILayout.Label("Spawn Random Sheep", EditorStyles.boldLabel);
        numberToSpawn = EditorGUILayout.FloatField("Number to spawn", numberToSpawn);
        Sheep = EditorGUILayout.ObjectField("Sheep prefab", Sheep, typeof(GameObject), false) as GameObject;
        spawnRadius = EditorGUILayout.FloatField("Spawn Radius", spawnRadius);
        if (GUILayout.Button("Spawn Object")) 
        {
            SpawnSheep();
        }

        
       

    }

    void SpawnSheep()
    {

        Vector2 spawnCircle = Random.insideUnitCircle * spawnRadius;
        Vector3 SpawnPosition = new Vector3(spawnCircle.x, 0f, spawnCircle.y);

        GameObject gameObject = Instantiate(Sheep, SpawnPosition, Quaternion.identity);
   
    }











}
