using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour { 

    public static void playsound(AudioClip clip, AudioSource audioplay)
    {
        audioplay.Stop();
        audioplay.clip = clip;
        audioplay.loop = false;
        audioplay.time = 0;
        audioplay.Play();
    }
		
	
}
