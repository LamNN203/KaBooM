using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class controller : MonoBehaviour
{
    PlayerController controls;
    float direction = 0;
    public float ydirection = 0;
    public float Jumpforce = 0;
    public float speed;
    public float attackDash = 0;
    public State state = State.idle;
    public LayerMask ground;
    public bool doubleJump;
    public float Dustrate;
    public float HurtDelay;
    private float timer;
    private float hurttimer;
    public float Hurtforce = 0;
    public bool isAttacking = false;
    public static controller instance;
    public int tempCoins;

    public Rigidbody2D rg;
    public CapsuleCollider2D boxcl;
    public Animator anim;
    public GameObject Dustparticle;
    public GameObject JumpParticle;
    public GameObject FallParticle;
    public PlayerHealthManager HealthManager;
    public PlayerCoinsManager CoinsManager;
    public coinBehaviour CoinsBehaviour;

    public enum State { idle, running, jumping, falling, hurt, doubleJump }

    private void Awake()
    {
        //Get component
        instance = this;
        rg = GetComponent<Rigidbody2D>();
        boxcl = GetComponent<CapsuleCollider2D>();
        anim = GetComponent<Animator>();
        HealthManager = FindObjectOfType<PlayerHealthManager>();
        CoinsManager = FindObjectOfType<PlayerCoinsManager>();
        CoinsBehaviour = FindObjectOfType<coinBehaviour>();

        //Input system

        controls = new PlayerController();
        controls.Enable();

        controls.Land.Move.performed += ctx =>
        {
            direction = ctx.ReadValue<float>();
        };
        controls.Land.Jump.performed += ctx => Jump();
        controls.Land.AttackG.performed += ctx => Attack();

    }

    private void AttackG_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        throw new System.NotImplementedException();
    }

    void Start()
    {

    }

    private void FixedUpdate()
    {
        hurttimer = hurttimer + Time.deltaTime;
        if (state != State.hurt)
        {
            Movee();
        }
        Animation();
        anim.SetInteger("state", (int)state);
    }
    private void Update()
    {
        
    }
    public void Movee()
    {
        rg.velocity = new Vector2(direction * speed * Time.deltaTime, rg.velocity.y);
        if (direction < 0)
        {
            transform.localScale = new Vector2(-1, 1);
            if (timer < Dustrate)
            {
                timer = timer + Time.deltaTime;
            }
            else
            {
                if (state == State.running)
                {
                    Instantiate(Dustparticle, new Vector3(transform.position.x, transform.position.y - 0.08f, 0), transform.rotation);
                    Dustparticle.transform.localScale = new Vector3(-1, 1, 0);
                    timer = 0;
                }
            }
        }
        //Moving Right
        else if (direction > 0)
        {
            transform.localScale = new Vector2(1, 1);
            if (timer < Dustrate)
            {
                timer = timer + Time.deltaTime;
            }
            else
            {
                if (state == State.running)
                {
                    Instantiate(Dustparticle, new Vector3(transform.position.x, transform.position.y - 0.08f, 0), transform.rotation);
                    Dustparticle.transform.localScale = new Vector3(1, 1, 0);
                    timer = 0;
                }
            }
        }
        //Jumping
        if (boxcl.IsTouchingLayers(ground) && ydirection > 0)
        {
            doubleJump = false;
        }
        if (ydirection > 0)
        {
            if (boxcl.IsTouchingLayers(ground) || doubleJump)
                Jump();
            doubleJump = !doubleJump;
        }
    }
    public void Jump()
    {
        rg.velocity = new Vector2(rg.velocity.x, Jumpforce);
        state = State.jumping;
        Instantiate(JumpParticle, new Vector3(transform.position.x, transform.position.y - 0.08f, 0), transform.rotation);
    }
    void Animation()
    {
        //hoat anh roi
        if (state == State.jumping)
        {
            if (rg.velocity.y < 0.1f)
            {
                state = State.falling;
            }
        }
        //hoat anh cham dat
        else if (state == State.falling)
        {
            if (boxcl.IsTouchingLayers(ground))
            {
                state = State.idle;
                Instantiate(FallParticle, new Vector3(transform.position.x, transform.position.y - 0.08f, 0), transform.rotation);
            }
        }
        //hoat anh bi hurt
        else if (state == State.hurt)
        {
        //    if (hurttimer >= HurtDelay)
        //    {
        //        state = State.idle;
        //        hurttimer = 0;
        //     }

        }
        //hoat anh chay
        else if (Mathf.Abs(rg.velocity.x) > 3f)
        {
            state = State.running;

        }
        //hoat anh idle
        else
        {
            state = State.idle;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // va cham voi enemy
        if (other.gameObject.tag == "Enemy")
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();

            state = State.hurt;
            HealthManager.TakeDamage(1);

            if (other.gameObject.transform.position.x > transform.position.x)
            {
                rg.velocity = new Vector2(-Hurtforce, Hurtforce +3);
            }
            if (other.gameObject.transform.position.x < transform.position.x)
            {
                rg.velocity = new Vector2(Hurtforce, Hurtforce +3);
            }
        }
        // va cham voi CannonBall
        if (other.gameObject.tag == "CannonBall")
        {
            state = State.hurt;
            HealthManager.TakeDamage(3);

            if (other.gameObject.transform.position.x > transform.position.x)
            {
                rg.velocity = new Vector2(-Hurtforce + 1 , Hurtforce + 3);
            }
            if (other.gameObject.transform.position.x < transform.position.x)
            {
                rg.velocity = new Vector2(Hurtforce +1 , Hurtforce + 3);
            }
        }
    }
    public void OnTriggerEnter2D(Collider2D trig)
    {
        //va cham voi enemy
       
        // va cham voi vat pham
        if(trig.gameObject.tag == "currency")
        {
            coinBehaviour Coins = trig.gameObject.GetComponent<coinBehaviour>();
            tempCoins = Coins.Value;
            CoinsManager.TakeCoins(tempCoins);
        }
    }


    // Player Combat Logic
    public void Attack()
    {
      //  dashwhenAtk();
        if (!isAttacking)
        {
            isAttacking = true;
            
        }
    }
    public void dashwhenAtk()
    {
        rg.velocity = new Vector2(attackDash, 0);
    }
    public void StopHurt()
    {
        state = State.idle;
    }
}




