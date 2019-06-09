using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;
using System;

public class SoldierAnimation : MonoBehaviour
{
    enum State {IDLE, RUNNING, ATTACK, DEAD };
    private State state = State.IDLE;

    public string run = "Running";
    public string attack = "Attack";
    public string idle = "Idle";

    private UnityArmatureComponent armatureComponent;

    // Start is called before the first frame update
    void Start()
    {
        armatureComponent = GetComponent<DragonBones.UnityArmatureComponent>();
        armatureComponent.AddDBEventListener(EventObject.COMPLETE, this.OnAnimationEventHandler);

        armatureComponent.animation.Play(run, 0);
    }

    public void Attack()
    {
        if(state != State.DEAD)
        {
            armatureComponent.animation.Play(attack, 1);
            state = State.ATTACK;
        }

    }

    public void Idle()
    {
        if (state != State.DEAD && state != State.IDLE)
        {
            armatureComponent.animation.FadeIn(idle, 0.2f);
            state = State.IDLE;
        }
    }

    public void Running()
    {
        if (state != State.DEAD && state != State.RUNNING)
        {
            armatureComponent.animation.FadeIn(run, 0.2f);
            state = State.RUNNING;
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
