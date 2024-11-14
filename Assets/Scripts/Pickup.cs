using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public bool isClock, isHeal;
    private bool isCollected;
    public GameObject pickupEffect;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isCollected)
        {
            if (isClock)
            {
                LevelManager.instance.clocksCollected++;
                UIController.instance.UpdateClockCount();
                Instantiate(pickupEffect, transform.position, transform.rotation);
                Destroy(gameObject);
            }

            if (isHeal)
            {
                if (PlayerHealthController.instance.currentHealth != PlayerHealthController.instance.maxHealth)
                {
                    PlayerHealthController.instance.HealPlayer();
                    isCollected = true;
                    Destroy(gameObject);
                }
            }
        }
    }
}
