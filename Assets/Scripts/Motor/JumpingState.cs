using UnityEngine;
using System.Collections;

public class JumpingState : BaseState
{
    public override void Construct()
    {
        base.Construct();
        motor.VerticalVelocity = motor.jumpHeight;
        immuneTime = 0.1f;
    }

    public override Vector3 ProcessMotion(Vector3 input)
    {
        MotorHelper.ApplySpeed(ref input, motor.Speed);
        MotorHelper.ApplyGravity(ref input, ref motor.verticalVelocity, motor.gravity, motor.gravity);

        return input;
    }

    public override void Transition()
    {
        base.Transition();

        if (motor.VerticalVelocity < 0)
            motor.ChangeState("FallingState");
    }
}