using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    private Card thisCard;
    
    private string[] rankStrings =
    {
        "A",
        "2",
        "3",
        "4",
        "5",
        "6",
        "7",
        "8",
        "9",
        "10",
        "J",
        "Q",
        "K"
    };
    
    public Sprite[] suitSprites = new Sprite[4];
    
    public TMP_Text cardNameDisplayText;
    public TMP_Text rankDisplayText;
    public Image suitImage;
    
    private string cardName;
    private string rankString;

    private void Awake()
    {
        thisCard = transform.parent.GetComponent<Card>();
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateCardDisplay();
    }

    private void UpdateCardDisplay()
    {
        rankString = rankStrings[(int)thisCard.rank];
        cardName = thisCard.rank + " of " + thisCard.suit;
        
        rankDisplayText.text = rankString;
        rankDisplayText.color = SuitColor();
        
        suitImage.sprite = suitSprites[(int)thisCard.suit];
        
        cardNameDisplayText.text = cardName;
    }

    //if the suit is spades or clubs it will return black, else it will return red.
    private Color SuitColor() => (int)thisCard.suit < 2 ? Color.black : Color.red;
    
}
