using UnityEngine;
using UnityEngine.UI;

public class MoneyDisplay : MonoBehaviour 
{
    public Text MoneyTxt;
    private string _rupeeHeld;
    private Animator _animator;

    public bool Plus
    {
        get { return _animator.GetBool("Plus"); }
        set { _animator.SetBool("Plus", value); }
    }

    public bool Minus
    {
        get { return _animator.GetBool("Minus"); }
        set { _animator.SetBool("Minus", value); }
    }

    public void Start()
    {
        _animator = GetComponent<Animator>();
        _rupeeHeld = GameManager.Instance.RupeeHeld.ToString();
        MoneyTxt.text = _rupeeHeld;
    }

    public void DisplayDifferentAmount(int rupeeHeld)
    {
        _rupeeHeld = rupeeHeld.ToString();
        MoneyTxt.text = _rupeeHeld;
    }
}
