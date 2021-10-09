using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse32 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(Mathf.Clamp(worldPos.x, -112, 112), Mathf.Clamp(worldPos.y, -72, 56));
    }
}
