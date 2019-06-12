using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;

public class SoldierController : Unit
{
    [Header("BaseStats")]
    public float baseSpeed = 2;

    public string damageType; //melee,projectile,magic
    public int baseAttackDamage = 10;

    public float attackDelay = 1f; 

    public Unit target;

    //adapted stats
    private int attackDamage;

    public float attackDelayCountdown = 0;

    Rigidbody2D body;
    SoldierAnimation anim;

    private UnityArmatureComponent armatureComponent;


    // Start is called before the first frame update
    void Start()
    {
        body = this.GetComponent<Rigidbody2D>();
        anim = GetComponent<SoldierAnimation>();

        attackDamage = baseAttackDamage;

        armatureComponent = GetComponent<DragonBones.UnityArmatureComponent>();
        armatureComponent.AddDBEventListener(EventObject.FRAME_EVENT, this.OnFrameEventHandler);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isDead)
        {
            body.velocity = new Vector2(0, 0);
            return;
        }

        if (!target)
        {
            body.velocity = new Vector2(baseSpeed, 0);
            anim.Running(); 
        }
        else
        {
            body.velocity = new Vector2(0, 0);
        }
    }

    private void Update()
    {
        if (isDead)
            return;

        if (target)
            if (target.isDead)
                target = null;

        if (attackDelayCountdown >= 0)
        {
            attackDelayCountdown -= Time.deltaTime;
        }
        else
        {
            if (target)
            {
                Action();
            }
        }
    }

    //trigger attack anim
    public virtual void Action()
    {
        anim.Attack();
        attackDelayCountdown = attackDelay;
    }

    public virtual void Attack(Unit target)
    {
        if (!target)
            return;

            target.TakeDamage(attackDamage);
    }

    public override void Dead()
    {
        anim.Dead();
        isDead = true;
        gameObject.layer = 10;
        Destroy(this.gameObject,3f);
    }

    //dragonbones event
    private void OnFrameEventHandler(string type, EventObject eventObject)
    {
        if(eventObject.name == "atk")
        {
            Attack(target);
        }
    }
}
