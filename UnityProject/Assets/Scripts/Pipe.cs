// 繼承：可以享有繼承類別的成員
public class Pipe : Ground
{
    private void Start()
    {
        // gmaeObject 指的是此類別的遊戲物件
        // 刪除(物件，延遲時間)
        
    }
    private void OnBecameInvisible()//攝影機畫面外執行一次
    {
        Destroy(gameObject, 1f);
    }
    //private void OnBecameVisible() 攝影機畫面內執行一次
    //{
        
    //}
}
