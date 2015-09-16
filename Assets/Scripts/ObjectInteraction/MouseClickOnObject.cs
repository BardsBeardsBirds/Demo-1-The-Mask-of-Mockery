using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MouseClickOnObject : MonoBehaviour
{
    public MouseClickOnObject Instance;
    public static bool MouseIsOnInvestigateButton = false;
    public static bool MouseIsOnInteractionButton = false;

    public ObjectsInLevel MyObject;
    public static ObjectsInLevel CurrentObject;
    public float depthIntoScene = 10;   

    public float defaultDepthIntoScene = 5;
    public float selectScale = .3f;

    private Text _descriptionText;

    private ActionPanel _actionPanel;

    #region ObjectsInLevel

    //This is the line that appears when the player hovers over an object
    public static Dictionary<ObjectsInLevel, string> ObjectLines = new Dictionary<ObjectsInLevel, string>() 
    {
        {ObjectsInLevel.Null, "Object is null"},
        {ObjectsInLevel.BennyTwospoons, "Grumpy clown"},
        {ObjectsInLevel.AyTheTearCollector, "Masked guy"},
        {ObjectsInLevel.Sentinel, "Sentinel"},
        {ObjectsInLevel.ArmadilloCostume, "Armadillo costume"},
        {ObjectsInLevel.Gorilla, "Gorilla costume"},
        {ObjectsInLevel.Lute, "Lute"},
        {ObjectsInLevel.CashMachine, "Cash machine"},
        {ObjectsInLevel.ClownNoses, "Clown noses"},
        {ObjectsInLevel.SneezePowder, "Sneeze Powder"},
        {ObjectsInLevel.TwoSpoonsPainting1, "Painting"},
        {ObjectsInLevel.TwoSpoonsPainting2, "Painting"},
        {ObjectsInLevel.TwoSpoonsPainting3, "Painting"},
        {ObjectsInLevel.TwoSpoonsWallPainting, "Wall painting"},
        {ObjectsInLevel.Wigs, "Wigs"},
        {ObjectsInLevel.Hatch, "Hatch"},
        {ObjectsInLevel.Marionet, "Marionet"},
        {ObjectsInLevel.ClownCertificate, "Certificate"},
        {ObjectsInLevel.LapelFlowers, "Squirting lapel flowers"},
        {ObjectsInLevel.ExplodingCandles, "Candles"},
        {ObjectsInLevel.RockingHorse, "Rocking horse"},

        {ObjectsInLevel.TheTwoSpoonsSign, "Sign"},
        {ObjectsInLevel.BeehiveHut, "Guard house"},
        {ObjectsInLevel.Carrot, "Carrot"},
        {ObjectsInLevel.TearCollectorSkull, "Creepy mask"},
        {ObjectsInLevel.TreasureChest, "Treasure chest"},

        {ObjectsInLevel.CaveSign, "Sign"},

        {ObjectsInLevel.MuseumDoor, "Door"},
        {ObjectsInLevel.ApathyHead, "Strange head"},
        {ObjectsInLevel.MuseumLeftPanel, "Wall drawings"},
        {ObjectsInLevel.MuseumMiddlePanelLeft, "Panel"},
        {ObjectsInLevel.MuseumMiddlePanelMiddle, "Panel"},
        {ObjectsInLevel.MuseumMiddlePanelRight, "Panel"},
        {ObjectsInLevel.MuseumRightPanel, "Panel"},
        {ObjectsInLevel.MuseumRightPanelTower, "Tower"},
        {ObjectsInLevel.MuseumRightPanelCynicism, "Mysterious person"},
        {ObjectsInLevel.MuseumRightPanelCrater, "Village"},
        {ObjectsInLevel.MuseumRightPanelOffering, "Sacrificial offering"},
        {ObjectsInLevel.SideDoor, "Door"},
        {ObjectsInLevel.DamagedWall, "Damaged wall"},
        {ObjectsInLevel.MaskOfMockery, "Mask of Mockery"},
        {ObjectsInLevel.Wheel1, "Wheel"},
        {ObjectsInLevel.Wheel2, "Wheel"},
        {ObjectsInLevel.Wheel3, "Wheel"},
        {ObjectsInLevel.Wheel4, "Wheel"},
        {ObjectsInLevel.Wheel5, "Wheel"},
        {ObjectsInLevel.Wheel6, "Wheel"},
        {ObjectsInLevel.Rabbit, "Rabbit"},
    };

    public static Dictionary<ObjectsInLevel, string> ObjectInteractionLines = new Dictionary<ObjectsInLevel, string>() 
    {
        {ObjectsInLevel.Null, "Object is null"},
        {ObjectsInLevel.BennyTwospoons, "Talk to grumpy clown"},
        {ObjectsInLevel.AyTheTearCollector, "Talk to masked guy"},
        {ObjectsInLevel.Sentinel, "Talk to sentinel"},
        {ObjectsInLevel.ArmadilloCostume, "Put on armadillo costume"},
        {ObjectsInLevel.Gorilla, "Take gorilla costume"},
        {ObjectsInLevel.Lute, "Pick up lute"},
        {ObjectsInLevel.CashMachine, "Pick up the cash machine"},
        {ObjectsInLevel.ClownNoses, "Put on a clowns nose"},
        {ObjectsInLevel.SneezePowder, "Take some sneeze Powder"},
        {ObjectsInLevel.TwoSpoonsPainting1, "Pick up painting"},
        {ObjectsInLevel.TwoSpoonsPainting2, "Pick up painting"},
        {ObjectsInLevel.TwoSpoonsPainting3, "Pick up painting"},
        {ObjectsInLevel.TwoSpoonsWallPainting, "Pick up wall Painting"},
        {ObjectsInLevel.Wigs, "Pick up a wig"},
        {ObjectsInLevel.Hatch, "Open hatch"},
        {ObjectsInLevel.Marionet, "Pick up marionet"},
        {ObjectsInLevel.ClownCertificate, "Pick up certificate"},
        {ObjectsInLevel.LapelFlowers, "Pick up squirting lapel flowers"},
        {ObjectsInLevel.ExplodingCandles, "Pick up a candle"},
        {ObjectsInLevel.RockingHorse, "Pick up the rocking horse"},

        {ObjectsInLevel.TheTwoSpoonsSign, "Pick up the sign"},
        {ObjectsInLevel.BeehiveHut, "Pick up the guard house"},
        {ObjectsInLevel.Carrot, "Pick up the carrot"},
        {ObjectsInLevel.TearCollectorSkull, "Talk to creepy mask"},
        {ObjectsInLevel.TreasureChest, "Open chest"},

        {ObjectsInLevel.CaveSign, "Pick up the sign"},

        {ObjectsInLevel.MuseumDoor, "Open door"},
        {ObjectsInLevel.ApathyHead, "Pick up strange head"},
        {ObjectsInLevel.MuseumLeftPanel, "Pick up wall drawings"},
        {ObjectsInLevel.MuseumMiddlePanelLeft, "Pick up panel"},
        {ObjectsInLevel.MuseumMiddlePanelMiddle, "Pick up panel"},
        {ObjectsInLevel.MuseumMiddlePanelRight, "Pick up panel"},
        {ObjectsInLevel.MuseumRightPanel, "Pick up panel"},
        {ObjectsInLevel.MuseumRightPanelTower, "Pick up tower"},
        {ObjectsInLevel.MuseumRightPanelCynicism, "Pick up mysterious person"},
        {ObjectsInLevel.MuseumRightPanelCrater, "Pick up village"},
        {ObjectsInLevel.MuseumRightPanelOffering, "Pick up sacrificial offering"},
        {ObjectsInLevel.SideDoor, "Open door"},
        {ObjectsInLevel.DamagedWall, "Hit damaged wall"},
        {ObjectsInLevel.MaskOfMockery, "Pick up the Mask of Mockery"},
        {ObjectsInLevel.Wheel1, "Turn wheel"},
        {ObjectsInLevel.Wheel2, "Turn wheel"},
        {ObjectsInLevel.Wheel3, "Turn wheel"},
        {ObjectsInLevel.Wheel4, "Turn wheel"},
        {ObjectsInLevel.Wheel5, "Turn wheel"},
        {ObjectsInLevel.Wheel6, "Turn wheel"},
        {ObjectsInLevel.Rabbit, "Pick up rabbit"},
    };

    public static Dictionary<ObjectsInLevel, string> ObjectInvestigationLines = new Dictionary<ObjectsInLevel, string>() 
    {
        {ObjectsInLevel.Null, "Object is null"},
        {ObjectsInLevel.BennyTwospoons, "Investigate grumpy clown"},
        {ObjectsInLevel.AyTheTearCollector, "Investigate masked guy"},
        {ObjectsInLevel.Sentinel, "Investigate sentinel"},
        {ObjectsInLevel.ArmadilloCostume, "Investigate armadillo costume"},
        {ObjectsInLevel.Gorilla, "Investigate gorilla costume"},
        {ObjectsInLevel.Lute, "Investigate lute"},
        {ObjectsInLevel.CashMachine, "Investigate cash machine"},
        {ObjectsInLevel.ClownNoses, "Investigate clowns nose"},
        {ObjectsInLevel.SneezePowder, "Investigate sneeze powder"},
        {ObjectsInLevel.TwoSpoonsPainting1, "Investigate painting"},
        {ObjectsInLevel.TwoSpoonsPainting2, "Investigate painting"},
        {ObjectsInLevel.TwoSpoonsPainting3, "Investigate painting"},
        {ObjectsInLevel.TwoSpoonsWallPainting, "Investigate wall Painting"},
        {ObjectsInLevel.Wigs, "Investigate wigs"},
        {ObjectsInLevel.Hatch, "Investigate hatch"},
        {ObjectsInLevel.Marionet, "Investigate marionet"},
        {ObjectsInLevel.ClownCertificate, "Investigate certificate"},
        {ObjectsInLevel.LapelFlowers, "Investigate squirting lapel flowers"},
        {ObjectsInLevel.ExplodingCandles, "Investigate candle"},
        {ObjectsInLevel.RockingHorse, "Investigate rocking horse"},

        {ObjectsInLevel.TheTwoSpoonsSign, "Investigate sign"},
        {ObjectsInLevel.BeehiveHut, "Investigate guard house"},
        {ObjectsInLevel.Carrot, "Investigate carrot"},
        {ObjectsInLevel.TearCollectorSkull, "Investigate mask"},
        {ObjectsInLevel.TreasureChest, "Investigate treasure chest"},

        {ObjectsInLevel.CaveSign, "Investigate sign"},

        {ObjectsInLevel.MuseumDoor, "Investigate door"},
        {ObjectsInLevel.ApathyHead, "Investigate strange head"},
        {ObjectsInLevel.MuseumLeftPanel, "Investigate wall drawings"},
        {ObjectsInLevel.MuseumMiddlePanelLeft, "Investigate panel"},
        {ObjectsInLevel.MuseumMiddlePanelMiddle, "Investigate panel"},
        {ObjectsInLevel.MuseumMiddlePanelRight, "Investigate panel"},
        {ObjectsInLevel.MuseumRightPanel, "Investigate panel"},
        {ObjectsInLevel.MuseumRightPanelTower, "Investigate tower"},
        {ObjectsInLevel.MuseumRightPanelCynicism, "Investigate mysterious person"},
        {ObjectsInLevel.MuseumRightPanelCrater, "Investigate village"},
        {ObjectsInLevel.MuseumRightPanelOffering, "Investigate sacrificial offering"},
        {ObjectsInLevel.SideDoor, "Investigate door"},
        {ObjectsInLevel.DamagedWall, "Investigate damaged wall"},
        {ObjectsInLevel.MaskOfMockery, "Investigate the Mask of Mockery"},
        {ObjectsInLevel.Wheel1, "Investigate wheel"},
        {ObjectsInLevel.Wheel2, "Investigate wheel"},
        {ObjectsInLevel.Wheel3, "Investigate wheel"},
        {ObjectsInLevel.Wheel4, "Investigate wheel"},
        {ObjectsInLevel.Wheel5, "Investigate wheel"},
        {ObjectsInLevel.Wheel6, "Investigate wheel"},
        {ObjectsInLevel.Rabbit, "Investigate rabbit"},
    };

    #endregion


    public void Start()
    {
        Instance = this;

        if (MyObject == ObjectsInLevel.Null)
            Debug.LogWarning("This object has no name: " + Instance.name);

        _descriptionText = GameManager.Instance.UICanvas.ObjectDescriptionText;
        _actionPanel = new ActionPanel();
    }

    public void OnMouseDown()
    {
        if (GameManager.GamePlayingMode == GameManager.GameMode.Paused || GameManager.GamePlayingMode == GameManager.GameMode.IntroMode) // don't show if paused.
            return;

        ActionPanel.LastHoveredObject = MyObject;

        if (UIDrawer.IsDraggingItem)
        {
            bool tryCombine = false;
            tryCombine = GameManager.Instance.IIventoryItemWithObject.CombineItems(GameManager.Instance.MyInventory.TheDraggedItem, MyObject);
            if (tryCombine)
            {
                Debug.LogWarning("We can combine these two!!");
                GameManager.Instance.MyInventory.EndDragging(UIDrawer.DraggingFromSlotNo);
            }

        }
        else
        {
            ActionPanel.IsInInventory = false;
            _actionPanel.MoveActionPanelToClickedObject(false);   //show the action panel
        }
    }

    public void OnMouseExit()
    {
        if(UIDrawer.IsDraggingItem)
        {
            _descriptionText.text = UIDrawer.DraggingItem.ItemName;
            _descriptionText.enabled = true;
        }
        else if (!MouseIsOnInvestigateButton && !MouseIsOnInteractionButton)
            GameManager.Instance.UICanvas.HideObjectDescriptionText();
    }

    public void OnMouseUp()
    {
        ActionPanel.LastHoveredObject = ObjectsInLevel.Null;

        if (MouseIsOnInvestigateButton || MouseIsOnInteractionButton)
        {
            AudioManager.Instance.UISoundsScript.PlayClick();   // sound
            _actionPanel.PlayActionPanelForClickedObject(MyObject, this.transform);
            GameManager.Instance.UICanvas.HideObjectDescriptionText();
        }
        else
            ActionPanel.HideActionPanel();
    }

    public void OnMouseOver()
    {
        if (GameManager.GamePlayingMode == GameManager.GameMode.Paused || GameManager.GamePlayingMode == GameManager.GameMode.IntroMode) // don't show if paused.
            return;

        if (GameManager.Instance.UICanvas.Hovering != MainCanvas.Hoverings.MouseInWorld)
            return;
        
        CurrentObject = MyObject;

        _descriptionText.enabled = true;
        GameManager.Instance.UICanvas.NewObjectDescription();

        if (ActionPanel.LastHoveredObject == CurrentObject)
            return;

        if (!MouseIsOnInteractionButton || !MouseIsOnInvestigateButton)
        {
            if(UIDrawer.IsDraggingItem)
            {
                _descriptionText.text = "Use "
                    + GameManager.Instance.MyInventory.TheDraggedItem.ItemName + " with " + ObjectLines[MyObject];
            }
            else
            {
                _descriptionText.text = ObjectLines[MyObject];
                MyConsole.WriteToConsole(ObjectLines[MyObject]);
            }
        }
    }
}
