using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraController : MonoBehaviour
{
    private float x_max;
    private float y_max;
    private float x_min;
    private float y_min;

    private Vector3 mRightDirection; // The inital "right" of the camera
    private Vector3 mUpDirection; // The inital "up" of the came
    float mSpeed = 3.0f; // Scale. Speed of the movement

    private bool can_camera_move = true;

    public bool MoveCamera { get => can_camera_move; set=> can_camera_move = value; }

    private static CameraController instance;
    public static CameraController Instance
	{
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<CameraController>();
            }
            return instance;
        }
    }

    void Start()
    {
        MapController.Instance.OnMapOpen += map_OnMapOpen;
    }

    public void changeCameraLimits(GameObject map)
    {
        Dictionary<string, float> camera_limits = new Dictionary<string, float>();
        camera_limits = corners(GetComponent<Camera>(), map.GetComponent<SpriteRenderer>(), map.GetComponent<Transform>());
                
        y_max = camera_limits["top"];
        y_min = camera_limits["bottom"];
        x_max = camera_limits["right"];
        x_min = camera_limits["left"];

        mRightDirection = transform.right;
        mUpDirection = transform.up;
    }

    void LateUpdate()
    {
        if(!can_camera_move) return;
        var mDelta = 80;
        // Check if on the right edge
        if ( Input.mousePosition.x >= Screen.width - mDelta )
        {
            transform.position += mRightDirection * Time.deltaTime * mSpeed;
        }
        
        // Check if on the left edge
        if ( Input.mousePosition.x <= 0 + mDelta )
        {
            // Move the camera
            transform.position -= mRightDirection * Time.deltaTime * mSpeed;
        }
        
        // Check if on the top edge
        if ( Input.mousePosition.y >= Screen.height - mDelta )
        {
            // Move the camera
            transform.position += mUpDirection * Time.deltaTime * mSpeed;
        }
        
        // Check if on the bottom edge
        if ( Input.mousePosition.y <= 0 + mDelta )
        {
            // Move the camera
            transform.position -= mUpDirection * Time.deltaTime * mSpeed;
        }
        
        clampCamera(transform.position);
    }

    public void handleMovement(float horizontal, float vertical)
    {
        float x = (transform.position.x + horizontal) ;
        float y = (transform.position.y + vertical);
        clampCamera(x, y);
    }

    private void clampCamera(float x, float y)
    {
        hideArrow(x, y);
        transform.position = new Vector3(Mathf.Clamp(x, x_min, x_max),  Mathf.Clamp(y, y_min, y_max), -10);
    }

    private void clampCamera(Vector3 vector) => clampCamera(vector.x, vector.y);

    private void hideArrow(float x, float y)
    {
        ArrowsController.Instance.hideArrow();

        if(x >= x_max) ArrowsController.Instance.hideArrow(ArrowsController.arrows.RIGHT);
        if(x <= x_min ) ArrowsController.Instance.hideArrow(ArrowsController.arrows.LEFT);

        if(y >= y_max)  ArrowsController.Instance.hideArrow(ArrowsController.arrows.TOP);
        if(y <= y_min ) ArrowsController.Instance.hideArrow(ArrowsController.arrows.BOTTOM);   
    }

    private Dictionary<string, float> corners(Camera cam, SpriteRenderer spriteBounds, Transform scale)
    {
        float vertExtent = cam.orthographicSize;  
        float horzExtent = vertExtent * Screen.width / Screen.height;
        
        float leftBound = (float)(horzExtent - (spriteBounds.sprite.bounds.size.x * scale.localScale.x) / 2.0f);
        float rightBound = (float)((spriteBounds.sprite.bounds.size.x * scale.localScale.x)/ 2.0f - horzExtent);
        float bottomBound = (float)(vertExtent - (spriteBounds.sprite.bounds.size.y * scale.localScale.y) / 2.0f);
        float topBound = (float)((spriteBounds.sprite.bounds.size.y * scale.localScale.y) / 2.0f - vertExtent);

        Dictionary<string, float> limits = new Dictionary<string, float>();
        limits.Add("top", topBound);
        limits.Add("left", leftBound);
        limits.Add("right", rightBound);
        limits.Add("bottom", bottomBound);

        return limits;
    }

    private void map_OnMapOpen(object sender, EventArgs e)
	{
		can_camera_move = !can_camera_move;
	}
}
