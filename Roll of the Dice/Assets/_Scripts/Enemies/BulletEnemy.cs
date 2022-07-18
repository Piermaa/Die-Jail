using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    [SerializeField] private float velocidad;

    [SerializeField] private float daño;

    Transform player;

    float fixCooldown;


    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * velocidad * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("AA ME DUELE");
            other.GetComponent<HealthController>().TomarDañoPlayer(daño);

            gameObject.SetActive(false);
            
        }
    }
}