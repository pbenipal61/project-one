using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UtilityMethodsAndEnums.UtilityEnums;

/// <summary>
/// Input class.
/// Events can be recieved in only one GameManager class, within a scene, with RecievedInput(Swipe swipe){ //Logic } method.
/// </summary>
public class SwipeInputV2 : MonoBehaviour
{
    private Vector2 startPos, endPos;
    private bool isDragging = false;
    [SerializeField]
    private float deadZone = 180f;
    private GameManager gameManager;

    [Header("Logic")]
    private bool swipeLeft, swipeRight, swipeUp, swipeDown;

    #region Public Properties
    public bool LeftSwipe { get { return swipeLeft; } }
    public bool RightSwipe { get { return swipeRight; } }
    public bool UpSwipe { get { return swipeUp; } }
    public bool DownSwipe { get { return swipeDown; } }
    public bool IsDragging { get { return isDragging; } }
    #endregion
    #region Instance
    private static SwipeInputV2 instance;
    public static SwipeInputV2 Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SwipeInputV2>();
                if (instance == null)
                {
                    instance = new GameObject("SwipeInput", typeof(SwipeInputV2)).GetComponent<SwipeInputV2>();
                }
            }
            return instance;
        }

        set
        {
            instance = value;
        }
    }

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        if(gameManager == null)
        {
            Debug.Log("No game manager present");
        }
    }
    #endregion
    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
            isDragging = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            swipeLeft = swipeRight = swipeUp = swipeDown = false;
            endPos = Input.mousePosition;
            isDragging = false;
            CalculateSwipe();

        }
#else

        if (Input.touches.Length != 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                
                startPos = Input.touches[0].position;
                isDragging = true;
                
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                endPos = Input.touches[0].position;
                isDragging = false;
                CalculateSwipe();
            }
        }
#endif

    }
    /// <summary>
    /// Logic behind swipe calculation
    /// </summary>
    private void CalculateSwipe()
    {

        // Delata between start position and end position is calculated
        Vector2 delta = endPos - startPos;
        //Debug.Log(delta.magnitude + " " + deadZone);
        // If the magnitude of delta is bigger then deadZone then the process proceeds
        if (delta.magnitude > deadZone)
        {
            float x = delta.x;
            float y = delta.y;
            if (Mathf.Abs(x) >= Mathf.Abs(y))
            {

                if (x > 0)
                {
                    swipeRight = true;
                    gameManager.RecieveInput(Swipe.RIGHT);
                }
                else
                {
                    swipeLeft = true;
                    gameManager.RecieveInput(Swipe.LEFT);
                }
            }
            else
            {
                if (y > 0)
                {
                    swipeUp = true;
                    gameManager.RecieveInput(Swipe.UP);
                }
                else
                {
                    swipeDown = true;
                    gameManager.RecieveInput(Swipe.DOWN);
                }
            }
        }


    }
}
