using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    public Animator anim;

    public Collider2D colliderA; // d��man�n colider� (colider� ayr� olarak almak istedim ��nk� d��man �ld�kten sonra, d��man objesini hemen yok edemem ��nk� �l�m animasyonu oynuyor
                                 // bu y�zden d��man �ld��� anda colider� yok edece�im bu sayede �l�m animasyonu oynayan d��mana tak�lmayaca��m.

    public bullet bulletSc;
    public healthBar healthBarO;

    public GameObject minimapicon;
    public GameObject playerCenter;

    public Vector3 targetVector;
    public Vector3 currentVector;
 
    public float speed;

    public int maxHealth = 100;
    public int currentHealth;
    public int hasar = 15;

    public bool isDead = false;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBarO.SetMaxHealth(maxHealth);
    }


    void Update()
    {
        if(isDead == false)
        {
            Move();
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBarO.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        anim.SetTrigger("dieTrigger");

        Destroy(colliderA);
        Destroy(healthBarO.gameObject);
        Destroy(minimapicon);

        StartCoroutine(bekle()); // �len d��man� yok etmek i�in �l�m animasyonunun tamamlanmas�n� bekliyorum
    }

    private void Move()
    {
        currentVector = transform.position;
        targetVector = playerCenter.transform.position;
        transform.position = Vector3.MoveTowards(currentVector, targetVector, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "bullet")
        {
            bulletSc = collision.gameObject.GetComponent<bullet>();
            TakeDamage(bulletSc.hasar);
            Destroy(collision);
        }
    }

    IEnumerator bekle()
    {
        //Beklemeden �nce 

        yield return new WaitForSecondsRealtime(9.5f); //Beklenecek zaman
        Destroy(gameObject);

        //Beklemeden sonra
    }
}
