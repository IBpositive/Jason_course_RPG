using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnCube : ItemComponent
{
    private Player player = GameObject.FindObjectOfType<Player>();
    public GameObject itemPrefab;
    
    public override void Use()
    {
        Instantiate(itemPrefab, new Vector3(0, 0, 10), Quaternion.identity);
    }
}