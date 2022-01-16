using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coords : MonoBehaviour
{

    [SerializeField] public static Transform top;
    [SerializeField] public static Transform bottom;
    [SerializeField] public static Transform left;
    [SerializeField] public static Transform right;
    
    void Start()
    {
        bottom = this.transform.GetChild(0);
        top = this.transform.GetChild(1);
        left = this.transform.GetChild(2);
        right = this.transform.GetChild(3);
    }
}
