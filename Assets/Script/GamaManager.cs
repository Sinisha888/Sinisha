using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class GamaManager : MonoBehaviour
{

    public List<Card> playerOneDeck = new List<Card>();
    public List<Card> playerTwoDeck = new List<Card>();
    public Transform[] cardSlotsPlayerOne;
    public Transform[] cardSlotsPlayerTwo;
    public bool[] availableCardSlotsPlayerOne;
    public bool[] availableCardSlotsPlayerTwo;
    public Text deckSizePlayerOneText;
    public Text deckSizePlayerTwoText;
    public Button playerOne;
    public Button playerTwo;
    private int playerOneCardsDrawn = 0;
    private int playerTwoCardsDrawn = 0;
    
    
    private void Start()
    {
        
        playerTwo.gameObject.GetComponent<Button>().interactable = false; //Player One will be first
    }

    public void DrawCardPlayerOne() ///Draw card Func for player one
    {
        
        if(playerOneDeck.Count >= 1)
        {
            Card randCard = playerOneDeck[Random.Range(0, playerOneDeck.Count)];
            for (int i = 0; i < availableCardSlotsPlayerOne.Length; i++)
            {
                
                if(availableCardSlotsPlayerOne[i] == true)
                {
                    randCard.gameObject.SetActive(true);
                    randCard.transform.position = cardSlotsPlayerOne[i].position;
                    availableCardSlotsPlayerOne[i] = false;
                    playerOneDeck.Remove(randCard);
                    playerOneCardsDrawn += 1;
                    
                    return;
                }
                

                if (playerOneCardsDrawn == 4)///after x cards drawn its player two trun
                {
                    
                    playerOne.gameObject.GetComponent<Button>().interactable = false;
                    playerTwo.gameObject.GetComponent<Button>().interactable = true;
                    playerTwoCardsDrawn = 0;
                    Debug.Log("playerTwoTurn");
                }
                
            }
        }
    }
    
    public void DrawCardPlayerTwo()///Draw card Func for player two
    {
        
        if(playerTwoDeck.Count >= 1)
        {
            Card randCard = playerTwoDeck[Random.Range(0, playerTwoDeck.Count)];
            for (int i = 0; i < availableCardSlotsPlayerTwo.Length; i++)
            {
                
                if(availableCardSlotsPlayerTwo[i] == true)
                {
                    randCard.gameObject.SetActive(true);
                    randCard.transform.position = cardSlotsPlayerTwo[i].position;
                    availableCardSlotsPlayerTwo[i] = false;
                    playerTwoDeck.Remove(randCard);
                    playerTwoCardsDrawn += 1;
                    return;
                }
                if (playerTwoCardsDrawn == 4)///after x cards drawn its player one trun
                {
                    
                    playerTwo.gameObject.GetComponent<Button>().interactable = false;
                    playerOne.gameObject.GetComponent<Button>().interactable = true;
                    playerOneCardsDrawn = 0;
                    Debug.Log("playerOneTurn");
                    
                }
                
            }
        }
    }

    private void SlotChecker()
    {
        for (int i = 0; i < availableCardSlotsPlayerOne.Length; i++)
        {
            if (availableCardSlotsPlayerOne[i] == false && cardSlotsPlayerOne[i] == false)
            {
                availableCardSlotsPlayerOne[i] = true;
            }
        }
    }

    public void Update() /// updates the amount of cards in deck
    {
        deckSizePlayerOneText.text = playerOneDeck.Count.ToString();
        deckSizePlayerTwoText.text = playerTwoDeck.Count.ToString();
    }
}
