using UnityEngine;
using System.Collections;

public class BannerController : MonoBehaviour
{

    private Animator animator;
    private AudioSource audioPlayer;

    private bool animating;
    void Start()
    {
        animator = GetComponent<Animator>();
        audioPlayer = GetComponent<AudioSource>();

    }

    public void showRoundFight()
    {
        animating = true;
        animator.SetTrigger("SHOW_ROUND_FIGHT");
    }


    public void playVoice(AudioClip voice)
    {
        SoundManager.playsound(voice, audioPlayer);
    }

    public void animationEnded()
    {
        animating = false;
    }

    public bool isAnimating
    {
        get
        {
            return animating;
        }
    }
}

