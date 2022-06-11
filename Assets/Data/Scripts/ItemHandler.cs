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
        float count;
        bool isCraftable;
        int element; // 0- Earth 1-Ice 2-Fire 3-Wind
    }

    Item[] Items = new Item[30];

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
