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

    public void setIcon(float Value)
    {
        if (Value == 1)
        {
            sourceImage.sprite = defaultIcon;
        }
        if (Value == 2)
        {
            sourceImage.sprite = noneIcon;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
