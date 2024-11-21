using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossActivator : MonoBehaviour
{
    public GameObject bossBattle;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            bossBattle.SetActive(true);
            gameObject.SetActive(false);

            AudioManager.instance.PlayBossMusic();
        }
    }
}
