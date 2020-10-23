using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{  

    public GameObject[] platformPrefabs;


    public int numberOfPlatforms = 200;
    public float levelWidth = 3f;
    public float minY = .2f;
    public float maxY = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 spawnPosition = new Vector3();
  
        for(int i=0; i<numberOfPlatforms; i++){
            spawnPosition.y += Random.Range(minY, maxY);
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);
            Debug.Log(Random.Range(0, platformPrefabs.Length));
            Instantiate(platformPrefabs[0], spawnPosition, Quaternion.identity);
            if(i%4 ==0)
                Instantiate(platformPrefabs[1], spawnPosition * Random.Range(0, platformPrefabs.Length), Quaternion.identity);
            if(i%30 == 0)
                Instantiate(platformPrefabs[2], spawnPosition * Random.Range(0, platformPrefabs.Length), Quaternion.identity);
        }   
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
