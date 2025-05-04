using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public string enemyName;
    public Rigidbody2D target;
    public bool isLive;
    public Sprite enemySprite;


    Collider2D coll;
    Rigidbody2D rigid;
    SpriteRenderer spriter;
    public GameObject dropItemPrefab;

    void Awake()
    {
        coll = GetComponent<Collider2D>();
        spriter = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
    }

    public void Init(EnemyData enemyData)
    {
        this.health = enemyData.health;
        this.maxHealth = enemyData.health;
        this.isLive = true;
        this.enemyName = enemyData.name;
        spriter.sprite = enemyData.sprite;

    }

    void OnEnable()
    {
        isLive = false;
        coll.enabled = true;
        rigid.simulated = true;
        spriter.sortingOrder = 2;
        health = maxHealth;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Bullet") || !isLive)
            return;

        health -= collision.GetComponent<Bullet>().damage;

        if (health > 0)
        {

        }
        else if(health <= 0)
        {
            DropReward();
            Dead();
        }
    }

    public void Dead()
    {
        isLive = false;
        coll.enabled = false;
        rigid.simulated = false;
        spriter.sortingOrder = 1;
        gameObject.SetActive(false);
        GameManager.Inst.StageClear();

    }
    public void DropReward()
    {
        int count = Random.Range(3, 6);
        for(int i = 0 ;  i < count ; i++){
            // DropItem item = Instantiate(dropItemPrefab).GetComponent<DropItem>();
            DropItem item = GameManager.Inst.pool.Get(2).GetComponent<DropItem>();
            item.Init(transform.position);
        }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
