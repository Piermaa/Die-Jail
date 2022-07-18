using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Target : MonoBehaviour{
    public int score;
    public bool boss;
    [SerializeField] GameObject realBody;
    [SerializeField] Animator animator;
    public float health = 50f;
    [SerializeField] SpriteRenderer sprite;

    private SoundManager soundManager;

    public void Awake()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }

    private void Start()
    {
        if (animator == null)
        {
            TryGetComponent<Animator>(out animator);
        } 
    }

    IEnumerator SpriteAffected()
    {
           //sprite.color = new Color(255, 0, 0);
        yield return new WaitForSeconds(0.2f);
        //sprite.color = new Color(255, 255, 255);
    }
    public void TakeDamage (float amount) {
        health -= amount;
        if (animator != null)
        {
            soundManager.SeleccionarAudio(0, 0.5f);
            animator.SetTrigger("TakeDamage");
        }
        
        StartCoroutine(SpriteAffected());
        if (health <= 0f) 
        {
            soundManager.SeleccionarAudio(1, 1f);
            Die();
        }
    }

    void Die() {

        __ScoreManager scoreManager = FindObjectOfType<__ScoreManager>();

        scoreManager.AddScore(score);

        if (boss)
        {
            Destroy(realBody);
        }
        Destroy(gameObject);
    }
}
