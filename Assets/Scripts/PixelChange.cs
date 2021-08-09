using System;
using UnityEngine;
using UnityEngine.UI;

public class PixelChange : MonoBehaviour
{
    public RenderTexture renderTexture; // renderTextuer that you will be rendering stuff on
   // public Renderer renderer; // renderer in which you will apply changed texture
    Texture2D texture;

    float radius = 3f;
    Text percentText;

    void Start()
    {

        texture = new Texture2D(renderTexture.width, renderTexture.height);
        GetComponent<Renderer>().material.mainTexture = texture;
        //make texture2D because you want to "edit" it. 
        //however this is not a way to apply any post rendering effects because
        //this way, you are reading it through CPU(slow).
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            RenderTexture.active = renderTexture;
            texture.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
            int count = 0;
            for (int i = 0; i < renderTexture.width; i++)
                for (int j = 0; j < renderTexture.height; j++)
                {
                    Color current = texture.GetPixel(i, j);
                    Vector2 currentPixel = new Vector2(i, j);
                    Vector2 mousePos = new Vector2(0, 0); // mouse'un o anki pixel posizyonu

                    if (current != Color.white) count++;
                    else if (Vector2.Distance(currentPixel, mousePos) < radius)
                    {

                        texture.SetPixel(i, j, new Color(255, 255,255));
                        texture.Apply();
                        count++;
                    }
                }
            percentText.text = (count / renderTexture.width * renderTexture.height).ToString();
        }
    }
}