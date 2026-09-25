using UnityEngine;

public class TitleUI : MonoBehaviour
{
    public GameObject TitleImage;
    public GameObject LogoImage;
    public GameObject Button;
    public GameObject StarImage;
    public bool isChange = false;
    public int time = 0;
    //効果音
    public AudioSource seSource;
    public AudioClip selectSE;

    void Start()
    {
        StarImage.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&!isChange)
        {
            TitleImage.SetActive(false); // タイトルを消す
            LogoImage.SetActive(false);
            Button.SetActive(false);
            StarImage.SetActive(true);
            seSource.PlayOneShot(selectSE);
            isChange = true;
            time = 600;
        }
    }
}
