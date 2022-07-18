using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoll : MonoBehaviour
{
    [SerializeField] GameObject boss;
    bool bossFight;

    [SerializeField] AudioClip bossc;

    [SerializeField] AudioSource bossm;
    public int waves;

    AudioSource diceSound;


    float timeBetweenWaves=20;
    float nextWave=10;

    float searchCooldown;

    public GameObject[] enemies;

    public Transform[] spawnPosition;

    Collider boxCollider;

    Animator animator;



    int rollDice;
    int aux;


    private void Start()
    {
        diceSound = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<Collider>();

    }

    private void Update()
    {
        if(!bossFight)
        {
            searchCooldown -= Time.deltaTime;

            if (searchCooldown < 0)
            {
                searchCooldown = 1;
                if (GameObject.FindGameObjectsWithTag("Enemy").Length <= 0)
                {
                    nextWave = timeBetweenWaves;
                }
            }

            nextWave += Time.deltaTime;
            if (!(waves > 0) && nextWave > timeBetweenWaves)
            {
                RotateDice();
            }
            else
            {
                if (nextWave > timeBetweenWaves)
                {
                    nextWave = 0;
                    waves--;
                    Spawn(rollDice);
                }

            }
        }
    }
    public void RotateDice()
    {
        while (rollDice == aux)
        {
            rollDice = Random.Range(1, 7);
        }
        diceSound.Play();

        waves += Random.Range(1, 3);

        aux = rollDice;
        print(rollDice);
        animator.SetTrigger(rollDice.ToString());
    }

    public void SpawnBoss()
    {
        bossm.clip = bossc;

        bossm.Play();
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            enemy.SetActive(false);
        }
        bossFight = true;
        boss.SetActive(true);
    }
    void Spawn(int side)
    {
        switch (side)
        {
            case 1:
                Instantiate(enemies[Random.Range(0,enemies.Length)], spawnPosition[0].position, spawnPosition[0].rotation);
                break;

            case 2:
                Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPosition[1].position, spawnPosition[1].rotation);
                Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPosition[2].position, spawnPosition[2].rotation);
                break;

            case 3:
                Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPosition[0].position, spawnPosition[0].rotation);
                Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPosition[3].position, spawnPosition[3].rotation);
                Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPosition[4].position, spawnPosition[4].rotation);
                break;

            case 4:
                Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPosition[1].position, spawnPosition[1].rotation);
                Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPosition[2].position, spawnPosition[2].rotation);
                Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPosition[3].position, spawnPosition[3].rotation);
                Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPosition[4].position, spawnPosition[4].rotation);
                break;

            case 5:
                Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPosition[0].position, spawnPosition[0].rotation);
                Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPosition[1].position, spawnPosition[1].rotation);
                Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPosition[2].position, spawnPosition[2].rotation);
                Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPosition[3].position, spawnPosition[3].rotation);
                Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPosition[4].position, spawnPosition[4].rotation);
                break;

            case 6:
                Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPosition[1].position, spawnPosition[1].rotation);
                Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPosition[2].position, spawnPosition[2].rotation);
                Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPosition[3].position, spawnPosition[3].rotation);
                Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPosition[4].position, spawnPosition[4].rotation);
                Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPosition[5].position, spawnPosition[5].rotation);
                Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPosition[6].position, spawnPosition[6].rotation);
                break;
        }


    }

    void RollDice()
    {
        print("Roll");
        int rollDice = Random.Range(1, 5);

        switch (rollDice)
        {
            case 1:
                //transform.RotateAround(boxCollider.bounds.center, new Vector3(0, 90, 0), 90);
                animator.SetTrigger("Left");
                break;

            case 2:
                //transform.RotateAround(boxCollider.bounds.center, new Vector3(0, 90, 0), -90);
                animator.SetTrigger("Front");
                break;

            case 3:
                //transform.RotateAround(boxCollider.bounds.center, new Vector3(90, 0, 0), 90);
                animator.SetTrigger("Right");
                break;

            case 4:
                //transform.RotateAround(boxCollider.bounds.center, new Vector3(90, 0, 0), -90);
                animator.SetTrigger("Back");
                break;
        }
    }
}
