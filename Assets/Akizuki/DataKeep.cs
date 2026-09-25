using UnityEngine;

public class DataKeep : MonoBehaviour
{
    public static DataKeep keep;

    public int score = 0;
    public int player = 0;

    void Awake()
    {
        if (keep == null)
        {
            keep = this;
            // DontDestroyOnLoad シーンを移動しても消えない
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            // 1つのみにする
            Destroy(gameObject);  
        }
    }


    //確認
    //void Update()
    //{
    //    Debug.Log(DataKeep.keep.player);
    //}

}


//↓こんな感じでスコアを増やす
//DataKeep.keep.score += 10;