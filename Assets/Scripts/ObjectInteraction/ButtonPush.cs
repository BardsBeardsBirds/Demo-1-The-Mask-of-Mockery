using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPush : MonoBehaviour
{
    public static ButtonPush Instance;

    public enum ButtonTypes { Chest, MuseumDoorButton, Other };

    public ButtonTypes ButtonType;
    public bool InRange = false;

    private Animator animator;
    private GameObject button;  //reference to button


    private Vector2 uvOffset = Vector2.zero;

    public void Awake()
    {
        Instance = this;
        ButtonType = Instance.ButtonType;

        InRange = Instance.InRange;

        if (Instance.ButtonType == ButtonTypes.Chest)
        {
            animator = transform.parent.gameObject.GetComponent<Animator>();

            if (animator == null)
                return;

            animator.SetBool("Activated", false);
        }

        
    }

    public void OnTriggerEnter()
    {
        InRange = true;
    }

    public void OnTriggerExit()
    {
        InRange = false;
    }

    public void Update()
    {
        if (ButtonType == ButtonTypes.Chest)
        {
            if (InRange && (animator.GetBool("Activated") == false) && Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("PLAY");
                animator.SetBool("Activated", true);


                GameObject reward;
                reward = GameObject.Instantiate(Resources.Load("Prefabs/Items/Coinage/MoneyThrower30")) as GameObject;
                reward.transform.parent = this.transform.parent;
                reward.transform.localPosition = new Vector3(0, 0, 0);
                reward.transform.rotation = reward.transform.parent.rotation;
                Animator coinAnimator = reward.transform.gameObject.GetComponent<Animator>();
                coinAnimator.SetBool("ThrowMoney", true);
                
            }
        }        
    }

   
}

