using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float speed = 50.0f;

    Vector3 hit_position = Vector3.zero;
    Vector3 current_position = Vector3.zero;
    Vector3 camera_position = Vector3.zero;
    float z = 0.0f;

    bool flag = false;
    Vector3 target_position;

    public BoxCollider2D boundsBox;
    private Vector3 minBounds;
    private Vector3 maxBounds;

    private Camera theCamera;
    private float halfHeight;
    private float halfWidth;

    /*
private void Start()
{
    boundsBox = GameObject.Find("BoundsBox").GetComponent<BoxCollider2D>();

    minBounds = boundsBox.bounds.min;
    maxBounds = boundsBox.bounds.max;

    theCamera = GetComponent<Camera>();
    halfHeight = theCamera.orthographicSize;
    halfWidth = halfHeight * Screen.width / Screen.height;
}

void Update()
{

    if (Input.GetMouseButtonDown(0) )
    {
        hit_position = Input.mousePosition;
        camera_position = transform.position;
    }

    if (Input.GetMouseButton(0) )
    {
        current_position = Input.mousePosition;
        LeftMouseDrag();
        flag = true;
    }

    if (flag)
    {
        transform.position = Vector3.MoveTowards(transform.position, target_position, Time.deltaTime * speed);
        float clampedX = Mathf.Clamp(transform.position.x, minBounds.x + halfWidth, maxBounds.x - halfWidth);
        //float clampedY = Mathf.Clamp(transform.position.y, minBounds.y + halfHeight, maxBounds.y - halfHeight);
        transform.position = new Vector3(clampedX, 0, transform.position.z);

        if (transform.position == target_position)//reached?
        {
            flag = false;// stop moving
        }
    }

}

void LeftMouseDrag()
{
    // From the Unity3D docs: "The z position is in world units from the camera."  In my case I'm using the y-axis as height
    // with my camera facing back down the y-axis.  You can ignore this when the camera is orthograhic.
    current_position.z = hit_position.z = camera_position.y;

    // Get direction of movement.  (Note: Don't normalize, the magnitude of change is going to be Vector3.Distance(current_position-hit_position)
    // anyways.  
    Vector3 direction = Camera.main.ScreenToWorldPoint(current_position) - Camera.main.ScreenToWorldPoint(hit_position);

    // Invert direction to that terrain appears to move with the mouse.
    direction = direction * -1;

    target_position = camera_position + direction;
}*/
}
