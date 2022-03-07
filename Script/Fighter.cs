using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour {

    // สร้างประเภทของผู้เล่น
    public enum PlayerType
    {
        Player1, Player2
    };

    public static float MAX_HEALTH = 1000f;
    public float health = MAX_HEALTH;  // ค่าพลังชีวิตปัจจุบัน 1000/1000 => 900/1000
    public string fighterName;    // ตั้งชื่อให้กับผู้เล่น
    public Fighter oponent;    //   อ้างอิง object
    public bool enable;        // กำหนดสถานะผู้เล่น
    public PlayerType player;
    // เริ่มต้นให้ยืน
    public FighterState currentState = FighterState.IDLE;


    public Rigidbody mybody;
    protected Animator animator;
    private AudioSource audio;

    // Use this for initialization
    void Start() {
        mybody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {

        animator.SetFloat("HEALTH", healthPercent);
        if (oponent != null)
        {
            animator.SetFloat("OPPONENT", oponent.healthPercent);
        }
        else
        {
            animator.SetFloat("OPPONENT", 1);
        }
        if (health <= 0 && currentState != FighterState.DEAD)
        {
            animator.SetTrigger("DEAD");
        }


        // แยกประเภทและรับ Input จากผู้เล่น
        if (enable)
        {
            if (player == PlayerType.Player1)
            {
                ControlPlayer1();
            }
            else
            {
                ControlPlayer2();
            }
        }



    }
    public void ControlPlayer1()
    {
        if (Input.GetAxis("Horizontal1") > 0.1)
        {
            animator.SetBool("WALK", true);
        }
        else
        {
            animator.SetBool("WALK", false);
        }

        if (Input.GetAxis("Horizontal1") < -0.1)
        {
            animator.SetBool("WALK_BACK", true);
        }
        else
        {
            animator.SetBool("WALK_BACK", false);
        }

        if (Input.GetAxis("Vertical1") < -0.1)
        {
            animator.SetBool("SIT", true);
        }
        else
        {
            animator.SetBool("SIT", false);
        }
        if (Input.GetAxis("Vertical1") < -0.1)
        {
            animator.SetBool("SIT", true);
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            animator.SetTrigger("JUMP");

        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            animator.SetTrigger("PUNCH");
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            animator.SetTrigger("KICK");
        }


    }

    public void ControlPlayer2()
    {
        if (Input.GetAxis("Horizontal2") > 0.1)
        {
            animator.SetBool("WALK", true);
        }
        else
        {
            animator.SetBool("WALK", false);
        }
        if (Input.GetAxis("Horizontal2") < -0.1)
        {
            animator.SetBool("WALK_BACK", true);
        }
        else
        {
            animator.SetBool("WALK_BACK", false);
        }

        if (Input.GetAxis("Vertical2") < -0.1)
        {
            animator.SetBool("SIT", true);
        }
        else
        {
            animator.SetBool("SIT", false);
        }
        if (Input.GetAxis("Vertical2") < -0.1)
        {
            animator.SetBool("SIT", true);
        }


        if (Input.GetKeyDown(KeyCode.G))
        {
            animator.SetTrigger("JUMP");
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            animator.SetTrigger("PUNCH");
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            animator.SetTrigger("KICK");
        }
    }

    public void playsound(AudioClip sound)
    {
        SoundManager.playsound(sound, audio);
    }

    public bool defending
    {
        get
        {
            return currentState == FighterState.DEFEND
                || currentState == FighterState.TAKE_HIT_DEFEND;
        }
    }

    public bool attacking
    {
        get
        {
            return currentState == FighterState.ATTACK;
        }
    }

    // ดึงพลังชีวิต 1000/1000 => 950/1000
    public float healthPercent
    {
        get
        {
            return health / MAX_HEALTH;
        }
    }

    public Rigidbody body
    {
        get
        {
            return this.mybody;
        }
    }

    // ลดพลังชีวิตตาม damage ที่ได้รับ
    // 1000 - 50
    public virtual void takeDamage(float damage)
    {
        if (defending)
        {
            damage *= 0.2f;
        }
        if (health >= damage)
        {
            health -= damage;
        }
        else
        {
            health = 0;
        }
        if (health > 0)
        {
            animator.SetTrigger("TAKE_HIT");
        }
    }
}
