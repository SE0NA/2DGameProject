using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  (메인)적 오브젝트의 정보와 움직임, 피격시의 메서드 구현
 */

public class Enemy : MonoBehaviour
{
    // 점수 증가
    public int hitpoint = 0;

    // 공격 오브젝트 프리펩
    public List<GameObject> enemyAttack = null;

    // 이동
    public float speed = 5f;
    public float maxX = 0;
    public float minX = 0;
    public bool isRightDir = true;

    // 피격 애니메이션
    public bool isHitAnim = false;
    Animator enemyAnim;
    AudioSource myAudioAS;
    public AudioClip hitSoundFx;

    // 스크립트
    ScoreManager scoreManager;
    GameManager gameManager;
    ESCMenu escMenu;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        scoreManager = FindObjectOfType<ScoreManager>();
        escMenu = FindObjectOfType<ESCMenu>();
        enemyAnim = GetComponent<Animator>();
        myAudioAS = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!escMenu.isPop)
        {
            // 적 오브젝트는 좌우로 이동함
            if (isRightDir)  // 우측으로 이동
            {
                transform.position += speed * Vector3.right;
                if (transform.position.x >= maxX) isRightDir = false;   // maxX를 넘으면 좌측이동
            }
            else
            {
                transform.position += speed * Vector3.left;
                if (transform.position.x <= minX) isRightDir = true;    //minX를 넘으면 우측 이동
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)     
    {
        if (collision.gameObject.tag == "PlayerAttack") // 총알에 피격 > 애니메이션, 점수증가
        {
            int level = collision.GetComponent<PlayerAttack>().GetAttackLevel();    // 맞은 공격의 레벨값 저장
            Destroy(collision.gameObject);  // 맞은 총알은 파괴
            scoreManager.IncreaseScoreByAttackEnemy(level, hitpoint);   // 점수 증가(공격레벨, 적 레벨)

            // 피격 애니메이션 + 효과음
            myAudioAS.PlayOneShot(hitSoundFx);
            if (isHitAnim)
            {
                switch (level)
                {
                    case 0:
                        enemyAnim.Play("enemyHitGreen");
                        break;
                    case 1:
                        enemyAnim.Play("enemyHitBlue");
                        break;
                    case 2:
                        enemyAnim.Play("enemyHitPink");
                        break;
                }
            }
        }
    }
}
