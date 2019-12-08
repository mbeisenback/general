using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeScript : MonoBehaviour
{
    public void Reset(string Scene)
    {
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }

    public void MainMenu(string Scene)
    {
        SceneManager.LoadScene("Opening", LoadSceneMode.Single);
    }
}