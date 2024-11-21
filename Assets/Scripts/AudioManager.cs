using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource[] soundEffects;
    public AudioSource bossMusic, levelMusic;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlaySFX(int soundToPlay)
    {
        soundEffects[soundToPlay].Stop();

        soundEffects[soundToPlay].pitch = Random.Range(0.9f, 1.1f);

        soundEffects[soundToPlay].Play();
    }

    public void PlayBossMusic()
    {
        bossMusic.Play();
        levelMusic.Stop();
    }

    public void StopBossMusic()
    {
        bossMusic.Stop();
        levelMusic.Play();
    }
}
