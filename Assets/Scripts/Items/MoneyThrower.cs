using System.Collections;
using UnityEngine;


public class MoneyThrower : MonoBehaviour
{
    private Animator animator;

    public void Awake()
    {
        animator = this.transform.gameObject.GetComponent<Animator>();
    }

    public void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= .99f && animator.GetCurrentAnimatorStateInfo(0).IsName("MoneyThrow"))
        {
            GameObject replacement;
            replacement = GameObject.Instantiate(Resources.Load("Prefabs/Items/Coinage/MoneyThrower30Replacer")) as GameObject;
            replacement.transform.parent = this.transform.parent;
            replacement.transform.localPosition = new Vector3(0, 0, 0);
            replacement.transform.rotation = replacement.transform.parent.rotation;
            GameManager.Destroy(this.transform.gameObject);         
        }
    }
}

