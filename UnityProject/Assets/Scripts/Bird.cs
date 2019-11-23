using UnityEngine;

public class Bird : MonoBehaviour
{
    [Header("跳躍高度"), Range(10, 2000)]
    public int jump = 100;
    [Header("是否死亡"), Tooltip("用來判斷角色是否死亡，true 死亡，false 還沒死亡")]
    public bool dead;

    public Rigidbody2D r2d;

    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();  
    }

    /// <summary>
    /// 小雞跳躍方法。
    /// </summary>
    private void Jump()
    {
        //如果玩家按下左鍵
        //輸入按下按鍵.手機觸控

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //print("0000");
            r2d.Sleep();                       //小雞剛體重新設定
            r2d.gravityScale = 1;              //小雞剛體,重力 = 1;
            r2d.AddForce(new Vector2(0, jump));//小雞剛體.增加推力(二維向量(左右，上下));
            
            
        }
        //小雞 往上跳
    }

    /// <summary>
    /// 小雞死亡方法。
    /// </summary>
    private void Dead()
    {

    }

    private void Update()
    {
        Jump();
    }
}
