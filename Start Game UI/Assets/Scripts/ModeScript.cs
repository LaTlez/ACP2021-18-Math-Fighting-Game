using System.Collections;
using System.Collections.Generic;
using System.Runtime.Hosting;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModeScript : MonoBehaviour {
    public void Mode()
    {
        SceneManager.LoadScene(0); // ต้องแก้ไขเป็น3
    }
    public void Back()
    {
        SceneManager.LoadScene(1);
    }
}