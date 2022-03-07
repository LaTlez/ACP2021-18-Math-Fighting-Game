using UnityEngine;
using System.Collections;

public class BattleController : MonoBehaviour
{
    public int roundTime = 50;
    private float lastTimeUpdate = 0;
    private bool battleStarted; // เริ่มต่อสู้
    private bool battleEnded;   // จบเกม

    public Fighter player1; // ผู้เล่นคนที่ 1
    public Fighter player2;  // ผู้เล่นคนที่ 2
    public BannerController banner;  // แสดงเตรียมพร้อมต่อสู้
    public AudioSource musicPlayer;   // แหล่งกำเนิดเสียง
    public AudioClip backgroundMusic;  // เสียง Background
    public AudioClip p1win;    // เสียงตอนที่ผู้เล่น 1 ชนะ
    public AudioClip p2win;    // เสียงคนที่ 2
    
    void Start()
    {
        banner.showRoundFight(); 
    }

    // เช็คว่าผู้เล่นคนไหนชนะตอนหมดเวลา
    private void expireTime()
    {
        if (player1.healthPercent > player2.healthPercent)
        {
            player2.health = 0;
            SoundManager.playsound(p1win, musicPlayer);
        }
        else
        {
            player1.health = 0;
            SoundManager.playsound(p2win, musicPlayer);
        }
    }

    void Update()
    {
        // เริ่มต้นเกมโดยรอ Banner ให้เล่นเสร็จก่อน
        if (!battleStarted && !banner.isAnimating)
        {
            battleStarted = true;

            player1.enable = true;
            player2.enable = true;

            SoundManager.playsound(backgroundMusic, musicPlayer);
        }

        if (battleStarted && !battleEnded)
        {
            if (roundTime > 0 && Time.time - lastTimeUpdate > 1)
                roundTime--;
            {
                lastTimeUpdate = Time.time;
                if (roundTime == 0)
                {
                    expireTime();
                }
            }
            
            // กรณีต่อสู้กัน
            if (player1.healthPercent <= 0)
            {
                battleEnded = true;
                SoundManager.playsound(p2win, musicPlayer);

            }
            else if (player2.healthPercent <= 0)
            {
                battleEnded = true;
                SoundManager.playsound(p1win, musicPlayer);
            }
        }
    }
}

