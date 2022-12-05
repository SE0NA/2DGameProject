using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  스테이지에서 생성되는 공격에 대한 스크립트
 */

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] int point = 0;         // 피격 점수
    [SerializeField] float speed = 15f;
    
    AudioSource myAudioAS;
    public AudioClip AttackFx;
    public AudioClip DestoryFx;

    // 오브젝트 위치
    GameObject player = null;
    Vector3 moveDir;    // 오브젝트 방향

    // 스크립트
    ScoreManager scoreManager;
    GameManager gameManager;
    ESCMenu escMenu;

    void Start()
    {
        myAudioAS = GetComponent<AudioSource>();
        scoreManager = FindObjectOfType<ScoreManager>();
        gameManager = FindObjectOfType<GameManager>();
        player = FindObjectOfType<PlayerController>().gameObject;
        escMenu = FindObjectOfType<ESCMenu>();
        moveDir = (player.transform.position - transform.position).normalized;
    }
    
    void Update()
    {
        if (!escMenu.isPop)
        {
            transform.position += moveDir * speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")   // 플레이어를 맞춤
        {
            scoreManager.DecreaseScoreByHit();
            AttackSound();
            Destroy(gameObject);
        }
        else if(collision.gameObject.tag == "PlayerAttack") // 플레이어 공격에 의해 피격당함(파괴)
        {
            int level = collision.gameObject.GetComponent<PlayerAttack>().GetAttackLevel();
            scoreManager.IncreaseScoreByAttackEnemy(level, point);
            Destroy(collision.gameObject);  // 플레이어 공격 오브젝트 파괴
            Destroy(gameObject);
        }
        else if(collision.gameObject.tag == "AttackBorder") // 경계에 닿으면 파괴
        {
            Destroy(gameObject);   
        }
    }
    
    private void AttackSound()
    {
        myAudioAS.PlayOneShot(AttackFx);
    }
}
