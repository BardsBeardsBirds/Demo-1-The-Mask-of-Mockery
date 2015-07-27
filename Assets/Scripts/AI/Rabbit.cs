using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Rabbit : MonoBehaviour 
{
    public GameObject Instance;
    public CritterState State;

    public List<Transform> WanderLocations = new List<Transform>();
    public List<AreaEnum> ActiveAreas = new List<AreaEnum>();   // the areas from which the rabbit could be seen by the player, so in which he should be active
    private float _speed = 4f;
    private float _rotationSpeed = 4f;
    private float _timer = 0;
    private float _maxTimer = 3f;
    private Animator _animator;

    public Transform CurrentDestinationGoal;
    public Transform PreviousDestinationGoal;

    private int _inTheArea = 0;
    private bool _withEmmonInArea = false;

	void Start () 
    {
        Instance = this.gameObject;
        State = CritterState.Idle;
        _animator = transform.GetComponentInChildren<Animator>();
	}
	
	void Update () 
    {
        for (int i = 0; i < this.ActiveAreas.Count; i++)
        {
            if (Emmon.Instance.CurrentArea == ActiveAreas[i])
            {
                _withEmmonInArea = true;
            }
        }

        if (_withEmmonInArea)
        {
            if (State == CritterState.Idle)
            {
                if (_timer > 0)
                {
                    _timer -= Time.deltaTime;

                    if (_timer <= 0)
                    {
                        int rand = Random.Range(0, 3);
                        if (rand == 0)
                            ChooseNewDestination();
                        else
                            _timer = _maxTimer;
                    }

                    var playerDistance = Vector3.Distance(Instance.transform.position, GameManager.Player.transform.position);
                    if (playerDistance < 2f)
                    {
                        _timer = 0f;
                        ChooseNewDestination();
                    }
                }
                else
                    _timer = _maxTimer;
            }

            else if (CurrentDestinationGoal != null)
            {
                Vector3 moveDir = CurrentDestinationGoal.position - Instance.transform.position;
                // Rotate towards the target
                Instance.transform.rotation = Quaternion.Slerp(Instance.transform.rotation, Quaternion.LookRotation(moveDir), _rotationSpeed * Time.deltaTime);
                Instance.transform.eulerAngles = new Vector3(0, Instance.transform.eulerAngles.y, 0);

                // move towards the target
                Instance.transform.position = Vector3.MoveTowards(Instance.transform.position, CurrentDestinationGoal.position, Time.deltaTime * _speed);
                var distance = Vector3.Distance(Instance.transform.position, CurrentDestinationGoal.position);
                if (distance < 1f)
                {
                    ReachPoint();
                }
            }
            _withEmmonInArea = false;
        }
	}

    public void ChooseNewDestination()
    {
        PreviousDestinationGoal = CurrentDestinationGoal;

        int rand = Random.Range(0, WanderLocations.Count - 1);
        CurrentDestinationGoal = WanderLocations[rand];

        if (CurrentDestinationGoal == PreviousDestinationGoal)
        {
            ChooseNewDestination();
        }
        else
            Run();
    }

    public void Run()
    {
        State = CritterState.Running;
        _animator.SetBool("Run", true);
    }

    public void ReachPoint()
    {
        CurrentDestinationGoal = null;
        State = CritterState.Idle;
        _animator.SetBool("Run", false);
    }
}
