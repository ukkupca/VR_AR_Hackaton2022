using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHandler : MonoBehaviour
{


    public struct Item
    {
        string name;
        Sprite icon;
        float efficiency;


    }

    Item[,] Inventory = new Item[9,4];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
