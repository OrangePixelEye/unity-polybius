using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class NumberInput : MonoBehaviour, IMove
{
    public Text[] texts;
    private int selected_text = 0;
    private int total_texts;

    [System.Serializable]
    public struct Codes{
        public int[] code;
    }

    public Codes[] codes;

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
        if(Math.Abs(vertical) >= 0.3f|| Math.Abs(horizontal) >= 0.3f) move(horizontal, vertical);
    }

    private void enterGame()
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
        if(y > 0) changeNumber(true);
        if (y < 0) changeNumber(false);
    }

    private void changeNumberSelected(bool next)
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
        yield return new WaitForSeconds(0.1f);
    }

    private void changeNumber(bool next)
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
        StartCoroutine(updateNumber(actual_number));
    }

    private IEnumerator updateNumber(int actual_number)
    {
        yield return new WaitForSeconds(0.15f);
        texts[selected_text].text = actual_number.ToString();  
    }
    
}