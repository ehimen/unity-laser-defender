using UnityEngine;
using UnityEngine.UI;

abstract public class GameButton : MonoBehaviour {

    public PlayerController player;
	
	void Update ()
    {
        Vector3 mouse = Input.mousePosition;

        RectTransform rect = gameObject.GetComponent<RectTransform>();
        
        if (rect && Input.GetMouseButton(0) && RectTransformUtility.RectangleContainsScreenPoint(rect, new Vector2(mouse.x, mouse.y))) {
            DoMouseDown();
        }
	}

    abstract protected void DoMouseDown();

}
