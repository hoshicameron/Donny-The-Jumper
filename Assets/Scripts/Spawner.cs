using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Monsters Prefab")] [SerializeField]
    private List<GameObject> monsterPrefabList;

    [Header("Spawn Positions")]
    [SerializeField] private Transform leftSpawnPosition;
    [SerializeField] private Transform rightSpawnPosition;


    private GameObject spawnedMonster;
    private int randomIndex;
    private int randomSide;
    private float spawnTimer;
    private void Update()
    {
        if (spawnTimer < Time.time)
        {
            randomIndex = Random.Range(0, monsterPrefabList.Count);

            randomSide = (Random.Range(0, 2));

            spawnedMonster =Instantiate(monsterPrefabList[randomIndex], transform.position, Quaternion.identity);
            if (randomSide == 0)
            {
                spawnedMonster.transform.position = leftSpawnPosition.position;
                spawnedMonster.GetComponent<Monster>().Speed = Random.Range(4, 10);
                spawnedMonster.transform.localScale=Vector3.one;

            } else
            {
                spawnedMonster.transform.position = rightSpawnPosition.position;
                spawnedMonster.GetComponent<Monster>().Speed = -Random.Range(4, 10);
                spawnedMonster.transform.localScale=new Vector3(-1,1,1);
            }

            spawnTimer = Time.time + Random.Range(1,5);
        }
    }
}
