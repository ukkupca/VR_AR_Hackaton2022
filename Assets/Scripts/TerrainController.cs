using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainController : MonoBehaviour
{
    public Terrain terrain = default;
    public List<GameObject> treeColliders = new List<GameObject>();

    void Start()
    {
        foreach (TreeInstance treeInstance in terrain.terrainData.treeInstances)
        {
            GameObject treeCollider = new GameObject();
            treeCollider.transform.position = treeInstance.position;

            treeCollider.AddComponent<CapsuleCollider>();
            treeCollider.GetComponent<CapsuleCollider>().height = 5f;

            treeCollider.AddComponent<TreeController>();
        }
    }

    void Update()
    {
        
    }
}
