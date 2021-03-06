using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterPaddle : MonoBehaviour
{

    [SerializeField] private Vector2 force = new Vector2(0f, 1100f);
    [SerializeField] private ParticleSystem moonParticles; 
    [SerializeField] private ParticleSystem starParticles;
    [SerializeField] private AudioSource sfx;     
    private float boostReductionMultiplier = 0.9f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        
        if(!col.gameObject.CompareTag("Player")) return; 
        if(col.relativeVelocity.y > 0)
        {
            col.gameObject.GetComponent<Player>().rb.AddForce(force * boostReductionMultiplier);
        } 
        else 
        {
            col.gameObject.GetComponent<Player>().rb.AddForce(force);
        }
        
    }

    
}

