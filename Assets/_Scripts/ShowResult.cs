using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowResult : MonoBehaviour
{
    public GameObject ConditionText;
    public GameObject ResultText;
    public Color winColor;
    public Color loseColor;

    private int gotArtifacts;
    private int finalTime;
    private int scoreCalc;
    private string result;

    private int score;
    // Start is called before the first frame update
    void Start()
    {
        gotArtifacts = GameControl.control.artifactsGathered;
        finalTime = (int)GameControl.control.resultTime;
        scoreCalc = GameControl.control.scoreMultiplier;
        result = GameControl.control.condition;
    }

    // Update is called once per frame
    void Update()
    {
        if (result == "WIN")
        {
            //Change Text to Win Colors
            ConditionText.transform.GetChild(1).GetComponent<Text>().color = winColor;
            ResultText.transform.GetChild(1).GetComponent<Text>().color = winColor;

            //Change Message to WinMessage
            ConditionText.transform.GetChild(0).GetComponent<Text>().text = "CONGRATS, YOU ESCAPED !";
            ConditionText.transform.GetChild(1).GetComponent<Text>().text = "CONGRATS, YOU ESCAPED !";
        }
        else if (result == "LOSE")
        {
            //Change Text to Lose Colors
            ConditionText.transform.GetChild(1).GetComponent<Text>().color = loseColor;
            ResultText.transform.GetChild(1).GetComponent<Text>().color = loseColor;

            //Change Message to LoseMessage
            ConditionText.transform.GetChild(0).GetComponent<Text>().text = "YOU FAILED TO ESCAPE !";
            ConditionText.transform.GetChild(1).GetComponent<Text>().text = "YOU FAILED TO ESCAPE !";
        }

        //CalculatePoints
        score = finalTime * scoreCalc + (gotArtifacts * 200);
        ResultText.transform.GetChild(0).GetComponent<Text>().text = "YOUR TIME WAS " + finalTime + "S" +
                                                                     "\nYOU COLLECTED " + gotArtifacts + " ARTIFACTS"
                                                                     + "\n\nWHICH MEANS YOUR SCORE IS ... " + score + " POINTS!";
        ResultText.transform.GetChild(1).GetComponent<Text>().text = "YOUR TIME WAS " + finalTime + "S" +
                                                                     "\nYOU COLLECTED " + gotArtifacts + " ARTIFACTS"
                                                                     + "\n\nWHICH MEANS YOUR SCORE IS ... " + score + " POINTS!";
    }
}
