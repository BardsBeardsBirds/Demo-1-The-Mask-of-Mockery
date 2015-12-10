using System.Collections;
using UnityEngine;


public class MoneyThrower : MonoBehaviour
{
    private Animator _animator;

    public void Awake()
    {
        _animator = this.transform.gameObject.GetComponent<Animator>();
    }

    public void Update()
    {
        if (_animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= .98f && _animator.GetCurrentAnimatorStateInfo(0).IsName("MoneyThrow"))
        {
            GameObject replacement;
            replacement = GameObject.Instantiate(Resources.Load("Prefabs/Items/Coinage/MoneyThrower30Replacer")) as GameObject;
            replacement.transform.parent = this.transform.parent;
            replacement.transform.localPosition = new Vector3(0, 0, 0);
            replacement.transform.rotation = new Quaternion(0, 0, 0, 1);

            GameManager.Destroy(this.transform.gameObject);         
        }
    }
}

