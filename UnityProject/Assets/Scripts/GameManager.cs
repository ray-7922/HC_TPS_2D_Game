using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("目前分數")]
    public int score;
    [Header("最高分數")]
    public int scoreHeight;
    [Header("水管")]
    // GameObject 可以存放場景上的遊戲物件與專案內的預製物
    public GameObject pipe;

    public GameObject goFinal;

    public static bool gameover;

    public Text textScore;

    public Text basetext;
  string best = "best"; 

    
  

    



   

    public void AddScore()
    {
        
        
        print("加分");
        score++;

        int i = PlayerPrefs.GetInt("best");
        Debug.Log(i);
        //分數介面文字更新成分數轉字串
        textScore.text = score.ToString();
        if (score>=i)
        {
            PlayerPrefs.SetInt("best", score);
        }
        
    }

    

    // 修飾詞權限：
    // private 其他類別無法使用
    // public 其他類別可以使用

    /// <summary>
    /// 加分。
    /// </summary>
    
    
    /// <summary>
    /// 最高分數判定。
    /// </summary>
    private void HeightScore()
    {
        basetext.text= PlayerPrefs.GetInt("best").ToString();
    }

    /// <summary>
    /// 生成水管。
    /// </summary>
    private void SpawnPipe()
    {
        print("生水管~");
        // 生成(物件);
        //Instantiate(pipe);

        // 生成(物件，坐標，角度)
        float y = Random.Range(-1f, 1.2f);
        // 區域欄位(不需要修飾詞)
        Vector3 pos = new Vector3(10, y, 0);

        // Quaternion.identity 代表零角度
        Instantiate(pipe, pos, Quaternion.identity);
    }

    /// <summary>
    /// 遊戲失敗。
    /// </summary>
    public void GameOver()
    {
        HeightScore();
        goFinal.SetActive(true);//顯示結算畫面
        gameover = true; //遊戲結束 = 是
        CancelInvoke("SpawnPipe"); //停止InvokeRepeating的方法
    }

    public void GameOverEXIT() { }

    public void Replay() 
    {
        SceneManager.LoadScene("遊戲場景"); //場景管理器.載入場景("場景名稱"); 舊版API
        //Application.LoadLevel("遊戲場景");//應用程式.載入場景("場景名稱"); 新版API
    }



    private void Start()
    {
        //PlayerPrefs.DeleteKey(best);
        Screen.SetResolution(720, 1280, false);
        //因靜態成員載入場景不會還原,在Start作開關
        gameover = false;
        // 重複調用("方法名稱"，開始時間，間隔時間)
        InvokeRepeating("SpawnPipe", 0, 1.5f);
        PlayerPrefs.GetInt("best").ToString();
    }
}
