using System;
using UnityEngine;

public class Props_Text : Props_1
{
    private TextMesh text;

    public event EventHandler LetterNotDestroyed;
    public event EventHandler LetterDestroyed;

    void Awake()
    {
        text = GetComponent<TextMesh>();
    }

    public void Initialize(char c)
    {
        text.text = c.ToString();
    }

    protected override void DestroyThis()
    {  
        LetterDestroyed?.Invoke(this, EventArgs.Empty);
        Destroy(gameObject);
    }

    void OnBecameInvisible()
    {
        LetterNotDestroyed?.Invoke(this, EventArgs.Empty);
        Destroy(gameObject);
    }
}
