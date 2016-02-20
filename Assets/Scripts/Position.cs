using UnityEngine;

public class Position : MonoBehaviour {

    void OnDrawGizmos()
    {
        // This draws a sphere marking where we are, helpful when in the Unity editor.
        // Does nothing in the actual game.
        Gizmos.DrawWireSphere(transform.position, 1);
    }

}
