using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void OnStartBtnClicked()
    {
        SceneManager.LoadScene(1);
    }

    public void OnTutorialBtnClicked()
    {
        SceneManager.LoadScene(5);
    }

    public void OnCreditsBtnClicked()
    {
        SceneManager.LoadScene(6);
    }

    public void OnExitBtnClicked()
    {
        Application.Quit();
    }
}
