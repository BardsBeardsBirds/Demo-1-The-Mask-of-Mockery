using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour 
{
    public string LevelToLoad;

    public Text BarText;
    public Image Background;
    public Image ProgressBar;

    private int _loadProgress = 0;

    public void Awake()
    {
        BarText.gameObject.SetActive(false);
        Background.gameObject.SetActive(false);
        ProgressBar.gameObject.SetActive(false);
    }


    public void Update()
    {

    }

    public void LoadLevel(string level)
    {
        StartCoroutine(DisplayLoadingScreen(LevelToLoad));
    }

    IEnumerator DisplayLoadingScreen(string level)
    {
        BarText.gameObject.SetActive(true);
        Background.gameObject.SetActive(true);
        ProgressBar.gameObject.SetActive(true);

        ProgressBar.transform.localScale = new Vector3(_loadProgress, ProgressBar.transform.localScale.y, ProgressBar.transform.localScale.z);

        BarText.text = "Loading Progress " + _loadProgress + "%";

        AsyncOperation async = Application.LoadLevelAsync(level);
        while (!async.isDone)
        {
            _loadProgress = (int)(async.progress * 100);

            BarText.text = "Loading Progress " + _loadProgress + "%";
            ProgressBar.transform.localScale = new Vector3(async.progress, ProgressBar.transform.localScale.y, ProgressBar.transform.localScale.z);
       
            yield return null;
        }
    }
}
