using UnityEngine;

abstract public class GameButton : MonoBehaviour {

    public PlayerController player;
	
	void Update ()
    {
        RectTransform rect = gameObject.GetComponent<RectTransform>();

        if (rect) {
            foreach (Touch touch in Input.touches) {
                if (RectTransformUtility.RectangleContainsScreenPoint(rect, touch.position)) {
                    DoMouseDown();
                    break;
                }
            }
        }
        
	}

    abstract protected void DoMouseDown();

}
