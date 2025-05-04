using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int id;
    public int prefabId;
    public float damage;
    public float speed;
    public int level;
    public Item.WeaponTier weaponTier;
    public SpriteRenderer spriter;
    public bool isEquipped;



    float timer;

    void Awake()
    {
        spriter = GetComponent<SpriteRenderer>();
    }

    public void Init(Item data)
    {
        gameObject.SetActive(true);
        this.id = data.id;
        this.prefabId = data.id;
        this.level = data.level;
        this.damage = data.damage[level];
        this.speed = data.speed;
        spriter.sprite = data.sprite;
        this.weaponTier = data.weaponTier;
    }

    public void Unequip()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameManager.Inst.isFight){
            timer = 0;
            return;
        }
        switch (id)
        {
            case 0:
                transform.Rotate(Vector3.back * speed * Time.deltaTime);
                break;

            default:
                timer += Time.deltaTime;

                if (timer > speed)
                {
                    timer = 0f;
                    Fire();
                }
                break;
        }
    }

    void Fire()
    {

        Vector3 targetPos = Vector3.zero;
        Vector3 dir = targetPos - transform.position;
        dir = dir.normalized;

        Transform bullet = GameManager.Inst.pool.Get(prefabId).transform;
        bullet.position = transform.position;
        bullet.rotation = Quaternion.FromToRotation(Vector3.up, dir);
        bullet.GetComponent<Bullet>().Init(damage, dir);
    }
}
