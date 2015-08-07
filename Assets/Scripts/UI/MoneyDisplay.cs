using UnityEngine;
using UnityEngine.UI;

public class MoneyDisplay : MonoBehaviour 
{
    public Text MoneyTxt;
    private string _rupeeHeld;

    public void Start()
    {
        _rupeeHeld = GameManager.Instance.RupeeHeld.ToString();
        MoneyTxt.text = _rupeeHeld;
    }

    public void DisplayDifferentAmount(int rupeeHeld)
    {
        _rupeeHeld = rupeeHeld.ToString();
        MoneyTxt.text = _rupeeHeld;
    }
}
