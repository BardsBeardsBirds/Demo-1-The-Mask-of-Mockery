using UnityEngine;
using System.Collections;

public class Widget : MonoBehaviour 
{
    private Animator _animator;

    public bool WidgetActive
    {
        get { return _animator.GetBool("IsActive"); }
        set { _animator.SetBool("IsActive", value); }
    }



    public void Awake()
    {
        _animator = GetComponent<Animator>();
    }
}
