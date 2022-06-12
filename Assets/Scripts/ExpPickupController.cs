using Data.Scripts;
using UnityEngine;

public class ExpPickupController : MonoBehaviour
{
    private int expReward = 1;

    private void OnCollisionEnter(Collision collision)
    {
        Tomogochi tamagochi = GameObject.Find("Tomogochi").GetComponent<Tomogochi>();
        tamagochi.AddExp(expReward);

        Destroy(gameObject);
    }
}
