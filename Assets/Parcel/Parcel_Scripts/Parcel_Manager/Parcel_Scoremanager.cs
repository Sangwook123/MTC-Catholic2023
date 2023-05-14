using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parcel_Scoremanager : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Text txtScore = null;
    [SerializeField] int increaseScore = 10;
    public int currentScore = 0;

    [SerializeField] float[] weight = null;
    [SerializeField] int comboBonusScore = 10;

    Animator myAnim;
    string animScoreUp = "ScoreUp";

    Parcel_ComboManager theCombo;

    void Start()
    {
        theCombo = FindObjectOfType<Parcel_ComboManager>();
        myAnim = GetComponent<Animator>();
        currentScore = 0; // 시작했을시 점수 0으로 설정
        txtScore.text = "0";
    }

    public void Initialized()
    {
        //점수 초기화
        currentScore = 0;
        txtScore.text = "0";
    }

    public void IncreaseScore(int p_JudgementState)
    {
        //콤보 증가
        theCombo.IncreaseCombo();

        //콤보 보너스 점수 계산
        int t_currentCombo = theCombo.GetCurrentCombo();
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
    
    public int GetCurrentScore() //현재 점수 반환
    {
        return currentScore;
    }
}
