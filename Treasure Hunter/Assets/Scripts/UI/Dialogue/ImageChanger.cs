using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum ImageType
{
    FACE = 0, BG
}

public class ImageChanger : MonoBehaviour
{
    public ImageType imageType;

    public Sprite[] images;
    public Image changeImage;

    public void Awake()
    {
        if (images.Length == 0)
        {
            Debug.LogError("No images available");
        }
    }

    public void Update()
    {
        changeImage.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }

    public void SetImage(int imageIndex)
    {
        if (images.Length < imageIndex)
        {
            Debug.LogError("No image for value");
            changeImage.enabled = false;
            return;
        }

        if (imageIndex == DialogueCommand.NON_IMAGE)
        {
            changeImage.enabled = false;
        }
        else
        {
            if (changeImage.enabled == false)
            {
                changeImage.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                changeImage.enabled = true;
                changeImage.sprite = images[imageIndex];
            }
            else
            {
                changeImage.sprite = images[imageIndex];
            }
        }
    }
}
