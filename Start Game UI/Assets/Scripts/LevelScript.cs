using System.Collections;
using System.Collections.Generic;
using System.Runtime.Hosting;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelScript : MonoBehaviour {
	public void Level() {
        SceneManager.LoadScene(2);
    }
    public void Back()
    {
        SceneManager.LoadScene(0);
    }
}