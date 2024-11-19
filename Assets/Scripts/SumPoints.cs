using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SumPoints : MonoBehaviour
{
    public int pointsToAdd;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GameManager.instance.AddPoints(pointsToAdd);
            Destroy(gameObject);
        }
    }
}
