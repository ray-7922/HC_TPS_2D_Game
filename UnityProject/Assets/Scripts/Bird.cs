using UnityEngine;

public class Bird : MonoBehaviour
{
    [Header("跳躍高度"), Range(10, 2000)]
    public int jump = 100;
    [Header("是否死亡"), Tooltip("用來判斷角色是否死亡，true 死亡，false 還沒死亡")]
    public bool dead;

    public float angle = 10;

    public Rigidbody2D r2d;

    public GameObject GM, NUM;

    public GameManager Gm_Script;

    public AudioSource aud;

    public AudioClip Die, SE_Jump, Bouns;

    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        


    }

    /// <summary>
    /// 小雞跳躍方法。
    /// </summary>
    private void Jump()
    {
        if (dead ==true) 
        {
            return;     //程式跳出這個{}外因此跳過JUMP
        }

        //if (dead) return;   簡寫{}內只有一行敘述 {}可將其省略


        //如果玩家按下左鍵
        //輸入按下按鍵.手機觸控

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //print("0000");
            aud.PlayOneShot(SE_Jump, 1.5f);
            r2d.Sleep();                       //小雞剛體重新設定
            r2d.gravityScale = 1;              //小雞剛體,重力 = 1;
            r2d.AddForce(new Vector2(0, jump));//小雞剛體.增加推力(二維向量(左右，上下));
            //分數 顯示
            //GM 顯示
            GM.SetActive(true);
            NUM.SetActive(true);

        }
        r2d.SetRotation(angle * r2d.velocity.y);
        //Rigidbody2D.SetRotation(float)設定角度(角度)
        //Rigidbody2D.velocity 加速度(二維向量x,y)
        
        //小雞 往上跳
    }

    /// <summary>
    /// 小雞死亡方法。
    /// </summary>
    private void Dead()
    {
        dead = true;
        //Time.timeScale = 0;
        Gm_Script.GameOver(); //static用 如果遊戲結束就跳出地板移動Funtion
        aud.PlayOneShot(Die, 1.5f);
    }

    private void FixedUpdate()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D hit)
    {
       //Print遊戲物件和名稱:hit是將名稱暫存進hit內
        print(hit.gameObject.name);

        if (hit.gameObject.name == "地板") 
        {
            Dead();
        }
    }
    private void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.gameObject.tag == "die")
        {
            Dead();
        }
    }     //如果碰到.物件名稱為上或下則死亡 TriggerEnter可省略GameObject

    private void OnTriggerExit2D(Collider2D hit) //物件離開觸發區時會執行一次
    {
        if (hit.gameObject.tag == "Add"&&!dead) 
        {
            Gm_Script.AddScore();
            aud.PlayOneShot(Bouns, 1.5f);
        }
    }


    private void Update()
    {
        gameObject.transform.position = new Vector2(0, Mathf.Clamp(gameObject.transform.position.y, -3.53f, 4.62f));
        Jump();
    }
    
}
