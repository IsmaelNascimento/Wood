using UnityEngine;
using System.Collections;

public class GenaratorEdges : MonoBehaviour
{
	// Use this for initialization
	void Update ()
    {
        Camera          cam = Camera.main;
        EdgeCollider2D  collider = GetComponent<EdgeCollider2D>();
        Vector2         lowerLeftCorner = cam.ScreenToWorldPoint(new Vector3(0, 0, 0));
        Vector2         upperLeftCorner = cam.ScreenToWorldPoint(new Vector3(0, Screen.height, 0));
        Vector2         upperRightCorner = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        Vector2         lowerRightCorner = cam.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0));
        collider.points = new Vector2[5] {lowerLeftCorner,  upperLeftCorner, upperRightCorner, lowerRightCorner, lowerLeftCorner};
    }
	
}
