using UnityEngine;
using System.Collections;

public class RotateTowards : MonoBehaviour
{
    private enum LeftRight { Left, Right };
    private LeftRight _leftRight = LeftRight.Right;
    public Transform From;
    public Transform Target;
    public float Speed;
    public float Timer;
    //private float _distance;

    public void Start()
    {
        Debug.LogWarning("to the right " + Vector3.Angle(From.transform.right, Target.transform.position - From.transform.position) + " and to the left " + Vector3.Angle(-From.transform.right, Target.transform.position - From.transform.position));
        
    //    _distance = Vector3.Distance(Target.transform.position, From.transform.position);

        if (Vector3.Angle(From.transform.right, Target.transform.position - From.transform.position) <= Vector3.Angle(-From.transform.right, Target.transform.position - From.transform.position))
        {
            Debug.Log("Turn Right");
            _leftRight = LeftRight.Right;
        }
        else
        {
            Debug.Log("Turn Left");
            _leftRight = LeftRight.Left;
        }
    }

    public void Update()
    {
       // Debug.Log("bestemming: " + Target.position);
    //    Debug.Log("this is the rotate timer " + Timer + " angle: " + Vector3.Angle(From.transform.forward, Target.transform.position - From.transform.position));
        if (Timer > 0)
        {
            Timer -= Time.deltaTime;

            if (Timer <= 0)
                EndTimer();
            else
            {

                if (Vector3.Angle(From.transform.forward, Target.transform.position - From.transform.position) > 5f) //only if we have to turn more than 5 degree
                {
                    if (_leftRight == LeftRight.Right && Vector3.Angle(-From.transform.right, Target.transform.position - From.transform.position) > 90)//we want to go right, but only if the angle towards the left is more than 90. Otherwise we turned too far.
                    {
                        CharacterControllerLogic.Instance.ForceTurningAngle(90);
                    }
                    else if (_leftRight == LeftRight.Left && Vector3.Angle(From.transform.right, Target.transform.position - From.transform.position) > 90) //we want to go left, but only if the angle towards the right is more than 90. Otherwise we turned too far.
                    {
                        //Debug.LogWarning("to the right " + Vector3.Angle(From.transform.right, Target.transform.position - From.transform.position));
                        CharacterControllerLogic.Instance.ForceTurningAngle(-90);
                    }
                    else
                    {
                        EndTimer();
                        Timer = 0;
                    }
                }
                else
                {
                    CharacterControllerLogic.Instance.ForceTurningAngle(0);

                    if (Sentinel.PushBack)
                    {
                        CharacterControllerLogic.Instance.ForceSpeed(1);
                        From.transform.position = Vector3.MoveTowards(From.transform.position, Target.position, 6 * Time.deltaTime);
                    }
                    else
                    {
                        EndTimer();
                        Timer = 0;
                    }
                }
            }
        }
    }

    private void EndTimer()
    {
        CharacterControllerLogic.Instance.ForceSpeed(0);
        CharacterControllerLogic.Instance.ForceTurningAngle(0);
        if (Sentinel.PushBack)
        {
            SentinelBlocker.IsBlocking = false;
            Sentinel.PushBack = false;
            CharacterControllerLogic.Instance.EndTalkingState();
        }
        Destroy(this.gameObject);
    }
}
