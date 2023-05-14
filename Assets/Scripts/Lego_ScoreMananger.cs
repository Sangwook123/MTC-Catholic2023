using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lego_ScoreMananger : MonoBehaviour
{

    [SerializeField] UnityEngine.UI.Text txtScore = null;

    [SerializeField] int increaseScore = 10;
    int currentScore = 0;

    [SerializeField] float[] weight = null;
    [SerializeField] int comboBonusScore = 10;


    Animator myAnim;
    string animScoreUp = "ScoreUp";

    Lego_ComboManager theComboManager;

    // Start is called before the first frame update
    void Start()
    {
        theComboManager = FindObjectOfType<Lego_ComboManager>();
        myAnim = GetComponent<Animator>();
        currentScore = 0;
        txtScore.text = "0";
    }

    public void Initialized()
    {
        currentScore = 0;
        txtScore.text = "0";
    }

    // Update is called once per frame
    public void IncreaseScore(int p_JudgementState)
    {
        //콤보 증가
        theComboManager.IncreaseCombo();

        //콤보 가중치 계산
        int t_currentCombo = theComboManager.GetCurrentCombo();
        int t_bonusComboScore = (t_currentCombo / 10) * comboBonusScore;

        //판정 가중치 계산
        int t_increaseScore = increaseScore + t_bonusComboScore;
        t_increaseScore = (int)(t_increaseScore * weight[p_JudgementState]);

        //점수 반영
        currentScore += t_increaseScore;
        txtScore.text = string.Format("{0:#,##0}", currentScore);

        //애니 실행
        myAnim.SetTrigger(animScoreUp);


    }

    public int GetCurrentScore()
    {
        return currentScore;
    }
}
