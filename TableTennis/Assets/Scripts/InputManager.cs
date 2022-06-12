using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    Vector2 MousePos;
    public static InputManager instance;
    public event Action<Vector2> MoveBat;
    private bool isInputActive = false;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    public void ActivateInput()
    {
        isInputActive = true;
    }

    public void DeActivateinput()
    {
        isInputActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isInputActive)
        {
            MousePos = Input.mousePosition;
            if (MoveBat != null)
            {
                MoveBat(MousePos);
            }
        }
    }
}
