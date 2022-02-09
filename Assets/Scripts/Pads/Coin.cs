using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] GameObject coinText;
    [SerializeField] float scoreToGive = 500f;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            GameManager.instance.AddCoinScore(scoreToGive);
            var text = Instantiate(coinText, this.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
