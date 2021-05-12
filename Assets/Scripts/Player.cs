using UnityEngine;

public class Player : MonoBehaviour
{
    public float movingVelocity;
    public float extraSpeed;
    public Rigidbody2D rd;
    private void Awake()
    {
        rd = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (Input.GetKeyDown("space"))
            Physics2D.gravity *= -1f;
    }
    void FixedUpdate()
    {
        if (this != null)
        {
            rd.velocity = new Vector2(movingVelocity + extraSpeed, rd.velocity.y);
            //rd.AddForce(new Vector2(movingVelocity + extraSpeed, rd.velocity.y),ForceMode2D.Impulse); Не подходит из за ускарения
           // transform.Translate(new Vector2(extraSpeed, rd.velocity.y)); В общем то подходит но нужны слишком маленькие значения
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
            Destroy(this.gameObject);
    }
}
