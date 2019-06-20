using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;
using System;

public class SoldierAnimation : MonoBehaviour
{
    enum State {IDLE, RUNNING, ATTACK, Skill, DEAD };
    private State state = State.IDLE;

    public string run = "Running";
    public string attack = "Attack";
    public string idle = "Idle";
    public string dead = "Dead";
    public string skill = "Skill";


    private UnityArmatureComponent armatureComponent;

    // Start is called before the first frame update
    public void Start()
    {
        armatureComponent = GetComponent<DragonBones.UnityArmatureComponent>();
        armatureComponent.AddDBEventListener(EventObject.COMPLETE, this.OnAnimationEventHandler);

        armatureComponent.animation.Play(run);
    }

    public void Attack()
    {
        if(state != State.DEAD && state != State.ATTACK)
        {
            armatureComponent.animation.Play(attack);
            state = State.ATTACK;
        }

    }

    public void Skill()
    {
        if (state != State.DEAD && state != State.Skill)
        {
            armatureComponent.animation.Play(skill);
            state = State.Skill;
        }
    }

    public void IdleNotAttack()
    {
        if (state != State.DEAD && state != State.IDLE && state != State.ATTACK && state != State.Skill)
        {
            armatureComponent.animation.Play(idle);
            state = State.IDLE;
        }
    }

    public void Idle()
    {
        if (state != State.DEAD && state != State.IDLE)
        {
            armatureComponent.animation.Play(idle);
            state = State.IDLE;
        }
    }

    public void Running()
    {
        if (state != State.DEAD && state != State.RUNNING)
        {
            armatureComponent.animation.Play(run);
            state = State.RUNNING;
        }
    }

    public void Dead()
    {
        if (state != State.DEAD)
        {
            armatureComponent.animation.Play(dead);
            state = State.DEAD;
        }
    }

    void OnAnimationEventHandler(string type, EventObject eventObject)
    {
        if (eventObject.animationState.name == attack)
        {
            Idle();
        }

        if (eventObject.animationState.name == skill)
        {
            Idle();
        }
    }

   
}
