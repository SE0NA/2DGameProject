using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

/*
 *  스테이지 인덱스에 따라 적, 적의 공격 프리펩을 관리하는 GameManager
 */

public class GameManager : MonoBehaviour
{
    // 플레이 정보
    public int perfectCnt = 0;
    public int goodCnt = 0;
    public int badCnt = 0;
    public int hitCnt = 0;  // 피격
    public bool isStart = false;
    
    // 적 오브젝트 프리펩
    [SerializeField] List<GameObject> enemyList = null;
    GameObject enemyObject;
    Enemy enemyInfo;
    public Transform enemyAppear;

    // 적 공격 오브젝트 프리펩
    List<GameObject> enemyAttackList = null;
    public Transform[] spawnPoints; // 스폰
    public float nextSpawnDelay;
    public float curSpawnDelay;
    public List<Spawn> spawnList = null;    // 공격 리스트(커스텀)
    public int spawnIndex;
    public bool spawnEnd;
    public Transform spawn0 = null;

    ESCMenu escMenu;
    StageList stageList;
    private int stageID;

    // UI 관리
    [SerializeField] Text _stageTitle = null;

    // Background Image : tutorial만 다르게
    [SerializeField] GameObject _tutorialBackground = null;
    [SerializeField] GameObject _normalBackground = null;

    void Start()
    {
        stageList = FindObjectOfType<StageList>();
        stageID = stageList.currentStageID;     // 현재 스테이지 인덱스
        // 스테이지에 따른 적 오브젝트 생성
        enemyObject = Instantiate(enemyList[stageID], enemyAppear.position, Quaternion.identity);
        enemyInfo = FindObjectOfType<Enemy>();
        escMenu = FindObjectOfType<ESCMenu>();
        enemyAttackList = enemyInfo.enemyAttack;
        spawnList = new List<Spawn>();
        ReadSpawnFile();

        _stageTitle.text = stageList.stageList[stageID].stagetxt;   // 좌측상단 스테이지명 텍스트 수정
        if (stageID == 0) _normalBackground.SetActive(false);   // 튜토리얼 배경 사용
        else              _tutorialBackground.SetActive(false); // 일반 배경 사용
    }

    private void Update()
    {
        if (!escMenu.isPop)
        {
            spawn0.position = enemyInfo.transform.position;
            curSpawnDelay += Time.deltaTime;
            if (isStart && !spawnEnd && curSpawnDelay > nextSpawnDelay)
            {
                SpawnEnemy();
                curSpawnDelay = 0;
            }
        }
    }

    void SpawnEnemy()   // 적 공격 생성
    {
        int type = spawnList[spawnIndex].type;
        int point = spawnList[spawnIndex].point;
        Instantiate(enemyAttackList[type], spawnPoints[point].position, spawnPoints[point].rotation);
        spawnIndex++;
        if(spawnIndex == spawnList.Count)
        {
            spawnEnd = true;
            return;
        }
        nextSpawnDelay = spawnList[spawnIndex].delay;
    }
    void ReadSpawnFile()    // 커스텀 파일 읽기
    {
        spawnList.Clear();
        spawnIndex = 0;
        spawnEnd = false;

        TextAsset fileData = Resources.Load("Stage" + stageID) as TextAsset;
        StringReader stringReader = new StringReader(fileData.text);
        while (stringReader != null)
        {
            string line = stringReader.ReadLine();
            if (line == null) break;

            Spawn spawnData = new Spawn();
            spawnData.delay = float.Parse(line.Split('/')[0]);
            spawnData.type = int.Parse(line.Split('/')[1]);
            spawnData.point = int.Parse(line.Split('/')[2]);
            spawnList.Add(spawnData);
        }
        stringReader.Close();
        nextSpawnDelay = spawnList[0].delay;
    }
   
}
