using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel;
    private bool menuOn = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !menuOn)
        {
            menuOn = true;
            PausePanel.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && menuOn)
        {
            PausePanel.SetActive(false);
            menuOn = false;
        }
    }

    public void Pause()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Continue()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1;
    }
}
