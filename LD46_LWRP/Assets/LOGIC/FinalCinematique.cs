using System.Collections;
using System.Collections.Generic;
using UnityEngine.Experimental.Rendering.LWRP;
using UnityEngine;

public class FinalCinematique : MonoBehaviour
{
    public Animator animZoom;
    public Animator animImg;
    public PixelPerfectCamera ppc;

    public bool started = false;
    float tcount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(started)
        {
            tcount += Time.deltaTime;
            if(tcount > 15)
            { 
                StartCoroutine(GameObject.FindObjectOfType<SceneFader>().FadeAndLoadScene(SceneFader.FadeDirection.In, 0));
            }
        }
    }

    public void playFinal()
    {
        ppc.enabled = false;
        animImg.SetBool("ReadyToPlay", true);
        animZoom.SetBool("ReadyToPlay", true);
        started = true;
    }
}
