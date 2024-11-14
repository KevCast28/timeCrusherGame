using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public SpriteRenderer sr;

    public Sprite cpOn, cpOff;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CheckpointController.instance.DeactivateCheckpoints();
            sr.sprite = cpOn;
            CheckpointController.instance.SetSpawnPoint(transform.position);
        }
    }

    public void ResetCheckpoint()
    {
        sr.sprite = cpOff;
    }
}
