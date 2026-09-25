using UnityEngine;

public class PetSelect : MonoBehaviour
{
    public GameObject[] pets;          // 犬・猫の画像
    public GameObject DogImage;        //切り替わる画像 犬
    public GameObject CatImage;        //切り替わる画像 猫
    public GameObject StarImage;       //切り替わる画像 星
    //public GameObject[] highlights;    // 黄色ハイライト
    //public AudioSource se;             // SE再生
    int index = 0;                     // 0=犬, 1=猫
    //効果音
    public AudioSource seSource;
    public AudioClip selectSE;

    void Start()
    {
        //最初に犬にハイライト
        //UpdateHighlight();
        CatImage.SetActive(false);  //最初は猫を非表示
        StarImage.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)&&index==0)
        {
            index = 1;
            //se.Play();
            //UpdateHighlight();
            DogImage.SetActive(false);
            CatImage.SetActive(true);
            StarImage.SetActive(true);
            seSource.PlayOneShot(selectSE);
            DataKeep.keep.player = 1;
        }
        else if (Input.GetKeyDown(KeyCode.A) && index == 1)
        {
            index = 0;
            //se.Play();
            //UpdateHighlight();
            DogImage.SetActive(true);
            CatImage.SetActive(false);
            StarImage.SetActive(false);
            seSource.PlayOneShot(selectSE);
            DataKeep.keep.player = 0;
        }
        if (Input.GetKeyDown(KeyCode.D)&&index==0)
        {
            index = 1;
            //se.Play();
            //UpdateHighlight();
            DogImage.SetActive(false);
            CatImage.SetActive(true);
            StarImage.SetActive(true);
            seSource.PlayOneShot(selectSE);
            DataKeep.keep.player = 1;
        }
        else if (Input.GetKeyDown(KeyCode.D) && index == 1)
        {
            index = 0;
            //se.Play();
            //UpdateHighlight();
            DogImage.SetActive(true);
            CatImage.SetActive(false);
            StarImage.SetActive(false);
            seSource.PlayOneShot(selectSE);
            DataKeep.keep.player = 0;
        }
    }

    //void UpdateHighlight()
    //{
    //    for (int i = 0; i < highlights.Length; i++)
    //    {
    //        highlights[i].SetActive(i == index);
    //    }
    //}

    public int GetSelectedPetIndex()
    {
        return index;
    }
}
