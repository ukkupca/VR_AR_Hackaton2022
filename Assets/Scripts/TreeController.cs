using System;
using UnityEngine;

public class TreeController : MonoBehaviour
{
    public Guid guid = default;

    void Start()
    {
        guid = Guid.NewGuid();
    }
}
