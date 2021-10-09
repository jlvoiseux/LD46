using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTextureOnClick : MonoBehaviour
{
    public GameObject tip;
    public float radius = 5;
    public GameObject brush;
    public ToggleSpriteOnClick tsoc;

    public RenderTexture texture;
    public Texture initialTexture;
    private RenderTexture buffer;
    public float updateInterval = 0.016f; // Seconds
    private float lastUpdateTime = 0;
    private Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        Graphics.Blit(initialTexture, texture);
        buffer = new RenderTexture(texture.width, texture.height, texture.depth, texture.format);
    }

    // Update is called once per frame
    public void Update()
    {
        lastUpdateTime += Time.deltaTime;
        Vector2 mouseTexturePos = tip.transform.position + new Vector3(initialTexture.width/2, initialTexture.height/2, 0);
        mouseTexturePos.x /= initialTexture.width;
        mouseTexturePos.y /= initialTexture.height;
        rend.sharedMaterial.SetVector("_SourcePos", new Vector4(mouseTexturePos.x, mouseTexturePos.y, 0, 0));
        rend.sharedMaterial.SetInt("_IsDown", tsoc.isDown);

        if (lastUpdateTime > updateInterval)
        {
            UpdateTexture();
            Debug.Log("GO");
            lastUpdateTime = 0;
        }
    }


    public void UpdateTexture()
    {
        Graphics.Blit(texture, buffer, rend.sharedMaterial);
        Graphics.Blit(buffer, texture);
    }

}
