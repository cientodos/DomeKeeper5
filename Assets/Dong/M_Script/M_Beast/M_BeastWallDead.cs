using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_BeastWallDead : M_State
{
    M_Beast beast;
    public M_BeastWallDead(M_Base @base, M_StateMachine stateMachine, string aniboolname, M_Beast beast) : base(@base, stateMachine, aniboolname)
    {
        this.beast = beast;
    }

    public override void Enter()
    {
        base.Enter();
        if(beast.rb.bodyType != RigidbodyType2D.Static)
        {
            beast.SetVelocity(0, 0);
            beast.rb.gravityScale = 0;
        }
        beast.gameObject.GetComponent<CircleCollider2D>().enabled = false;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
    }
}
