using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GateWheel : ButtonPush
{
    public static GateWheel Instance;

    public enum Wheels { Wheel1, Wheel2, Wheel3, Wheel4, Wheel5, Wheel6 };
    public enum WheelColours { Blue, Other };

    public List<WheelColours> WheelButtonColours = new List<WheelColours>();
    public Wheels WheelNumber;
    public Wheels OriginalNumber;
    public static bool WheelTurns = false;
    public static int AmountOfBlueButtons = 1;

    private float _wheelTimer = 0;
    private int _rotatorTimer = 0;
    private int _wheelColourIndex = 0;
    private int _blueIndex = 0;
    private static int _wheelNumber = 0;

    public new void  Awake()
    {
     //   Instance = this;

   //     WheelNumber = Instance.WheelNumber;
        OriginalNumber = this.WheelNumber;
        _wheelColourIndex = 0;

        switch (WheelNumber)
        {
            case Wheels.Wheel1:
                _blueIndex = 5;
                WheelButtonColours.Add(WheelColours.Other);
                WheelButtonColours.Add(WheelColours.Other);
                WheelButtonColours.Add(WheelColours.Other);
                WheelButtonColours.Add(WheelColours.Other);
                WheelButtonColours.Add(WheelColours.Other);
                WheelButtonColours.Add(WheelColours.Blue);
                WheelButtonColours.Add(WheelColours.Other);
                break;
            case Wheels.Wheel2:
                _blueIndex = 5;
                WheelButtonColours.Add(WheelColours.Other);
                WheelButtonColours.Add(WheelColours.Other);
                WheelButtonColours.Add(WheelColours.Other);
                WheelButtonColours.Add(WheelColours.Other);
                WheelButtonColours.Add(WheelColours.Other);
                WheelButtonColours.Add(WheelColours.Blue);
                WheelButtonColours.Add(WheelColours.Other);
                break;
            case Wheels.Wheel3:
                _blueIndex = 3;
                WheelButtonColours.Add(WheelColours.Other);
                WheelButtonColours.Add(WheelColours.Other);
                WheelButtonColours.Add(WheelColours.Other);
                WheelButtonColours.Add(WheelColours.Blue);
                WheelButtonColours.Add(WheelColours.Other);
                WheelButtonColours.Add(WheelColours.Other);
                WheelButtonColours.Add(WheelColours.Other);
                break;
            case Wheels.Wheel4:
                _blueIndex = 3;
                WheelButtonColours.Add(WheelColours.Other);
                WheelButtonColours.Add(WheelColours.Other);
                WheelButtonColours.Add(WheelColours.Other);
                WheelButtonColours.Add(WheelColours.Blue);
                WheelButtonColours.Add(WheelColours.Other);
                WheelButtonColours.Add(WheelColours.Other);
                WheelButtonColours.Add(WheelColours.Other);
                break;
            case Wheels.Wheel5:
                _blueIndex = 4;
                WheelButtonColours.Add(WheelColours.Other);
                WheelButtonColours.Add(WheelColours.Other);
                WheelButtonColours.Add(WheelColours.Other);
                WheelButtonColours.Add(WheelColours.Other);
                WheelButtonColours.Add(WheelColours.Blue);
                WheelButtonColours.Add(WheelColours.Other);
                WheelButtonColours.Add(WheelColours.Other);
                break;
            case Wheels.Wheel6:
                _blueIndex = 0;
                WheelButtonColours.Add(WheelColours.Blue);
                WheelButtonColours.Add(WheelColours.Other);
                WheelButtonColours.Add(WheelColours.Other);
                WheelButtonColours.Add(WheelColours.Other);
                WheelButtonColours.Add(WheelColours.Other);
                WheelButtonColours.Add(WheelColours.Other);
                WheelButtonColours.Add(WheelColours.Other);
                break;
        }
    }

    public void Update()
    {
        if (InRange && ButtonType == ButtonTypes.MuseumDoorButton && Input.GetKeyDown(KeyCode.E))
        {
            WheelTurns = true;
        }

        if (WheelTurns)
        {
            string transName = "Wheel" + _wheelNumber;
            Transform wheel = this.transform.parent.transform.FindChild(transName);

            if (wheel == null)
                return;

            WheelTurnTimer(wheel);
        }
    }

    private void WheelTurnTimer(Transform wheel)
    {
        var degreesToTurn = 51.42f / 15f; //amount of degrees to turn = 51.42

        wheel.gameObject.transform.Rotate(new Vector3(0, degreesToTurn, 0));
        var wheelRotationAngle = wheel.gameObject.transform.rotation.y;
        //  Debug.LogWarning("Turn it around" + wheelRotationAngle + " index " + index);

        _rotatorTimer = _rotatorTimer + 1;

        if (_rotatorTimer == 15)
        {
            WheelTurns = false;
            _rotatorTimer = 0;
            _wheelColourIndex = _wheelColourIndex + 1;
            if (_wheelColourIndex == 7)
                _wheelColourIndex = 0;

            if (WheelButtonColours[_wheelColourIndex] == WheelColours.Blue)
                AmountOfBlueButtons = AmountOfBlueButtons + 1;

            if (_wheelColourIndex == _blueIndex + 1 || (_wheelColourIndex == 0 && _blueIndex == 6))
                AmountOfBlueButtons = AmountOfBlueButtons - 1;
            //   Debug.LogWarning("how many blue? " + AmountOfBlueButtons);
        }
    }

    public static void ChooseWheelNumber(int number)
    {
        _wheelNumber = number;
        WheelTurns = true;
    }
}

