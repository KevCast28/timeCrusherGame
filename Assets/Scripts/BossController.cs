using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class BossController : MonoBehaviour
{
    public enum bossStates { shooting, hurt, moving, ended };
    public bossStates currentStates;
    public Transform boss;
    public Animator anim;

    [Header("Movement")]
    public float moveSpeed;
    [Header("Directions")]
    public Transform leftPoint, rightPoint;
    private bool moveRight;
    [Header("Shooting")]
    public GameObject bullet;
    public Transform firePoint;
    public float timeBetweenShots;
    private float shotCounter;
    [Header("Hurt")]
    public float hurtTime;
    private float hurtCounter;

    public GameObject hitbox;

    [Header("Health")]
    public int health = 5;
    public GameObject explosion, winPlatform;
    private bool isDefeated;
    public float shotSpeedUp;
    // Start is called before the first frame update
    void Start()
    {
        currentStates = bossStates.shooting;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentStates)
        {
            case bossStates.shooting:

                shotCounter -= Time.deltaTime;
                if (shotCounter <= 0)
                {
                    shotCounter = timeBetweenShots;
                    var newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
                    newBullet.transform.localScale = boss.localScale;
                    AudioManager.instance.PlaySFX(2);
                }
                break;
            case bossStates.hurt:
                if (hurtCounter > 0)
                {
                    hurtCounter -= Time.deltaTime;

                    if (hurtCounter <= 0)
                    {
                        currentStates = bossStates.moving;

                        if (isDefeated)
                        {
                            boss.gameObject.SetActive(false);
                            Instantiate(explosion, transform.position, transform.rotation);

                            winPlatform.SetActive(true);

                            currentStates = bossStates.ended;

                            AudioManager.instance.StopBossMusic();

                        }
                    }
                }
                break;
            case bossStates.moving:

                if (moveRight)
                {
                    boss.position += new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);

                    if (boss.position.x > rightPoint.position.x)
                    {
                        boss.localScale = Vector3.one;

                        moveRight = false;

                        EndMovement();
                    }
                }
                else
                {
                    boss.position -= new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);

                    if (boss.position.x < leftPoint.position.x)
                    {
                        boss.localScale = new Vector3(-1f, 1f, 1f);

                        moveRight = true;

                        EndMovement();
                    }
                }

                break;
        }
    }

    public void TakeHit()
    {
        currentStates = bossStates.hurt;
        hurtCounter = hurtTime;

        anim.SetTrigger("Hit");

        health--;

        if (health <= 0)
        {
            isDefeated = true;
        }
        else
        {
            timeBetweenShots /= shotSpeedUp;
            //shotCounter = timeBetweenShots;
        }
    }

    private void EndMovement()
    {
        currentStates = bossStates.shooting;
        shotCounter = timeBetweenShots;

        anim.SetTrigger("StopMoving");

        hitbox.SetActive(true);
    }
}