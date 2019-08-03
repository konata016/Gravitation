using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PosChange : MonoBehaviour
{
    GameObject[] Targets;
    Vector3 Velocity;
    Vector3 Pos;
    int Count;

    [Header("移動位置リスト")]
    public List<GameObject> TargetPos = new List<GameObject>();

    [Header("見つける位置")]
    public GameObject LookTarget;

    [Header("向かうまでの時間")]
    public float SmoothTime = 0.1f;

    [Header("UI")]
    public GameObject StartUi;
    public GameObject EndUi;
    public GameObject OptionUi;

    // Start is called before the first frame update
    void Start()
    {
        //星の数分だけ確保する
        Targets = GameObject.FindGameObjectsWithTag("Planet");
        foreach(GameObject Target in Targets)
        {
            TargetPos.Add(Target);
        }
      
        StartUi.SetActive(false);
        EndUi.SetActive(false);
        OptionUi.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //要素数、参照による制限
        if (Count > TargetPos.Count - 1) Count = 0;
        if (Count < 0) Count = TargetPos.Count - 1;

        //核の方を見る
        transform.LookAt(LookTarget.transform);

        //星のポジション確保
        Pos = TargetPos[Count].transform.position;

        //移動
        transform.position =
            Vector3.SmoothDamp(transform.position, Pos, ref Velocity, SmoothTime);
    }

    void OnTriggerEnter(Collider other)
    {
        //各箇所に適したUIを表示する
        switch (Count)
        {
            case 0: StartUi.SetActive(true); break;
            case 1: OptionUi.SetActive(true); break;
            case 2: EndUi.SetActive(true); break;
            default: break;
        }
    }

    public void OnButton()
    {
        //ボタンを押した時、シー処理が入る
        switch (Count)
        {
            case 0: SceneManager.LoadScene("GameScene"); break;
            case 1: SceneManager.LoadScene("Option"); break;
            case 2: Application.Quit(); break;
            default: break;
        }
    }
    public void OnLeftClick()
    {
        StartUi.SetActive(false);
        EndUi.SetActive(false);
        OptionUi.SetActive(false);
        Count++;
    }
    public void OnRightClick()
    {
        StartUi.SetActive(false);
        EndUi.SetActive(false);
        OptionUi.SetActive(false);
        Count--;
    }
}
