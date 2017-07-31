using UnityEngine;
using System.Collections;

public class FallingState : BaseState
{
    public bool lockMovementWhileAirborne = true;
    private Vector3 lockDirection;

    public override void Construct()
    {
        base.Construct();
        if (lockMovementWhileAirborne)
            LockMovementDirection();
    }

    public override Vector3 ProcessMotion(Vector3 input)
    {
        MotorHelper.ApplySpeed(ref input,motor.horizontalVelocity, motor.Speed, motor.inAirDamping);
        MotorHelper.ApplyGravity(ref input, ref motor.verticalVelocity, motor.gravity, motor.gravity);

        return input + Vector3.down;
    }

    public override void Transition()
    {
        base.Transition();

        if (motor.Grounded)
            motor.ChangeState("RunningState");

        //	if (motor.SlopeNormal.y < motor.SlopeTreshold) 
        //		Debug.Log("Sliding State");
    }

    #region state specific

    private void LockMovementDirection()
    {
        lockDirection = new Vector3(motor.MoveVector.x, 0, motor.MoveVector.z).normalized;
    }

    #endregion
}