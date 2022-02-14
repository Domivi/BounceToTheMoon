using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] private Vector2 force = new Vector2(0f, 1100f);
    // [SerializeField] private ParticleSystem moonParticles; 
    // [SerializeField] private ParticleSystem starParticles;
    // [SerializeField] private AudioSource audioSource;     

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Player") && (col.gameObject.GetComponent<Player>().rb.velocity.y > 0)) return;
        col.gameObject.GetComponent<Player>().rb.AddForce(force);
        // audioSource.Play();
        // moonParticles.Emit(5);
        // starParticles.Emit(3);
    }
    
}


