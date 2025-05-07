using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Inst;

    [Header("# Game Control")]
    //public bool isLive;
    public float stageTime;
    public float maxStageTime = 3 * 10f;
    public float maxPreStageTime = 1 * 10f ;
    public bool isFight;
    public int stageIndex;



    [Header("# GameObject")]
    public PoolManager pool;
    public EnemyDataSO enemyDataSO;
    public int Coin;
    public Enemy currentEnemey;

    [Header("# Item Data")]
    public WeaponArray weaponArray;
    public GameObject inventory;

    [Header("# Game Control")]
    public bool isDrag;

    [Header("# Passive Data")]
    public float passiveWeaponSpeed;
    public int passiveWeaponDamage;


    void Awake()
    {
        Inst = this;
    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartStage();
    }

    public void StartStage()
    {
        stageTime = 0;
        isFight = true;
        Spawn();
    }

    void Spawn()
    {
        GameObject enemy = pool.Get(0);
        enemy.transform.position = Vector3.zero;
        enemy.GetComponent<Enemy>().Init(enemyDataSO.enemyDatas[stageIndex]);
        currentEnemey = enemy.GetComponent<Enemy>();
    }
    

    // Update is called once per frame
    void Update()
    {
        stageTime += Time.deltaTime;
        
        // 싸우는 중인데 시간 초과면 GAME OVER

        // 준비 시간인데 시간 다되면 다음 스테이지로 
        if(!isFight)
        {
            if(stageTime >= maxPreStageTime)
            {
                StartStage();
            }
        }

    }

    public void StageClear()
    {
        isFight = false;
        stageTime = 0;
        stageIndex++;

    }
}
