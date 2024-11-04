//The following code snippet was adapted from BMo (youtube, 2022)

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
    public Sprite fullHeart, threeQuarterHeart, halfHeart, quarterHeart, emptyHeart;
    Image heartImage;

    private void Awake()
    {
        heartImage = GetComponent<Image>();
    }

    public void SetHeartState(HeartState state)
    {
        switch (state) //change the displayed heart sprite based on the setstate that is passed in
        {
            case HeartState.emptyHeart:
                heartImage.sprite = emptyHeart;
                break;
            case HeartState.quarterHeart:
                heartImage.sprite = quarterHeart;
                break;
            case HeartState.halfHeart:
                heartImage.sprite = halfHeart;
                break;
            case HeartState.threeQuarterHeart:
                heartImage.sprite = threeQuarterHeart;
                break;
            case HeartState.fullHeart:
                heartImage.sprite = fullHeart;
                break;
        }
    }
}

public enum HeartState
{
    emptyHeart = 0,
    quarterHeart = 1,
    halfHeart = 2,
    threeQuarterHeart = 3,
    fullHeart = 4
}
