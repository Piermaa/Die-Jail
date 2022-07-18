using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Katana : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Attack");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            print("enemyHitted");
        }
        Target target;
        other.TryGetComponent<Target>(out target);
        if(target!=null)
        {
            print("DamagingEnemy");
            target.TakeDamage(10);
        }
    }

}
