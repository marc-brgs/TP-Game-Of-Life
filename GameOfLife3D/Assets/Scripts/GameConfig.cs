using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameConfig : MonoBehaviour
{
    public static GameConfig instance;
    public string gameMode;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(instance);
    }

    public void launchGame(string mode)
    {
        gameMode = mode;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
