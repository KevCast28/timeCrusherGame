using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killzone : MonoBehaviour
{
    public GameObject deathEffect;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Instantiate(deathEffect, PlayerController.instance.transform.position, PlayerController.instance.transform.rotation);

            AudioManager.instance.PlaySFX(8);

            LevelManager.instance.RespawnPlayer();
        }
    }
}
