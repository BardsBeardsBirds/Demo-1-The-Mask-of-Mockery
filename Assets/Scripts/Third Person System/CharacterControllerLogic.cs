using UnityEngine;
using System.Collections;

public class CharacterControllerLogic : MonoBehaviour
{
    public enum CharacterState
    {
        Idle, Running, Walking, 
        WalkBackwards, Turning, 
        Jumping, Falling, Landing, Sliding, Using, 
        Dead, Talking, TalkingLastLine
    }

    public enum WalkGround
    {
        Concrete, ConcreteGritty, CreakyFloor, CreakyRug, Deck, Dirt, Gravel, Leaves, Marble, Metal, Mud, SandDry, SandWet, Snow, Wood, WoodRug, WoodSolid, None
    }

    public static CharacterControllerLogic Instance;

    [SerializeField]
    private CharacterState _state = CharacterState.Idle;
    [SerializeField]
    private ThirdPersonCamera _gameCam;
	[SerializeField]
	private Animator _animator;
    [SerializeField]
    private CapsuleCollider _capCollider;
    [SerializeField]
    private bool _isGrounded;
	[SerializeField]
	private float _directionSpeed = 4.0f;
	[SerializeField]
	private float _rotationDegreePerSecond = 120f;
	[SerializeField]
	private float _speedDampTime = 0.25f;
    [SerializeField]    
    private float _fovDampTime = 3f;
    [SerializeField]
    private float _jumpMultiplier = 1f;

    [SerializeField]
    private float _jumpDist = 1f;
    [SerializeField]
    private float _slideThreshold = 40f;

	private float _speed = 0.0f;
	private float _direction = 0f;
    private float _charAngle = 0f;
    private float _fallHeightStart = 5f;
    private float _heightAtFallStart = 0f;
    private float _fatalFallHeight = 24f;
    private const float SPRINT_SPEED = 3.0f;
    private const float SPRINT_FOV = 75.0f;
    private const float NORMAL_FOV = 60.0f;
	private AnimatorStateInfo _stateInfo;
    private AnimatorTransitionInfo _transitionInfo;
    private Vector3 _slideDirection;
    private GameObject _initialPosition;

 //   private int _m_IdlePivotLId = 0;
 //   private int _m_IdlePivotRId = 0;
	private int _m_LocomotionId = 0;

    //NEW

    private CharacterMovement _characterMovement;
    public static CharacterController CharacterController;

    public float ForwardSpeed = 2f;
    public float BackwardSpeed = 1.6f;
    public float SlideSpeed = 13f;
    public float JumpSpeed = 2f;
    public float Gravity = 21f;
    public float TerminalVelocity = 20f;

    //NEW




    public CharacterState State { get { return this._state; } set { _state = value; } }
    public Animator Animator { get { return this._animator; } }
    public bool IsGrounded { get { return this._isGrounded; } }
    public float Speed { get { return this._speed; } }
    public float LocomotionThreshold { get { return 0.2f; } }

	void Start () 
	{
        Instance = this;
        _characterMovement = new CharacterMovement();
        CharacterController = this.GetComponent<CharacterController>();

        _animator = this.GetComponent<Animator>();

		if (_animator.layerCount >= 2) 
		{
			_animator.SetLayerWeight(1, 1);
		}

		//hash all animation names for performance
        //_m_IdlePivotLId = Animator.StringToHash("Base Layer.IdlePivotL");
        //_m_IdlePivotRId = Animator.StringToHash("Base Layer.IdlePivotR");
        _m_LocomotionId = Animator.StringToHash("Base Layer.Locomotion");

        GameObject initialPosition = new GameObject("Player spawnpoint");
        initialPosition.transform.position = transform.position;
        initialPosition.transform.rotation = transform.rotation;
        _initialPosition = initialPosition;
	}
	
	void Update () 
	{
        //Debug.Log(CharacterControllerLogic.Instance.State + " " + _characterMovement.MoveDirection);
        _characterMovement.ControllerLogic();
        _characterMovement.DetermineCurrentState();
	}

    private bool CanWalkForward()
    {
        RaycastHit hitInfo;
        Debug.DrawRay(transform.position, transform.forward, Color.yellow);

        Physics.Raycast(new Vector3(transform.position.x, transform.position.y + 0.15f, transform.position.z), transform.forward, out hitInfo, 1.0f);
      //  Debug.Log(Vector3.Dot(Vector3.up, hitInfo.normal) + " kan hij doorlopen? " + (Vector3.Dot(Vector3.up, hitInfo.normal) > 0.60f));   //45 maximum hoek
        if (Vector3.Dot(Vector3.up, hitInfo.normal) > 0.65f || Vector3.Dot(Vector3.up, hitInfo.normal) <= 0)
        {
        //    Debug.Log(Vector3.Dot(Vector3.up, hitInfo.normal) + "pass");
            return true;
        }
        else
        //    Debug.LogWarning(Vector3.Dot(Vector3.up, hitInfo.normal) + "stop");
            return false;
    }
   
