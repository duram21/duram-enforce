using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    Rigidbody2D rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }


    public void Init(float damage,  Vector3 dir)
    {
        this.damage = damage;
        rigid.linearVelocity = dir * 20f;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy"))
            return;

        rigid.linearVelocity = Vector2.zero;
        gameObject.SetActive(false);


    }
}
