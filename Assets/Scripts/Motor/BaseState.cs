using UnityEngine;
using System.Collections;

public class BaseState : MonoBehaviour
{
    protected PlayerMotor motor;
    protected float startTime;
    protected float immuneTime;

    private void Awake()
    {
        motor = GetComponent<PlayerMotor>();
    }

    public virtual void Construct()
    {
        startTime = Time.time;
    }
    public virtual void Destruct()
    {

    }
    public virtual void Transition()
    {
        if (Time.time - startTime < immuneTime)
            return;
    }
    public virtual Vector3 ProcessMotion(Vector3 input)
    {
        Debug.Log("Process Motion not implemented in " + this.ToString());
        return input;
    }
    public virtual Quaternion ProcessRotation(Vector3 input)
    {
        return MotorHelper.FaceDirection(motor.MoveVector);
    }
}
