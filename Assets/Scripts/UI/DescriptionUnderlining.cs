using UnityEngine;
using System.Collections;

public class DescriptionUnderlining : MonoBehaviour 
{
    private Animator _animator;

    public bool ShowNewDescription
    {
        get { return _animator.GetBool("ShowNew"); }
        set { _animator.SetBool("ShowNew", value); }
    }

	public void Start () 
    {
        _animator = GetComponent<Animator>();
	}

}
