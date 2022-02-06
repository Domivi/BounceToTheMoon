using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; 

public class coinText : MonoBehaviour
{
    private AudioSource source;
    private AudioClip sfx;
    private int score;
    private float animationDuration = 1f;

    void Start()
    {
        Vector3 targetPosition = this.transform.position;
        targetPosition.y += 1f;
        this.GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
        transform.DOMove(targetPosition, animationDuration, false);
        Destroy(gameObject, animationDuration);
    }

    public void Init(Vector3 positionToInstantiate)
    {
        transform.position = positionToInstantiate;
    }
}
