using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;

public class CatController : Unit
{
    [Header("BaseStats")]
    public float baseSpeed = 2;

    public int baseAttackDamage = 10;

    public float actionDelay = 1f; 

    public Unit target;

    //adapted stats
    [HideInInspector]public int attackDamage;

    [Header("Skill")]
    public int mana;
    public int manaIncresement = 20;
    public float skillCooldown = 5f;

    [HideInInspector] public float actionDelayCountdown = 0;
    [HideInInspector] public float skillCooldownCountdown = 0;

    [Header("Points")]
    public GameObject healthBarPoint;

    Rigidbody2D body;
    [HideInInspector] public CatAnimation anim;

    private UnityArmatureComponent armatureComponent;
    [HideInInspector] public HealthBar healthBar;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        body = this.GetComponent<Rigidbody2D>();
        anim = GetComponent<CatAnimation>();

        if (healthBarPoint)
        {
            GameObject healthBarObj = Resources.Load("Prefabs/UIs/HealthBar/CatHealthBar") as GameObject;
            healthBar = Instantiate(healthBarObj, healthBarPoint.transform.position, healthBarPoint.transform.rotation).GetComponent<HealthBar>();
            healthBar.transform.SetParent(this.transform);
            healthBar.SetHPBar(maxHP,maxHP);
            healthBar.SetManaBar(0);
        }
        
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
            if(anim.currentState == "idle"|| anim.currentState == "running")
            {
                body.velocity = new Vector2(baseSpeed, 0);
                anim.Running();
            }
        }
        else
        {
            body.velocity = new Vector2(0, 0);
            anim.IdleNotAttack();
        }
    }

    private void Update()
    {
        if (isDead)
            return;

        if (target)
            if (target.isDead)
                target = null;

        if (actionDelayCountdown >= 0)
        {
            actionDelayCountdown -= Time.deltaTime;
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
        if(mana < 100)
        {
            anim.Attack();
        }
        else
        {
            anim.Skill();
        }

        actionDelayCountdown = actionDelay;

    }

    public virtual void Attack()
    {
        if (mana < 100)
        {
            mana += manaIncresement;
        }

        if (healthBar)
        {
            healthBar.SetManaBar(mana);
        }
    }

    public virtual void Skill()
    {
        mana = 0;
        if (healthBar)
        {
            healthBar.SetManaBar(mana);
        }
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);

        if(mana < 100)
        {
            mana += manaIncresement;
        }


        if (healthBar)
        {
            healthBar.SetHPBar(hp,maxHP);
            healthBar.SetManaBar(mana);
        }
    }

    public override void Dead()
    {
        if (healthBar)
        {
            healthBar.SetHPBar(0,maxHP);
            healthBar.gameObject.SetActive(false);
        }

        anim.Dead();
        base.Dead();
    }

    //dragonbones event
    private void OnFrameEventHandler(string type, EventObject eventObject)
    {
        if(eventObject.name == "atk")
        {
            Attack();
        }

        if (eventObject.name == "skill")
        {
            Skill();
        }
    }
}
