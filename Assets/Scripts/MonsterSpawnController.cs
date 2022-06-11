using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawnController : MonoBehaviour
{
    private int mobsPerZone = 20;
    public List<GameObject> monsterPrefabs = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < mobsPerZone; j++)
            {
                Vector3 spawnPos = new Vector3(0f, 1f, 0f) + RandomPointOnSphereEdge(i * 100, (i + 1) * 100);
                GameObject spawnedMob = Instantiate(monsterPrefabs[Random.Range(0, monsterPrefabs.Count)], spawnPos, Quaternion.identity);
                spawnedMob.GetComponent<Wolfy>().player = GameObject.Find("Player");
            }
        }
    }

    public static Vector3 RandomPointOnSphereEdge(float minRadius, float maxRadius)
    {
        var vector3 = Random.insideUnitSphere.normalized;
        var randomDistance = Random.Range(minRadius, maxRadius);
        return new Vector3(vector3.x, 0f, vector3.z) * randomDistance;
    }
}
