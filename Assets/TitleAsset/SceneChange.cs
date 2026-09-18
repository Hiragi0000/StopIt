using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;  //シーンの切り換えに必要
public class SceneChange : MonoBehaviour
{
    public string sceneName;    //読み込むシーン名
    public TitleUI change;
    //効果音
    public AudioSource seSource;
    public AudioClip selectSE;

    void Update()
    {
        change.time--;
        Debug.Log(change.time);
        if (Input.GetKeyDown(KeyCode.Space)&&change.time<=0)
        {
            seSource.PlayOneShot(selectSE);
            SceneManager.LoadScene(sceneName);
        }
    }
    //public void Load()
    //public void Load()
    //{
    //    SceneManager.LoadScene(sceneName);
    //}
}
