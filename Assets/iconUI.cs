using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class iconUI : MonoBehaviour
{
    public Sprite defaultIcon;
    public Sprite noneIcon;

    private Image sourceImage;

    private void Start()
    {
        sourceImage = GetComponent<Image>();
        sourceImage.sprite = noneIcon;
    }

    public void toggleIcon()
    {
        if(sourceImage.sprite = defaultIcon)
        {
            sourceImage.sprite = noneIcon;
        }
        else if (sourceImage.sprite = noneIcon)
        {
            sourceImage.sprite = defaultIcon;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
