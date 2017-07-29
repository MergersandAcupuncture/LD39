using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningState : BaseState
{
    public override void Construct()
    {
        base.Construct();
        motor.VerticalVelocity = 0.0f;
    }

    public override Vector3 ProcessMotion(Vector3 input)
    {
        MotorHelper.ApplySpeed(ref input, motor.Speed);

        return input;
    }

    public override void Transition()
    {
        base.Transition();

        if (!motor.Grounded)
            motor.ChangeState("FallingState");

        if (motor.Inputs.y > 0)
            motor.ChangeState("JumpingState");
    }
}
