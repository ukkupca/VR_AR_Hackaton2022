using System.Collections.Generic;
using UnityEngine;

public class TerrainController : MonoBehaviour
{
    private float capsuleColliderHeight = 5f;
    public Terrain terrain = default;
    public List<GameObject> treeColliders = new List<GameObject>();
    public GameObject foodPrefab = default;

    void Start()
    {
        foreach (TreeInstance treeInstance in terrain.terrainData.treeInstances)
        {
            GameObject treeCollider = new GameObject();
            treeCollider.transform.position =
                new Vector3(treeInstance.position.x * terrain.terrainData.size.x - terrain.terrainData.size.x / 2,
                            treeInstance.position.y + capsuleColliderHeight / 2,
                            treeInstance.position.z * terrain.terrainData.size.z - terrain.terrainData.size.z / 2);

            treeCollider.AddComponent<CapsuleCollider>();
            treeCollider.GetComponent<CapsuleCollider>().height = capsuleColliderHeight;

            treeCollider.AddComponent<TreeController>();
            treeCollider.GetComponent<TreeController>().foodPrefab = foodPrefab;
        }
    }
}
