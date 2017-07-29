using UnityEngine;
using System.Collections;
using Prime31;

public class PlayerMotor : MonoBehaviour
{
    public float gravity = 14f;
    public float runSpeed = 8f;
    public float groundDamping = 5f;
    public float inAirDamping = 5f;
    public float jumpHeight = 14f;

    private Animator anim;
    private CharacterController2D controller;
    private RaycastHit2D _lastControllerColliderHit;
    private Vector3 moveVector;
    private BaseState state;

    private float horizontalVelocity;
    [HideInInspector]
    public float verticalVelocity;

    public Vector3 MoveVector { get { return moveVector; } }
    public float VerticalVelocity { set { verticalVelocity = value; } get { return verticalVelocity; } }
    public float Speed { get { return runSpeed; } }
    public bool Grounded { get { return controller.isGrounded; } }
    public Vector3 Inputs { get { return PoolInput(); } }

    private void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController2D>();
        state = GetComponent<RunningState>();
        state.Construct();
    }

    private Vector3 PoolInput()
    {
        Vector3 r = Vector3.zero;

        r.x = Input.GetAxisRaw("Horizontal");
        r.y = Input.GetAxisRaw("Vertical");
        r.z = Input.GetKeyDown(KeyCode.Space) ? 1 : 0;

        return r;
    }

    private void Update()
    {
        moveVector = PoolInput();
        moveVector = state.ProcessMotion(moveVector);
        state.ProcessRotation(moveVector);

        state.Transition();

     //   moveVector.x = Mathf.Lerp(horizontalVelocity, inputs.x * runSpeed, Time.deltaTime * (controller.isGrounded ? groundDamping : inAirDamping));
     //   moveVector.y = verticalVelocity;

        controller.move(moveVector * Time.deltaTime);

        horizontalVelocity = controller.velocity.x;
    }

    public virtual void ChangeState(string stateName)
    {
        state.Destruct();
        state = GetComponent(stateName) as BaseState;
        state.Construct();
    }
}
