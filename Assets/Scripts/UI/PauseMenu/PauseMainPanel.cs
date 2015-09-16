using UnityEngine;

public class PauseMainPanel : MonoBehaviour
{
    private Animator _animator;

    public bool MainPanelOpen
    {
        get { return _animator.GetBool("IsOpen"); }
        set { _animator.SetBool("IsOpen", value); }
    }

    public void Awake()
    {
        _animator = GetComponent<Animator>();
    }
}

