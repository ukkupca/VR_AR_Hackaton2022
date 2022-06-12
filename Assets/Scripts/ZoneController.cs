using Data.Scripts;
using UnityEngine;

public class ZoneController : MonoBehaviour
{
    private readonly int numberOfZones = 5;
    private int[] zoneRadiuses = new int[6];
    private bool[] zoneUnlocked = new bool[6];
    public Tomogochi tomogochi = default;
    public GameObject barrier = default;

    void Start()
    {
        zoneRadiuses[0] = 100;
        zoneRadiuses[1] = 200;
        zoneRadiuses[2] = 300;
        zoneRadiuses[3] = 400;
        zoneRadiuses[4] = 500;
        zoneRadiuses[5] = 600;
    }

    void Update()
    {
        if (tomogochi != null)
        {
            for (int i = 0; i < numberOfZones; i++)
            {
                if (tomogochi.LEVEL - 1 >= i)
                {
                    zoneUnlocked[i] = true;
                    barrier.transform.position = new Vector3(barrier.transform.position.x, zoneRadiuses[i], barrier.transform.position.z);
                    barrier.transform.localScale = new Vector3(zoneRadiuses[i], zoneRadiuses[i], zoneRadiuses[i]);
                }
            }
        }
    }
}
