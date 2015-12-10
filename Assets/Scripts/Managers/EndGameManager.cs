using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EndGameManager
{
    public void EndingSequence()
    {
        GameObject sceneFaderGO = GameObject.Instantiate(Resources.Load("Prefabs/UI/ScreenFaderClearToBlack")) as GameObject;
        sceneFaderGO.transform.SetParent(GameObject.Find("Canvas").transform);
        SceneFader fader = sceneFaderGO.GetComponent<SceneFader>();
        fader.BlackFader = SceneFader.ToBlack.FinishGame;
        fader.IsFadingToBlack = true;
        //GameObject sceneFaderGO = GameObject.Instantiate(Resources.Load("Prefabs/UI/ScreenFader")) as GameObject;
        //sceneFaderGO.transform.parent = GameObject.Find("Canvas").transform;
        //RectTransform rectT = sceneFaderGO.GetComponent<RectTransform>();
        //Image blackImage = sceneFaderGO.GetComponent<Image>();
        //blackImage.color = new Color(0, 0, 0, 0);
        //rectT.anchoredPosition = new Vector2(0, 0); ;
        //SceneFader sceneFader = sceneFaderGO.GetComponent<SceneFader>();
        //sceneFader.SceneEnding = true;

    }
}
