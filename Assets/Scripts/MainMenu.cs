using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public void OpenOrClosePanel(GameObject panel)
    {
        var panelAnimator = panel.GetComponent<Animator>();

        if (panelAnimator != null && panel.activeSelf)
        {
            panelAnimator.SetTrigger("ClosePan");
            return;
        }

        if (!panel.activeSelf) panel.SetActive(true);
        else panel.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}