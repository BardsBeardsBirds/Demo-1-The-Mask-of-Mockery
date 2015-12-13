
using UnityEngine;

public class CharacterMovement
{
    public enum Direction
    {
        Stationary, Forward, Backward, Left, Right,
        LeftForward, RightForward, LeftBackward, RightBackward,
        Turning
    }

    public Vector3 MoveVector { get; set; }
    public Direction MoveDirection { get; set; }
    public float VerticalVelocity { get; set; }
    public bool IsSliding { get; set; }

    public bool TooSteep = false;
    public float SlideThreshold = 45f;

    private float _turningAxis = 0;
    private Vector3 _slideDirection;
    private float _rayDistance = 1;

    public void ControllerLogic()
    {
        ResetMotor();

        if ((CharacterControllerLogic.Instance.State != CharacterControllerLogic.CharacterState.Using &&
            CharacterControllerLogic.Instance.State != CharacterControllerLogic.CharacterState.Landing &&
            CharacterControllerLogic.Instance.State != CharacterControllerLogic.CharacterState.Talking &&
            CharacterControllerLogic.Instance.State != CharacterControllerLogic.CharacterState.TalkingLastLine) &&
            GameManager.GamePlayingMode == GameManager.GameMode.Running)
        {
            GetLocomotionInput();
            HandleActionInput();
        }

        UpdateMotor();
    }

    public void DetermineCurrentState()
    {
        if (GameManager.GamePlayingMode != GameManager.GameMode.Running)
            return;

        if (CharacterControllerLogic.Instance.State == CharacterControllerLogic.CharacterState.Dead)
            return;

        if (!CharacterControllerLogic.CharacterController.isGrounded)
        {
            if (CharacterControllerLogic.Instance.State != CharacterControllerLogic.CharacterState.Falling &&
               CharacterControllerLogic.Instance.State != CharacterControllerLogic.CharacterState.Jumping &&
               CharacterControllerLogic.Instance.State != CharacterControllerLogic.CharacterState.Landing)
            {
     //           Fall();
            }
        }

        //if (GameManager.PlayerInSpeechState)
        //{
        //    State = CharacterState.Talking;
        //}

        if (CharacterControllerLogic.Instance.State != CharacterControllerLogic.CharacterState.Falling &&
           CharacterControllerLogic.Instance.State != CharacterControllerLogic.CharacterState.Jumping &&
           CharacterControllerLogic.Instance.State != CharacterControllerLogic.CharacterState.Landing &&
           CharacterControllerLogic.Instance.State != CharacterControllerLogic.CharacterState.Using &&
           CharacterControllerLogic.Instance.State != CharacterControllerLogic.CharacterState.Sliding &&
           CharacterControllerLogic.Instance.State != CharacterControllerLogic.CharacterState.Talking &&
           CharacterControllerLogic.Instance.State != CharacterControllerLogic.CharacterState.TalkingLastLine)
        {
            switch (MoveDirection)
            {
                case Direction.Stationary:
                    CharacterControllerLogic.Instance.State = CharacterControllerLogic.CharacterState.Idle;
                    CharacterControllerLogic.Instance.Animator.SetBool("Backwards", false);
                    CharacterControllerLogic.Instance.Animator.SetBool("Forward", false);
                    CharacterControllerLogic.Instance.Animator.SetBool("Jump", false);
                    break;
                case Direction.Forward:                   
                    CharacterControllerLogic.Instance.State = CharacterControllerLogic.CharacterState.Running;
                    CharacterControllerLogic.Instance.Animator.SetBool("Backwards", false);
                    CharacterControllerLogic.Instance.Animator.SetBool("Forward", true);

                    break;
                case Direction.Backward:
                    CharacterControllerLogic.Instance.State = CharacterControllerLogic.CharacterState.WalkBackwards;
                    CharacterControllerLogic.Instance.Animator.SetBool("Backwards", true);
                    CharacterControllerLogic.Instance.Animator.SetBool("Forward", false);
                    CharacterControllerLogic.Instance.Animator.SetBool("Jump", false);
                    break;
                case Direction.Left:
              //      CharacterControllerLogic.Instance.State = CharacterControllerLogic.CharacterState.StrafingLeft;
                    break;
                case Direction.Right:
              //      CharacterControllerLogic.Instance.State = CharacterControllerLogic.CharacterState.StrafingRight;
                    break;
                case Direction.LeftForward:
                    CharacterControllerLogic.Instance.State = CharacterControllerLogic.CharacterState.Running;
                    break;
                case Direction.RightForward:
                    CharacterControllerLogic.Instance.State = CharacterControllerLogic.CharacterState.Running;
                    break;
                case Direction.LeftBackward:
                    CharacterControllerLogic.Instance.State = CharacterControllerLogic.CharacterState.WalkBackwards;
                    CharacterControllerLogic.Instance.Animator.SetBool("Backwards", true);
                    CharacterControllerLogic.Instance.Animator.SetBool("Forward", false);
                    break;
                case Direction.RightBackward:
                    CharacterControllerLogic.Instance.State = CharacterControllerLogic.CharacterState.WalkBackwards;
                    CharacterControllerLogic.Instance.Animator.SetBool("Backwards", true);
                    CharacterControllerLogic.Instance.Animator.SetBool("Forward", false);
                    break;
                default:
                    break;
            }
        }
    }

