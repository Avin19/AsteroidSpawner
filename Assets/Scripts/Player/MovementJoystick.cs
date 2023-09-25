using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class MovementJoystick : MonoBehaviour
{
    [SerializeField] private GameObject joystick;
    [SerializeField] private GameObject JoystickBg;
    [SerializeField] private Vector2 joystickVec;
    [SerializeField] private Vector2 joystickTouchPos;
    [SerializeField] private Vector2 joystickOriginalPos;
   
    
    private float joystickRadius;

    void Start()
    {
        joystickOriginalPos = JoystickBg.transform.position;
        joystickRadius = JoystickBg.GetComponent<RectTransform>().sizeDelta.y/4;
    }
    public void PointerDown()
    {   // Click on the screen and setting up  joystick position 
        joystick.transform.position = Input.mousePosition;
        JoystickBg.transform.position = Input.mousePosition;
        joystickTouchPos = Input.mousePosition;
    }
    public void Drag(BaseEventData baseEventData)
    {
        PointerEventData pointerEventData = baseEventData as PointerEventData;
        Vector2 dragPos = pointerEventData.position;
        joystickVec = (dragPos - joystickTouchPos ).normalized;
        Debug.Log(joystickVec);

        float joystickDist = Vector2.Distance(dragPos,joystickTouchPos);

        if(joystickDist < joystickRadius)
        {
            joystick.transform.position = joystickTouchPos + joystickVec*joystickDist;
        }
        else
        {
             joystick.transform.position = joystickTouchPos + joystickVec* joystickRadius;
        }
    }
    public void PointerUp()
    { // When click is up the joystick back to original position
        joystickVec = Vector2.zero;
        joystick.transform.position = joystickOriginalPos;
        JoystickBg.transform.position = joystickOriginalPos;

    }
    public Vector2 JoystickVector()
    {
        return joystickVec;
    }
    
}