    private void CheckForSliding()
    {
     //   Debug.DrawRay(transform.position, Vector3.down, Color.yellow);
        _slideDirection = Vector3.zero;
        RaycastHit rayHit;
        if (Physics.Raycast(transform.position, Vector3.down, out rayHit))
        {
          //  Debug.Log(myAng);

            if (Vector3.Angle(rayHit.normal, Vector3.up) > _slideThreshold && _isGrounded)
            {
                Animator.SetBool("Slide", true);
                _state = CharacterState.Sliding;
                Vector3 hit = rayHit.normal;
                _slideDirection = new Vector3(rayHit.normal.x, -rayHit.normal.y, rayHit.normal.z);
                Vector3.OrthoNormalize(ref hit, ref _slideDirection);
                Vector3 moveVector = _slideDirection;


                transform.position = transform.position + moveVector * Time.deltaTime * 10f;
           

                Debug.DrawRay(transform.position, transform.forward, Color.red);
                Debug.DrawRay(transform.position, _slideDirection, Color.white);

            }
            else
            {
                Animator.SetBool("Slide", false);
            }
        }
    }

    private bool IsGroundedTest()
    {
        Debug.DrawRay(transform.position, Vector3.down, Color.cyan);
        float distanceToGround = 0f;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -Vector3.up, out hit, 150f))
        {
            distanceToGround = hit.distance;
        }
        // Debug.Log("Distance to the ground is: " + distanceToGround);
        if (distanceToGround > .2f)
        {
            _isGrounded = false;
            if(_animator.GetBool("Falling")) // we are falling
            {
                
                transform.position = transform.position - new Vector3(0, 10f, 0) * Time.deltaTime;
            }
            else if (distanceToGround > _fallHeightStart)
            {
                StartFalling();
            }
        }
        else
        {
            _isGrounded = true;
            if (_animator.GetBool("Falling"))
            {
                //we land
                _animator.SetBool("Falling", false);
                Debug.LogWarning("we fell: " + (_heightAtFallStart - transform.position.y));
                if (_heightAtFallStart - transform.position.y > _fatalFallHeight)
                    Die();
            }
        }
        return (_isGrounded);
    }

    private void StartFalling()
    {
        _heightAtFallStart = transform.position.y;
        Animator.SetBool("Falling", true);
        _state = CharacterState.Falling;
    }

    public void GoToTalkingState()
    {
        Debug.LogWarning("To Talking state");
        _state = CharacterState.Talking;
        ForceSpeed(0);
        ForceTurningAngle(0);
        GameManager.Instance.UICanvas.WidgetNotActive();
    }

    public void GoToTalkingLastLineState()
    {
        _state = CharacterState.TalkingLastLine;
    }

    public void EndDialogueState()
    {
        GameManager.Instance.UICanvas.WidgetActive();
        GoToIdleState();
    }

    public void SetTalkingBool(bool talking)
    {
        _animator.SetBool("Talking", talking);
    }

    public void GoToIdleState()
    {
        _state = CharacterState.Idle;
    }

    public void ForceSpeed(float speed)
    {
        if (speed == 0)
        {
            _animator.SetBool("Forward", false);
            _animator.SetBool("Backwards", false);
        }
        if (speed > 0)
        {
            _animator.SetBool("Forward", true);
            _animator.SetBool("Backwards", false);
        }
        if (speed < 0)
        {
            _animator.SetBool("Forward", false);
            _animator.SetBool("Backwards", true);
        }

        _characterMovement.MoveVector += new Vector3(0, 0, speed);

    //    _animator.SetFloat("Speed", speed);
    }

    public void ForceTurningAngle(int direction)
    {
        if (direction == 1)
            _animator.SetInteger("TurningDirection", 1);
        else if (direction == -1)
            _animator.SetInteger("TurningDirection", -1);
        else if (direction == 0)
            _animator.SetInteger("TurningDirection", 0);
        else
            Debug.LogWarning("Wrong turning direction! Direction is " + direction);
    }

    public bool IsInSlide()
    {
        return _animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Slide");
    }

    public bool IsInLocomotion()
    {
        return _stateInfo.fullPathHash == _m_LocomotionId;
    }

    private void Die()
    {
        Debug.LogError("DIE!");
        _state = CharacterState.Dead;
    }

    public void Slide()
    {
        if (_animator.GetBool("Falling"))
            return;

        if (!_characterMovement.TooSteep)
        {
            StopSliding();
            return;
        }

        //       Debug.Log("Sliding");
        State = CharacterState.Sliding;
        _animator.SetBool("Slide", true);
    }

    public void StopSliding()
    {
        _animator.SetBool("Slide", false);
        State = CharacterState.Idle;
    }

    private void Reset() //reset character so we can play again
    {
        _state = CharacterState.Idle;
        transform.position = _initialPosition.transform.position;
        transform.rotation = _initialPosition.transform.rotation;
    }

    public void StopMovingAndTurning()
    {
        _animator.SetBool("Forward", false);
        _animator.SetBool("Backwards", false);
        _animator.SetInteger("TurningDirection", 0);
    }

    public void StopMoving()
    {
        _animator.SetBool("Forward", false);
        _animator.SetBool("Backwards", false);
    }

    public void StopTurning()
    {
        _animator.SetInteger("TurningDirection", 0);
    }

    public CharacterState GetState()
    {
        CharacterState state = _state;
        return state;
    }
}
