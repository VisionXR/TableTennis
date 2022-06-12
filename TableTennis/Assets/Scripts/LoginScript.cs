using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class LoginScript : MonoBehaviour
{
    public static LoginScript instance;
    public TMP_InputField NameIF;
    public event Action<string> LoginClicked;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnLoginButtonClicked()
    {
        LoginClicked(NameIF.text);
    }
}
