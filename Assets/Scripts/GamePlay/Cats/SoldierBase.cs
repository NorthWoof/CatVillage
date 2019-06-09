using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;

public class SoldierBase : MonoBehaviour
{

    public int hp = 50;

    [Header("BaseStats")]
    public float baseSpeed = 2;
    public int baseAttackDamage = 10;
    public float attackDelay = 1f; 

    public GameObject target;

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
        if(attackDelayCountdown >= -1)
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

    public void Attack(GameObject target)
    {
        if(target.tag == "Enemy")
        {
            EnemyBase enemy = target.GetComponent<EnemyBase>();
            enemy.TakeDamage(attackDamage);
        }
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        CheckHp();
    }

    public void CheckHp()
    {
        if (hp <= 0)
        {
            Dead();
        }
    }

    public void Dead()
    {
        gameObject.layer = 10;
        Destroy(this.gameObject);
    }

    private void OnFrameEventHandler(string type, EventObject eventObject)
    {
        Debug.Log(eventObject.name);
        if(eventObject.name == "atk")
        {
            Attack(target);
        }
    }
}
