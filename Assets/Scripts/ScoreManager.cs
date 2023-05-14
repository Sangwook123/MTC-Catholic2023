using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    [SerializeField] UnityEngine.UI.Text txtScore = null;
    [SerializeField] float[] weight = null;
    [SerializeField] int comboBonusScore = 10;
    [SerializeField] int increaseScore = 10;
    int currentScore = 0;

    Animator myAnim;
    string animScoreUp = "ScoreUp";

    ComboManager theComboManager;

    // Start is called before the first frame update
    void Start()
    {
        theComboManager = FindObjectOfType<ComboManager>();
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
        theComboManager.IncreaseCombo();

        int t_currentCombo = theComboManager.GetCurrentCombo();
        int t_bonusComboScore = (t_currentCombo / 10) * comboBonusScore;

        int t_increaseScore = increaseScore + t_bonusComboScore;
        t_increaseScore = (int)(t_increaseScore * weight[p_JudgementState]);

        currentScore += t_increaseScore;
        txtScore.text = string.Format("{0:#,##0}", currentScore);

        myAnim.SetTrigger(animScoreUp);
    }

    public int GetCurrentScore()
    {
        return currentScore;
    }
}
