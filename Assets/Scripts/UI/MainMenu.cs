﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public GameObject loadingScreen;

    public void Play()
    {
        loadingScreen.SetActive(true);
        SceneManager.LoadScene("Scene/Beta 1");
    }

    public void PlayFromMenu()
    {
        SceneManager.LoadScene("HowToPlay");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void RetourMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene("HowToPlay");
    }
}
