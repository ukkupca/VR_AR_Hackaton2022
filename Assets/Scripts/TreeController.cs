using System;
using UnityEngine;

public class TreeController : MonoBehaviour
{
    public Guid guid = default;
    public GameObject foodPrefab = default;

    void Start()
    {
        guid = Guid.NewGuid();
    }

    public void DropFood()
    {
        GameObject droppedFood = Instantiate(foodPrefab, transform);
    }

    private void OnCollisionEnter(Collision collision)
    {
        DropFood();
    }
}