    public void DetermineCurrentMoveDirection()
    {
        var forward = false;
        var backward = false;
        var left = false;
        var right = false;

        if (MoveVector.z > 0)
            forward = true;
        if (MoveVector.z < 0)
            backward = true;
        if (MoveVector.x > 0)
            right = true;
        if (MoveVector.x < 0)
            left = true;

        if (forward)
        {
            if (left)
                MoveDirection = Direction.LeftForward;
            else if (right)
                MoveDirection = Direction.RightForward;
            else
                MoveDirection = Direction.Forward;
        }
        else if (backward)
        {
            if (left)
                MoveDirection = Direction.LeftBackward;
            else if (right)
                MoveDirection = Direction.RightBackward;
            else
                MoveDirection = Direction.Backward;
        }
        else if (left)
            MoveDirection = Direction.Left;
        else if (right)
            MoveDirection = Direction.Right;
        else
            MoveDirection = Direction.Stationary;
    }

    public void ProcessMotion()
    {
        if (CharacterControllerLogic.Instance.State == CharacterControllerLogic.CharacterState.Talking || CharacterControllerLogic.Instance.State == CharacterControllerLogic.CharacterState.TalkingLastLine)//stop player from moving if talking
            return;

        if (CharacterControllerLogic.Instance.State == CharacterControllerLogic.CharacterState.Dead)
        {
            //if (Input.anyKeyDown)
            //    Reset();
            return;
        }

    //    if (!TP_Animator.Instance.IsDead)
            MoveVector = GameManager.Player.transform.TransformDirection(MoveVector);
        //else
        //    MoveVector = new Vector3(0, MoveVector.y, 0);

        if (MoveVector.magnitude > 1)
            MoveVector = Vector3.Normalize(MoveVector);

        var moveVector = MoveVector;

        if (CharacterControllerLogic.CharacterController.isGrounded)
            SlideMethod();

        MoveVector *= MoveSpeed();

        //reapply vertical velocity
        MoveVector = new Vector3(MoveVector.x, VerticalVelocity, MoveVector.z);

        ApplyGravity();

        CharacterControllerLogic.CharacterController.Move(MoveVector * Time.deltaTime);
    }

    public void GetLocomotionInput()
    {
        var deadZone = 0.1f;

        if (Input.GetAxis("Vertical") > deadZone || Input.GetAxis("Vertical") < deadZone)
        {
            MoveVector += new Vector3(0, 0, Input.GetAxis("Vertical"));
        }

        if (Input.GetAxis("Horizontal") > deadZone || Input.GetAxis("Horizontal") < deadZone)
        {
            _turningAxis = Input.GetAxis("Horizontal");

            if (CharacterControllerLogic.Instance.State != CharacterControllerLogic.CharacterState.Running)
            {
             //   if((turningAxis > 0.2f) || (turningAxis < -0.2f))
             //   {
             ////       turningAxis = 1;
             //       CharacterControllerLogic.Instance.Animator.SetFloat("TurningDirection", turningAxis);
             //   }
                if (_turningAxis > 0)
                {
                    _turningAxis = 1;
                    CharacterControllerLogic.Instance.Animator.SetInteger("TurningDirection", 1);
                }
                else if (_turningAxis < 0)
                {
                    _turningAxis = -1;
                    CharacterControllerLogic.Instance.Animator.SetInteger("TurningDirection", -1);
                }
                else
                {
                    _turningAxis = 0;
                    CharacterControllerLogic.Instance.Animator.SetInteger("TurningDirection", 0);
                }
            }
            else    //we are running and then start turning
            {
                     GameManager.Player.transform.Rotate(0, _turningAxis * Time.deltaTime * 85, 0);
            }

        }
        DetermineCurrentMoveDirection();
    }

