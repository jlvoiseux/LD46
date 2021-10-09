using System.Collections;
using System.Collections.Generic;
using FreeDraw;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Sprite imageToErase1;
    public Texture2D imageToReveal1;
    public Sprite imageToErase2;
    public Texture2D imageToReveal2;
    public Sprite imageToErase3;
    public Texture2D imageToReveal3;
    public Sprite imageToErase4;
    public Texture2D imageToReveal4;

    public Sprite trans1;
    public Sprite trans2;
    public Sprite trans3;

    public Drawable dr;
    public SpriteRenderer sr;

    public AudioClip cool;
    public AudioClip uncool;
    public AudioSource ase;

    public SceneFader sf;

    int state = 0;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("PaintStep"))
        {
            state = PlayerPrefs.GetInt("PaintStep");
        }
        Debug.Log(state);
        if(state == 0)
        {
            sr.sprite = imageToErase1;
            dr.underTexture = imageToReveal1;
            ase.clip = cool;
            dr.prop = 18;
            ase.Play();
        }
        else if(state == 1)
        {
            sr.sprite = imageToErase2;
            dr.underTexture = imageToReveal2;
            ase.clip = cool;
            dr.prop = 18;
            ase.Play();
        }
        else if (state == 2)
        {
            sr.sprite = imageToErase3;
            dr.underTexture = imageToReveal4;
            ase.clip = uncool;
            dr.prop = 30;
            ase.Play();

        }
        dr.SetupPaints();
    }

    // Update is called once per frame
    void Update()
    {
        if(dr.isErased)
        {
            
            
            int nextScene = 0;
            if(state == 0)
            {
                sf.fadeOutUIImage.sprite = trans1;
                nextScene = 3;
                PlayerPrefs.SetInt("PaintStep", state+1);
            }
            else if (state == 1)
            {
                sf.fadeOutUIImage.sprite = trans2;
                nextScene = 4;
                PlayerPrefs.SetInt("PaintStep", state + 1);

            }
            else if (state == 2)
            {
                sf.fadeOutUIImage.sprite = trans3;
                nextScene = 5;
                PlayerPrefs.SetInt("PaintStep", 0);
            }
            StartCoroutine(sf.FadeAndLoadScene(SceneFader.FadeDirection.In, nextScene));
            dr.ResetCanvas();
        }
    }
}
