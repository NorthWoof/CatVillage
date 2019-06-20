using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;
using System;

public class EnemyController : Unit
{
    [Header("BaseStats")]
    public float baseSpeed = 2;
    public int baseAttackDamage = 10;
    public float attackDelay = 1f;

    public Unit target;

    //adapted stats
    private int attackDamage;

    public float attackDelayCountdown = 0;

    [Header("Points")]
    public GameObject healthBarPoint;

    Rigidbody2D body;
    EnemyAnimation anim;

    private UnityArmatureComponent armatureComponent;
    private HealthBar healthBar;


    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        body = this.GetComponent<Rigidbody2D>();
        anim = GetComponent<EnemyAnimation>();

        if (healthBarPoint)
        {
            GameObject healthBarObj = Resources.Load("Prefabs/UIs/HealthBar/EnemyHealthBar") as GameObject;
            healthBar = Instantiate(healthBarObj, healthBarPoint.transform.position, healthBarPoint.transform.rotation).GetComponent<HealthBar>();
            healthBar.transform.SetParent(this.transform);
            healthBar.SetHPBar(maxHP,maxHP);
            healthBar.SetManaBar(0);
        }

        attackDamage = baseAttackDamage;

        armatureComponent = GetComponent<DragonBones.UnityArmatureComponent>();
        armatureComponent.AddDBEventListener(EventObject.FRAME_EVENT, this.OnFrameEventHandler);
    }


    void FixedUpdate()
    {
        if (isDead)
        {
            body.velocity = new Vector2(0, 0);
            return;
        }
        if (!target)
        {
            body.velocity = new Vector2(-baseSpeed, 0);
            anim.Running();
        }
        else
        {
            body.velocity = new Vector2(0, 0);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(target)
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

    public virtual void Action()
    {
        anim.Attack();
        attackDelayCountdown = attackDelay;
    }

    //Do Damage
    public virtual void Attack(Unit target)
    {
        if (!target)
            return;
        target.TakeDamage(attackDamage);
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        if (healthBar)
        {
            healthBar.SetHPBar(hp,maxHP);
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

    private void OnFrameEventHandler(string type, EventObject eventObject)
    {
        if (eventObject.name == "atk")
        {
            Attack(target);
        }
    }

}
