using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {
    
	void Start () {
        Text text = GetComponent<Text>();
        text.text = ScoreKeeper.GetScore().ToString();
	}

}
