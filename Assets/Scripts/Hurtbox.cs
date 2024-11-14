using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hurtbox : MonoBehaviour
{
    public GameObject deathEffect;
    [Range(0, 100)] public float chancheToDrop;
    public GameObject collectible;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            other.transform.parent.gameObject.SetActive(false);
            Instantiate(deathEffect, other.transform.position, other.transform.rotation);
            PlayerController.instance.Bounce();
            float dropSelect = Random.Range(0f, 100f);

            AudioManager.instance.PlaySFX(3);

            if (dropSelect <= chancheToDrop)
            {
                Instantiate(collectible, other.transform.position, other.transform.rotation);
            }
        }
    }
}
