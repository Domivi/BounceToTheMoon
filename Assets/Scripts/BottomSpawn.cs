using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomSpawn : MonoBehaviour
{
    [SerializeField] private bool colliderTouchedOnce = false;
    void OnTriggerEnter2D(Collider2D col)
    {
        if(!colliderTouchedOnce)
        {
            colliderTouchedOnce = true;
            LevelSetup.singleton.GenerateLevel();
        }
    }

    // void Update()
    // {
    //     Debug.Log(colliderTouchedOnce);
    // }
}
