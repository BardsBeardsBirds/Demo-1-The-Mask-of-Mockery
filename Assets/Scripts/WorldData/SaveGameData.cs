using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SaveGameData
{
    //public bool IsThisANewGame;
    public bool EmmonWasBlockedBySentinel;
    public bool EmmonHasRoughneckShot;
    public bool EmmonHasMaskOfMockery;
    public bool EmmonKnowsAy;
    public bool EmmonKnowsBenny;
    public bool BennyHasOfferedLute;
    public bool EmmonSawTheLute;
    public bool EmmonKnowsMaskLocation;
    public bool EmmonHasPassedTheSentinel;

    public bool PickedUpCarrot;
    public bool PickedUpMaskOfMockery;

    public int Carrot;
    public int RoughneckShot;
    public int MaskOfMockery;

    public int Rupee;
}
