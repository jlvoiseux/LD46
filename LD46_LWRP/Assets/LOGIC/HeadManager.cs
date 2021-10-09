using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeadManager : MonoBehaviour
{
    public int[] heads;

    public Image currentHead;
    public Sprite boy; //0
    public Sprite girl; //1
    public Sprite custo; //2
    public Sprite paint; //3
    public int current = -1;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToNext()
    {
        current += 1;
        int newh = heads[current];
        if(newh == 0)
        {
            currentHead.enabled = true;
            currentHead.sprite = boy;
        }
        else if(newh == 1)
        {
            currentHead.enabled = true;
            currentHead.sprite = girl;
        }
        else if(newh == 2)
        {
            currentHead.enabled = true;
            currentHead.sprite = custo;
        }
        else if(newh == 3)
        {
            currentHead.enabled = true;
            currentHead.sprite = paint;
        }
        else if (newh == 4)
        {
            currentHead.enabled = false;
        }
    }
}
