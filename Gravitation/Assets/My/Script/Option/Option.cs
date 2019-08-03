using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Option : MonoBehaviour
{
    VideoPlayer VidPlay;
    public VideoClip[] VidClip;
    public Text Txt;
    int Count;

    // Start is called before the first frame update
    void Start()
    {
        VidPlay = GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        //要素数、参照による制限
        if (Count > VidClip.Length - 1) Count = 0;
        if (Count < 0) Count = VidClip.Length - 1;


        switch (Count)
        {
            case 0: VidPlay.clip = VidClip[0]; break;
            case 1: VidPlay.clip = VidClip[1]; break;
            case 2: VidPlay.clip = VidClip[2]; break;
            case 3: VidPlay.clip = VidClip[3]; break;
            case 4: VidPlay.clip = VidClip[4]; break;
            case 5: VidPlay.clip = VidClip[5]; break;
            case 6: VidPlay.clip = VidClip[6]; break;
            case 7: VidPlay.clip = VidClip[7]; break;
            case 8: VidPlay.clip = VidClip[8]; break;
            case 9: VidPlay.clip = VidClip[9]; break;
            case 10: VidPlay.clip = VidClip[10]; break;
            default: break;
        }

        switch (Count)
        {
            case 0: Txt.text = "キャラクター移動　A：左へ　D：右へ"; ; break;
            case 1: Txt.text="星の操作　マウス左クリックで、クリックした場所まで動く"; break;
            case 2: Txt.text = "黄色いエリアに入った場合、中心に吸い寄せられる";break;
            case 3: Txt.text = "動いている物に対しては、軌道を変えることができる"; break;
            case 4: Txt.text = "Qキーで星を奥へもっていくことができる"; break;
            case 5: Txt.text = "下へ引いて離すと、大ジャンプができるブロック"; break;
            case 6: Txt.text = "敵　引き寄せて星に当てるとダメージを与えることができ、倒した場合ポイントがもらえる"; break;
            case 7: Txt.text = "敵　多くエリア内に入れると素早く倒すことができる"; break;
            case 8: Txt.text = "弾の軌道を変えてブロックに弾を当てると壊すことができる"; break;
            case 9: Txt.text = "マウス右クリックで、プレイヤー自身も引き寄せることができる"; break;
            case 10: Txt.text = "アイテムは星で引き寄せることができる"; break;
            default: break;
        }
    }
    public void OnLeftClick()
    {
        Count++;
    }
    public void OnRightClick()
    {
        Count--;
    }
    public void OnButton()
    {
        SceneManager.LoadScene("Select");
    }
}
