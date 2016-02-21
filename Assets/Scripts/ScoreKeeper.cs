using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

    private static int score = 0;

    void Start()
    {
        Reset();
    }

    public void Score(int points)
    {
        score += points;
        Update();
    }

    public void Reset()
    {
        score = 0;
        Update();
    }

    public static int GetScore()
    {
        return score;
    }

    void Update()
    {
        gameObject.GetComponent<Text>().text = score.ToString();
    }

}
