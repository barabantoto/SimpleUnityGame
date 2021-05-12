using System.Collections;
using UnityEngine;

public class ForButton : MonoBehaviour
{
    public Canvas SettingsCanvas;
    public GameObject Panel;
    public ForGame game;
    public bool FirstTime;
    private void Start()
    {
        StartCoroutine(Delay());
    }
    public void OnClick()
    {
        if (Time.timeScale == 1) Time.timeScale = 0;
        else Time.timeScale = 1;
        SettingsCanvas.enabled = !SettingsCanvas.enabled;

    }
    IEnumerator Delay()
    {
        yield return new WaitForSecondsRealtime(0.001f);
        SettingsCanvas.enabled = false;
    }
}
