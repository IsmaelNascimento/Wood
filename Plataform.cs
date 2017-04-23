using UnityEngine;
using System.Collections;

public class Plataform : MonoBehaviour
{
    public float    fSpeedMoviment;
    private float   fLimitAxisX;

	// Use this for initialization
	void Start ()
    {
        fLimitAxisX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x - GetComponent<SpriteRenderer>().bounds.extents.x;
	}
	
	// Update is called once per frame
	void Update ()
    {
        MovimentPlataform();
	}

    private void MovimentPlataform()
    {
        float fDirectionMouseHorizontal = Input.GetAxis("Mouse X");
        GetComponent<Transform>().position += Vector3.right * fDirectionMouseHorizontal * fSpeedMoviment * Time.deltaTime;
        float fAxisXCurrent = transform.position.x;
        fAxisXCurrent = Mathf.Clamp(fAxisXCurrent, -fLimitAxisX, fLimitAxisX);
        transform.position = new Vector3(fAxisXCurrent, transform.position.y, transform.position.z);
    }
}
