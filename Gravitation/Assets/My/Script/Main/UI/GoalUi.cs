using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoalUi : MonoBehaviour
{
    public Text PointText;
    public Text ResetText;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        PointText.text = "Point:" + Score.ScorePoint;
        ResetText.text = "Reset:" + Score.WarpCount;
    }
    public void OnClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Select");
    }
}
