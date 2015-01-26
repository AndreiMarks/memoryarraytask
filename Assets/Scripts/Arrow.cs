using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour 
{
    public Vector3 leftRotation;
    public Vector3 rightRotation;

	void Update () 
    {
        if ( Input.GetKey( KeyCode.LeftArrow ) )
        {
            ShowLeftArrow();
        } else if ( Input.GetKey( KeyCode.RightArrow ) ) {
            ShowRightArrow();
        }
	}

    public void ShowLeftArrow()
    {
        transform.eulerAngles = leftRotation;
    }

    public void ShowRightArrow()
    {
        transform.eulerAngles = rightRotation;
    }
}
