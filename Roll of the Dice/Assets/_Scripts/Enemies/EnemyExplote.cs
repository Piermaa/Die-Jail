using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyExplote : MonoBehaviour
{
    [SerializeField] private float vida;

    [SerializeField] private GameObject player;

    [SerializeField] private GameObject explode;

    [SerializeField] ParticleSystem explodeParticle;

    private SoundManager soundManager;

    Animator animator;

    public float timeToExplode;
    public float power;
    public float radius;
    public float upForce;

    NavMeshAgent agent;

    public float daño;

    private Transform playerPosition;
    public void Awake()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }

    public void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerPosition = player.GetComponent<Transform>();
    }

    public void Update()
    {
        agent.SetDestination(playerPosition.position);
    }


    public void TomarDaño(float daño)
    {
        vida -= daño;

        if (vida <= 0)
        {
            Muerte();
        }
    }

    private void Muerte()
    {
        Destroy(gameObject);
    }

    IEnumerator DelayExplosion()
    {
        agent.speed = 0;
        animator.SetTrigger("Explode");

        yield return new WaitForSeconds(0.5f);

        explodeParticle.Play();
        soundManager.SeleccionarAudio(2, 0.75f);

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null && rb.gameObject.tag == "Player")
            {
                rb.AddExplosionForce(power, transform.position, radius, upForce);


                GameObject.Find("Player").GetComponent<HealthController>().TomarDañoPlayer(daño);
                print("ME DUELE");
            }
        }
       
        yield return new WaitForSeconds(1);

        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine("DelayExplosion");
            
        }
    }
}
