using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Card : MonoBehaviour
{
    //defines the thirteen ranks
    public enum Ranks
    {
        Ace,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King
    }
    
    //defines the four suits
    public enum Suits
    {
        Spades,
        Clubs,
        Hearts,
        Diamonds
    }

    public void Start()
    {
        SetRankAndSuitAtRandom();
    }

    public Suits suit;
    public Ranks rank;

    public void SetRankAndSuitAtRandom()
    {
        //set rank
        rank = (Ranks)Random.Range(0, Enum.GetNames(typeof(Ranks)).Length);
        
        //set suit
        suit = (Suits)Random.Range(0, Enum.GetNames(typeof(Suits)).Length);
    }

    public void SetRankAndSuit(int targetRank, int targetSuit)
    {
        //set rank
        rank = (Ranks) targetRank;
        
        //set suit
        suit = (Suits) targetSuit;
    }
}
