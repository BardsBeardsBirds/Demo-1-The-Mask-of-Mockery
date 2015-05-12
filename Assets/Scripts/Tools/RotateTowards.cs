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

    public void Start()
    {
        GameManager.InCutScene = true;
    //    Debug.LogWarning("to the right " + Vector3.Angle(From.transform.right, Target.transform.position - From.transform.position) + " and to the left " + Vector3.Angle(-From.transform.right, Target.transform.position - From.transform.position));
        if (Vector3.Angle(From.transform.right, Target.transform.position - From.transform.position) < Vector3.Angle(-From.transform.right, Target.transform.position - From.transform.position))
        {
       //     Debug.Log("Turn Right");
            _leftRight = LeftRight.Right;
        }
        else
        {
      //      Debug.Log("Turn Left");
            _leftRight = LeftRight.Left;
        }
    }

    public void Update()
    {
      //  Debug.Log("bestemming: " + Target.position);
      //  Debug.Log("this is the rotate timer " + Timer);
        if (Timer > 0)
        {
            Timer -= Time.deltaTime;

            if (Timer <= 0)
            {
                EndTimer();
            }
            else
            {
              //  Vector3 targetDir = Target.position - From.transform.position;
                if (Vector3.Angle(From.transform.forward, Target.transform.position - From.transform.position) > 5)
                {
                    if (_leftRight == LeftRight.Right)
                        CharacterControllerLogic.Instance.ForceTurningAngle(90);
                    else
                        CharacterControllerLogic.Instance.ForceTurningAngle(-90);
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
                        EndTimer();
                }

            }
        }
    }

    private void EndTimer()
    {
        Debug.Log("end Timer");
        CharacterControllerLogic.Instance.ForceSpeed(0);
        CharacterControllerLogic.Instance.ForceTurningAngle(0);
        if (Sentinel.PushBack)
        {
            GameManager.InCutScene = false;
            SentinelBlocker.IsBlocking = false;
            Sentinel.PushBack = false;
            CharacterControllerLogic.Instance.GoToIdleState();
        }
        GameManager.InCutScene = false;

        Destroy(this.gameObject);
    }
}
