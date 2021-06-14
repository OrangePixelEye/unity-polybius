using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class NumberInput : MonoBehaviour, IMove
{
    public TextMesh[] texts;
    protected int selected_text = 0;
    protected int total_texts;

    void Start()
    {
        total_texts = texts.Length;
    }

    void FixedUpdate()
    {
        handleMovement();
    }

    public void handleMovement()
    {
        if(Input.GetAxis("Fire1") >= 0.3f) enterGame();
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        if(Math.Abs(vertical) >= 0.45f|| Math.Abs(horizontal) >= 0.45f) move(horizontal, vertical);
    }

    protected virtual void enterGame()
    {
        int[] code = new int[texts.Length];
        for(int i = 0; i < texts.Length; i++)
        {
            code[i] = int.Parse(texts[i].text);
        }
        NumberInputManager.Instance.useCode(code);  
    }

    public void move(float x = 0, float y = 0)
    {
        if(x > 0) changeNumberSelected(true);
        if(x < 0) changeNumberSelected(false);
        if(y > 0) changeText(true);
        if (y < 0) changeText(false);
    }

    protected virtual void changeNumberSelected(bool next)
    {
        texts[selected_text].color = Color.gray;
        if(next)
        {
            selected_text++;
            if(selected_text > texts.Length - 1) selected_text = 0;
        }
        else
        {
            selected_text--;
            if(selected_text < 0) selected_text = texts.Length - 1;
        }
        
        StartCoroutine("wait");
        texts[selected_text].color = Color.white;
    }

    private IEnumerator wait()
    {
        yield return new WaitForSecondsRealtime(0.1f);
    }

    protected virtual void changeText(bool next)
    {
        int actual_number = int.Parse(texts[selected_text].text); 
        if(next)
        {
            actual_number++;
            if(actual_number > 45) actual_number = 0; 
        }
        else
        {
            actual_number--;
            if(actual_number < 0) actual_number = 45;
        }
        
        //actual_number = (next ? (actual_number >= 45 ? 0: actual_number++) : (actual_number <= 0 ? 45: actual_number--));
        StartCoroutine(updateText(actual_number.ToString()));
    }

    protected virtual IEnumerator updateText(string new_text)
    {
        yield return new WaitForSecondsRealtime(0.15f);
        texts[selected_text].text = new_text;  
    }
    
}