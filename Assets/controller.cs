using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class controller : MonoBehaviour
{
    PlayerController controls;
    float direction = 0;
    private float ydirection = 0;
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
    public bool isAttacking2 = false;
    public bool isFacingleft = false;
    public static controller instance;
    public int tempCoins;
    public float ThrowForceX;
    public float ThrowForceY;
    public bool HaveSword = true;

    public Rigidbody2D rg;
    public CapsuleCollider2D boxcl;
    public Animator anim;
    public GameObject Dustparticle;
    public GameObject JumpParticle;
    public GameObject FallParticle;
    public Rigidbody2D ThorwingSword;
    public PlayerHealthManager HealthManager;
    public PlayerCoinsManager CoinsManager;
    public Slider YforceThrowChange;
    public TimeFreezer FreezyTimes;
    public SlowMotion SlowDown;
 //   public coinBehaviour CoinsBehaviour;


    public enum State { idle, running, jumping, falling, hurt, doubleJump,Throw, NoIdle, NoRunning, NoJumping, NoFalling, NoHurt, }

    private void Awake()
    {
        //Input system

        controls = new PlayerController();
        controls.Enable();

        controls.Land.Move.performed += ctx =>
        {
            direction = ctx.ReadValue<float>();
        };
        controls.Land.Jump.performed += ctx => Jump();
        controls.Land.AttackG.performed += ctx => Attack();
        controls.Land.Throw.performed += ctx => StartThrow();

    }

    private void AttackG_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        throw new System.NotImplementedException();
    }

    void Start()
    {
        //Get component
        instance = this;
        YforceThrowChange = FindAnyObjectByType<Slider>();
        rg = GetComponent<Rigidbody2D>();
        boxcl = GetComponent<CapsuleCollider2D>();
        anim = GetComponent<Animator>();
        HealthManager = FindObjectOfType<PlayerHealthManager>();
        CoinsManager = FindObjectOfType<PlayerCoinsManager>();
        FreezyTimes = FindObjectOfType<TimeFreezer>();
        SlowDown = FindObjectOfType<SlowMotion>();
        //CoinsBehaviour = FindObjectOfType<coinBehaviour>();
    }

    private void FixedUpdate()
    {
        ThrowForceY = YforceThrowChange.value;

        hurttimer = hurttimer + Time.deltaTime;
        if (state != State.hurt && state != State.Throw && isAttacking2 != true)
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
            isFacingleft = true;
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
            isFacingleft = false;
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
        if(state != State.hurt)
        {
            rg.velocity = new Vector2(rg.velocity.x, Jumpforce);
            state = State.jumping;
            Instantiate(JumpParticle, new Vector3(transform.position.x, transform.position.y - 0.08f, 0), transform.rotation);
        }  
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
        else if (Mathf.Abs(rg.velocity.x) > 3f && state != State.hurt)
        {
            state = State.running;

        }
        //hoat anh idle
        else
        {
            if(state != State.Throw)
            {
                state = State.idle;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //Va cham voi item kiem
        if (other.gameObject.tag == "SwordItem")
        {
            HaveSword = true;
            anim.SetBool("HaveSword", true);
            other.gameObject.SetActive(false);
        }


            // va cham voi enemy
        if (other.gameObject.tag == "Enemy")
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();

            state = State.hurt;
            SlowDown.DoSlowMotion();
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
            SlowDown.DoSlowMotion();

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
        if (trig.gameObject.tag == "SwordBarrel")
        {
            HaveSword = true;
            anim.SetBool("HaveSword", true);
        }

    }


    // Player Combat Logic
    public void Attack()
    {
        //  dashwhenAtk();
        if (!isAttacking && state != State.running)
        {
            isAttacking = true;
            isAttacking2 = true;
        }
    }
    public void dashwhenAtk()
    {
        if (isFacingleft == false)
        {
            rg.velocity = new Vector2(attackDash, 1f);
        }
        else if (isFacingleft == true)
        {
            rg.velocity = new Vector2(-attackDash, 1f);
        }    
    }
    public void StopHurt()
    {
        state = State.idle;
    }

    public void StartThrow()
    {
        if (HaveSword == true)
        {
            state = State.Throw;
            Debug.Log("throw");
        }
    }
    public void ThrowSword()
    {
        
        if (state != State.hurt)
        {
            Rigidbody2D Clone;
            if (transform.localScale.x < 0)
            {
                Clone = Instantiate(ThorwingSword, new Vector2(transform.position.x - 0.65f, transform.position.y), transform.rotation);
                Clone.velocity = new Vector2(-ThrowForceX, ThrowForceY);
            }
            else if (transform.localScale.x > 0)
            {
                Clone = Instantiate(ThorwingSword, new Vector2(transform.position.x + 0.65f, transform.position.y), transform.rotation);
                Clone.velocity = new Vector2(ThrowForceX, ThrowForceY);
            }

            HaveSword = false;
            anim.SetBool("HaveSword", false);
            state = State.NoIdle;
            
        }
    }
    public void CancelAttack()
    {
        isAttacking2 = false;
    }

}




