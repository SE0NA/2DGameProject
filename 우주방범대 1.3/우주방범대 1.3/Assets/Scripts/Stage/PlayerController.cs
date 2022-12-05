using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 키보드 입력에 대한 플레이어의 움직임, 공격 호출
 */

public class PlayerController : MonoBehaviour
{
    // 이동 (경계확인)
    [SerializeField] private float speed = 1.0f;
    private bool isTouchTop;
    private bool isTouchBottom;
    private bool isTouchRight;
    private bool isTouchLeft;

    // 공격 및 판정
    public int currentlevel;
    public GameObject lasorGreen;
    public GameObject lasorBlue;
    public GameObject lasorPink;
    TimingManager timingManager;
    AudioSource myAudioAS;
    public AudioClip lasorFx;
    public AudioClip beepFx;
    GameManager gameManager;

    // 피격
    Animator playerAnim;
    public AudioClip hitfx;

    // 노트 센터 연결
    public GameObject Center;
    Vector3 centerDefaultScale;

    ESCMenu escMenu;

    private void Start()
    {
        isTouchTop = false; isTouchBottom = false; isTouchRight = false; isTouchLeft = false;
        timingManager = FindObjectOfType<TimingManager>();
        gameManager = FindObjectOfType<GameManager>();
        escMenu = FindObjectOfType<ESCMenu>();
        playerAnim = GetComponent<Animator>();
        myAudioAS = GetComponent<AudioSource>();
        centerDefaultScale = Center.transform.localScale;
    }

    private void Update()
    {
        if (!escMenu.isPop)
        {
            PlayerMove();
            PlayerAttack();
        }
    }

    private void PlayerMove()
    {
        // 플레이어 이동
        float x = Input.GetAxisRaw("Horizontal");
        if ((isTouchRight && x == 1) || (isTouchLeft && x == -1)) x = 0;
        float y = Input.GetAxisRaw("Vertical");
        if ((isTouchTop && y == 1) || (isTouchBottom && y == -1)) y = 0;

        Vector3 curpos = transform.position;
        Vector3 nextpos = new Vector3(x, y, 0) * speed * Time.deltaTime;
        transform.position = curpos + nextpos;
    }

    private void PlayerAttack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Center.transform.localScale = centerDefaultScale * 1.2f;
            currentlevel = timingManager.CheckTiming(); // currentlevel 값에 따른 공격, 점수
            GameObject lasor;
            switch (currentlevel)
            {
                case 0:     // perfect
                    gameManager.perfectCnt++;
                    myAudioAS.PlayOneShot(lasorFx);
                    lasor = Instantiate(lasorGreen, transform.position + new Vector3(0, 0.5f), transform.rotation);
                    break;
                case 1:     // good
                    gameManager.goodCnt++;
                    myAudioAS.PlayOneShot(lasorFx);
                    lasor = Instantiate(lasorBlue, transform.position + new Vector3(0, 0.5f), transform.rotation);
                    break;
                case 2:     // bad
                    gameManager.badCnt++;
                    myAudioAS.PlayOneShot(lasorFx);
                    lasor = Instantiate(lasorPink, transform.position + new Vector3(0, 0.5f), transform.rotation);
                    break;
                case -1:    // miss
                    myAudioAS.PlayOneShot(beepFx);
                    break;
            }
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            Center.transform.localScale = centerDefaultScale;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "PlayerBorder")      // 플레이어 이동 경계
        {
            switch (collision.gameObject.name)
            {
                case "Top":
                    isTouchTop = true;
                    break;
                case "Bottom":
                    isTouchBottom = true;
                    break;
                case "Left":
                    isTouchLeft = true;
                    break;
                case "Right":
                    isTouchRight = true;
                    break;
            }
        }
        else if(collision.gameObject.tag == "EnemyAttack")  // 플레이어가 피격당함
        {
            myAudioAS.PlayOneShot(hitfx);
            playerAnim.Play("playerHitAnim");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBorder")     // 플레이어 이동 경계
        {
            switch (collision.gameObject.name)
            {
                case "Top":
                    isTouchTop = false;
                    break;
                case "Bottom":
                    isTouchBottom = false;
                    break;
                case "Left":
                    isTouchLeft = false;
                    break;
                case "Right":
                    isTouchRight = false;
                    break;
            }
        }
    }
}
