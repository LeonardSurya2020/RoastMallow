using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManage : MonoBehaviour
{
    [SerializeField] private Texture2D[] cursorTextureArray;
    [SerializeField] private int FrameCount;
    [SerializeField] private float FrameRate;

    private int currentFrame;
    private float frameTimer;

    [SerializeField] private Texture2D cursorTexture;

    private Vector2 cursorHotSpot;
    // Start is called before the first frame update
    void Start()
    {
        cursorHotSpot = new Vector2(cursorTexture.width / 2, cursorTexture.height / 2);
        Cursor.SetCursor(cursorTextureArray[0], cursorHotSpot, CursorMode.Auto);

    }

    private void Update()
    {
            frameTimer -= Time.deltaTime;
            if(frameTimer <= 0f)
            {
                frameTimer += FrameRate;
                currentFrame = (currentFrame + 1) % FrameCount;
                Cursor.SetCursor(cursorTextureArray[currentFrame], cursorHotSpot, CursorMode.Auto);       
            }
        
    }
}
