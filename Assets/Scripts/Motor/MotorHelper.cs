using UnityEngine;

public static class MotorHelper
{
    /// <summary>
    /// Multiply input vector by speed </summary>
    public static void ApplySpeed(ref Vector3 vector, float speed)
    {
        vector *= speed;
    }

    /// <summary>
    /// Returns the vertical velocity , Apply gravity to Vertical Velocity then changes the vector input </summary>
    public static float ApplyGravity(ref Vector3 vector, ref float verticalVelocity, float gravity, float terminalVelocity)
    {
        verticalVelocity -= (gravity * Time.deltaTime);
        verticalVelocity = (verticalVelocity < -terminalVelocity) ? -terminalVelocity : verticalVelocity;
        vector.Set(vector.x, verticalVelocity, vector.z);
        return verticalVelocity;
    }

    /// <summary>
    /// Get rid of input's components that are going in the direction of the toKill vector </summary>
    public static void KillVector(ref Vector3 vector, Vector3 toKill)
    {
        toKill.Set(toKill.x, 0, toKill.z);
        toKill.Normalize();
        if (toKill.x > 0 && vector.x < 0)
            vector.Set((1 - toKill.x) * vector.x, vector.y, vector.z);
        if (toKill.x < 0 && vector.x > 0)
            vector.Set((1 + toKill.x) * vector.x, vector.y, vector.z);
        if (toKill.z > 0 && vector.z < 0)
            vector.Set(vector.x, vector.y, (1 - toKill.z) * vector.z);
        if (toKill.z < 0 && vector.z > 0)
            vector.Set(vector.x, vector.y, (1 + toKill.z) * vector.z);
    }

    /// <summary>
    /// Will rotate the vector so it fits with the floor normal </summary>
    public static void FollowVector(ref Vector3 vector, Vector3 slopeNormal)
    {
        Vector3 right = new Vector3(slopeNormal.y, -slopeNormal.x, 0).normalized;
        Vector3 forward = new Vector3(0, -slopeNormal.z, slopeNormal.y).normalized;
        vector = right * vector.x + forward * vector.z;
    }

    /// <summary>
    /// Rotate current view with the camera's direction </summary>
    public static void RotateWithView(ref Vector3 vector, Transform cameraTransform)
    {
        Vector3 dir = cameraTransform.TransformDirection(vector);
        KillVertical(ref vector);
        vector = dir.normalized * vector.magnitude;
    }

    /// <summary>
    /// Returns Vector3 x,0,z </summary>
    public static void KillVertical(ref Vector3 vector)
    {
        vector = new Vector3(vector.x, 0, vector.z);
    }

    /// <summary>
    /// Returns rotation facing move </summary>
    public static Quaternion FaceDirection(Vector3 move)
    {
        Vector3 dir = move;
        MotorHelper.KillVertical(ref dir);
        if (dir == Vector3.zero)
            return Quaternion.identity;
        return Quaternion.LookRotation(dir, Vector3.up);
    }
}