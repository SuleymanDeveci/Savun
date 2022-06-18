using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerMovement : MonoBehaviour
{

    public enemyScript enemySc;
    public healthBar healthBarO;
    public GameObject hb;
    public GameObject playerMerkez;
    public Joystick joystick;
    public TextMeshProUGUI txt;

  
    

    public float moveSpeed = 5f;
    
    
    public int maxHealth = 100;
    public int currentHealth;

   
    public Vector2 movement;
    public Vector2 ittirmeKuvveti;
    





    public Quaternion fliperPlayer;
    public Quaternion fliperHealtBar;


    Rigidbody2D rb;
    Animator anim;

    private float[] frameDeltaTimeArray;
    private int lastFrameIndex;


    private void Awake()
    {
        frameDeltaTimeArray = new float[50];
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
        healthBarO.SetMaxHealth(maxHealth);

        


    }

    void Update()
    {

        movement.x = Input.GetAxis("Horizontal") + joystick.Horizontal;
        movement.y = Input.GetAxis("Vertical") + joystick.Vertical;


        Movement();
        Animation();

        frameDeltaTimeArray[lastFrameIndex] = Time.deltaTime;
        lastFrameIndex = (lastFrameIndex + 1) % frameDeltaTimeArray.Length;


        txt.text = Mathf.RoundToInt(CalculateFPS()).ToString();



        
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        

        

    }

    private float CalculateFPS()
    {
        float total = 0f;
        foreach(float deltaTime in frameDeltaTimeArray)
        {
            total += deltaTime;
        }
        return frameDeltaTimeArray.Length / total;
    }

    private void Movement()
    {
        if (movement.x >= 0.7 && movement.y >= 0.7)
        {
            movement.x = 0.7f;
            movement.y = 0.7f;

        }
        else if (movement.x >= 0.7 && movement.y <= -0.7)
        {
            movement.x = 0.7f;
            movement.y = -0.7f;

        }
        else if (movement.x <= -0.7 && movement.y >= 0.7)
        {
            movement.x = -0.7f;
            movement.y = 0.7f;

        }
        else if (movement.x <= -0.7 && movement.y <= -0.7)
        {
            movement.x = -0.7f;
            movement.y = -0.7f;

        }
        
        if(movement.x > 0.01)
        {


            fliperPlayer.eulerAngles = new Vector3(0,180,0);
            transform.rotation = fliperPlayer;

            fliperHealtBar.eulerAngles = new Vector3(0, 0, 0);
            hb.transform.rotation = fliperHealtBar;


            
            
        }
        else if(movement.x < -0.01)
        {

            fliperPlayer.eulerAngles = new Vector3(0, 0, 0);
            transform.rotation = fliperPlayer;

            fliperHealtBar.eulerAngles = new Vector3(0, 0, 0);
            hb.transform.rotation = fliperHealtBar;



        }
        


    }

    private void Animation()
    {
        if (movement.x > 0.1 || movement.y > 0.1 || movement.x < -0.1 || movement.y < -0.1)
        {
            anim.SetBool("isMoving", true);

            anim.SetFloat("xSpeed", movement.x);
            anim.SetFloat("ySpeed", movement.y);

            if (Mathf.Abs(movement.x) > Mathf.Abs(movement.y))
            {
                anim.speed = Mathf.Abs(movement.x);
            }
            else
            {
                anim.speed = Mathf.Abs(movement.y);
            }


        }
        else
        {
            anim.SetBool("isMoving", false);
            anim.speed = 1;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBarO.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            //Die();
            
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "enemy")
        {
            enemySc = collision.gameObject.GetComponent<enemyScript>();

            TakeDamage(enemySc.hasar);

            Rigidbody2D rbEnemy = collision.gameObject.GetComponent<Rigidbody2D>();

            ittirmeKuvveti = (playerMerkez.transform.position - collision.transform.position) * -70;

            

            rbEnemy.AddForce(ittirmeKuvveti, ForceMode2D.Impulse);
            //rbEnemy.AddForceAtPosition(ittirmeKuvveti, transform.position);


            
            
        }
        
    }

    

}
