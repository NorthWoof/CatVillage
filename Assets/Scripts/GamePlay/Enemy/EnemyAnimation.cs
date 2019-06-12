using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;
using System;

public class EnemyAnimation : MonoBehaviour
{
    enum State { IDLE, RUNNING, ATTACK, DEAD };
    private State state = State.IDLE;

    public string run = "Running";
    public string attack = "Attack";
    public string idle = "Idle";
    public string dead = "Dead";

    private UnityArmatureComponent armatureComponent;

    // Start is called before the first frame update
    void Start()
    {
        armatureComponent = GetComponent<DragonBones.UnityArmatureComponent>();
        armatureComponent.AddDBEventListener(EventObject.COMPLETE, this.OnAnimationEventHandler);

        armatureComponent.animation.Play(run);
    }

    public void Attack()
    {
        if (state != State.DEAD)
        {
            armatureComponent.animation.Play(attack);
            state = State.ATTACK;
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
    }
}
