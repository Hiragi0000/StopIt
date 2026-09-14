using UnityEngine;

public class TitleUI : MonoBehaviour
{
    public GameObject TitleImage;
    public GameObject LogoImage;
    public GameObject Button;
    public GameObject StarImage;
    public bool isChange = false;

    void Start()
    {
        StarImage.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TitleImage.SetActive(false); // タイトルを消す
            LogoImage.SetActive(false);
            Button.SetActive(false);
            StarImage.SetActive(true);
            isChange = true;
        }
    }
}
