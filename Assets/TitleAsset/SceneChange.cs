using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;  //シーンの切り換えに必要
public class SceneChange : MonoBehaviour
{
    public string sceneName;    //読み込むシーン名
    public TitleUI change;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&change.isChange)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
    //public void Load()
    //{
    //    SceneManager.LoadScene(sceneName);
    //}
}
