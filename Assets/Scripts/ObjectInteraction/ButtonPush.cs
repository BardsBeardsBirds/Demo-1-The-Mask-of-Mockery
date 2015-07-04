using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPush : MonoBehaviour
{
    public static ButtonPush Instance;

    public enum ButtonTypes { Chest, MuseumDoorButton, Other };

    public ButtonTypes ButtonType;
    public bool InRange = false;
    public bool ChestIsOpen = false;
    private Animator animator;
    private GameObject button;  //reference to button
    private GameObject _thrower;

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
            if (InRange && (animator.GetBool("Activated") == false) && Input.GetKeyDown(KeyCode.E)  )
            {
                ChestIsOpen = true;
            }
            else if (ChestIsOpen && (animator.GetBool("Activated") == false))
                    OpenChest();
        }        
    }

   public void OpenChest()
    {
        Debug.Log("PLAY");
        animator.SetBool("Activated", true);

        AudioManager.OpenChestAudio(Instance.transform.parent.gameObject);

        GameObject reward;
        reward = GameObject.Instantiate(Resources.Load("Prefabs/Items/Coinage/MoneyThrower30")) as GameObject;
        reward.transform.parent = this.transform.parent;
        reward.transform.localPosition = new Vector3(0, 0, 0);
        reward.transform.rotation = new Quaternion(0, 0, 0, 1);
        Animator coinAnimator = reward.transform.gameObject.GetComponent<Animator>();
        coinAnimator.SetBool("ThrowMoney", true);
        _thrower = reward;       
                
    }
}

