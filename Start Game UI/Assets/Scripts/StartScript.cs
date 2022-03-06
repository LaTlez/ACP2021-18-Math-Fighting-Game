using System.Collections;
using System.Collections.Generic;
using System.Runtime.Hosting;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour {
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
        Application.Quit();
        UnityEngine.Debug.Log("EXIT!");
    }
}