    private float MoveSpeed()
    {
        var moveSpeed = 0f;

        switch (MoveDirection)
        {
            case Direction.Stationary:
                moveSpeed = 0;
                break;
            case Direction.Forward:
                moveSpeed = CharacterControllerLogic.Instance.ForwardSpeed;
                break;
            case Direction.Backward:
                moveSpeed = CharacterControllerLogic.Instance.BackwardSpeed;
                break;
            case Direction.Left:
                moveSpeed = 0;
             //   moveSpeed = CharacterControllerLogic.Instance.StrafingSpeed;
                break;
            case Direction.Right:
                moveSpeed = 0;
                //    moveSpeed = CharacterControllerLogic.Instance.StrafingSpeed;
                break;
            case Direction.LeftForward:
                moveSpeed = CharacterControllerLogic.Instance.ForwardSpeed;
                break;
            case Direction.RightForward:
                moveSpeed = CharacterControllerLogic.Instance.ForwardSpeed;
                break;
            case Direction.LeftBackward:
                moveSpeed = CharacterControllerLogic.Instance.BackwardSpeed;
                break;
            case Direction.RightBackward:
                moveSpeed = CharacterControllerLogic.Instance.BackwardSpeed;
                break;
        }

        if (IsSliding)
            moveSpeed = CharacterControllerLogic.Instance.SlideSpeed;

        return moveSpeed;
    }

    public void ApplyGravity()
    {
        if (MoveVector.y > -CharacterControllerLogic.Instance.TerminalVelocity)
            MoveVector = new Vector3(MoveVector.x, MoveVector.y - CharacterControllerLogic.Instance.Gravity * Time.deltaTime, MoveVector.z);

        if (CharacterControllerLogic.CharacterController.isGrounded && MoveVector.y < -1)
            MoveVector = new Vector3(MoveVector.x, -1, MoveVector.z);
    }

    public void ResetMotor()
    {
        VerticalVelocity = MoveVector.y;
        MoveVector = Vector3.zero;
    }

    void HandleActionInput()
    {
        if (Input.GetButton("Jump") && 
            CharacterControllerLogic.Instance.State != CharacterControllerLogic.CharacterState.Falling &&
            CharacterControllerLogic.Instance.State != CharacterControllerLogic.CharacterState.Talking &&
            CharacterControllerLogic.Instance.State != CharacterControllerLogic.CharacterState.TalkingLastLine)
        {
                if (CharacterControllerLogic.CharacterController.isGrounded && !IsSliding && !TooSteep)
                {
                //    VerticalVelocity = CharacterControllerLogic.Instance.JumpSpeed;
               // CharacterControllerLogic.Instance.JumpStartHeight = transform.position.y;

                CharacterControllerLogic.Instance.Animator.SetTrigger("Jump");
                Debug.Log("FIRE");
            }


            //       Jump();
        }

        //if (Input.GetKeyDown(KeyCode.L)) //death key
        //{
        //    Die();
        //}
    }

    public void UpdateMotor()	
    {
    //    SnapAllignCharacterWithCamera();
        ProcessMotion();
    }

    void SlideMethod()
    {
        Debug.DrawRay(GameManager.Player.transform.position, Vector3.down, Color.cyan);
        _slideDirection = Vector3.zero;
        RaycastHit rayHit;
        if (Physics.Raycast(GameManager.Player.transform.position, -Vector3.up, out rayHit, _rayDistance + 0.2F))
        {
             Debug.Log(Vector3.Angle(rayHit.normal, Vector3.up) + " and " + SlideThreshold);

            if (Vector3.Angle(rayHit.normal, Vector3.up) > SlideThreshold && CharacterControllerLogic.CharacterController.isGrounded)
            {
                TooSteep = true;
                CharacterControllerLogic.Instance.Slide();
                Vector3 hit = rayHit.normal;
                _slideDirection = new Vector3(rayHit.normal.x, -rayHit.normal.y, rayHit.normal.z);
                Vector3.OrthoNormalize(ref hit, ref _slideDirection);
                MoveVector = _slideDirection;
            }
            else
            {
                TooSteep = false;
                CharacterControllerLogic.Instance.StopSliding();

            }
        }
    }


}
