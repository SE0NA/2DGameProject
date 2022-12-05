using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  플레이어의 공격(레이저)에 적용되는 스크립트
 *   > 이동, 파괴, 피격시 점수 추가
 */

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private int _attackLevel = -1;

    ScoreManager scoreManager;
    ESCMenu escMenu;

    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        escMenu = FindObjectOfType<ESCMenu>();
        scoreManager.IncreaseScoreByJudgement(_attackLevel);
        // 공격은 판정 결과에 따라 생성되므로 이는 노트 판정의 결과와 동일
    }

    private void Update()
    {
        if (!escMenu.isPop)
        {
            transform.position += _speed * Time.deltaTime * new Vector3(0, 1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "AttackBorder")  // 경계에 닿으면 오브젝트 파괴
        {
            Destroy(gameObject);
        }
    }

    public int GetAttackLevel()
    {
        return _attackLevel;
    }
}
