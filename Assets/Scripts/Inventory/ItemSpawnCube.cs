using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnCube : ItemComponent
{
    // Unity is giving me errors about FindObjectsOfType.
    // It asked to throw it in an awake or start method, but that caused a bunch of other errors.
    // Commenting out the line seems to fix it.
    // No isses as a result of this have occured yet. Also, it shouldn't because this player was never used.
    //private Player player = GameObject.FindObjectOfType<Player>();
    public GameObject itemPrefab;

    private void Awake()
    {
        //throw new NotImplementedException();
        //private Player player = GameObject.FindObjectOfType<Player>();
    }

    public override void Use()
    {
        Instantiate(itemPrefab, new Vector3(0, 0, 10), Quaternion.identity);
    }
}