using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSpriteOnClick : MonoBehaviour
{
    public Sprite spriteUp;
    public Sprite spriteDown;
    public int isDown = 0;

    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = spriteUp;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            sr.sprite = spriteDown;
            isDown = 1;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            sr.sprite = spriteUp;
            isDown = 0;
        }
    }
}
