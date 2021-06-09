using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class NumberInputManager : MonoBehaviour, IMove
{
    public Text[] texts;
    private int selected_text = 0;
    private int total_texts;
    void Start()
    {
        total_texts = texts.Length;
    }

    void Update()
    {
        handleMovement();
    }

    public void handleMovement()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        if(Math.Abs(vertical) > .8f || Math.Abs(horizontal) > .8f) move(horizontal, vertical);
    }

    public void move(float x = 0, float y = 0)
    {
        if(y > 0){
            changeNumber(true);
        }
        else changeNumber(false);
    }

    private void changeNumber(bool next)
    {
        int actual_number = int.Parse(texts[selected_text].text); 
        actual_number = (next ? (actual_number >= 45 ? 0: actual_number++) : (actual_number <= 0 ? 45: actual_number--));
        updateNumber(actual_number);
    }

    private void updateNumber(int actual_number) => texts[selected_text].text = actual_number.ToString();
    
}