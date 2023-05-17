// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Card : MonoBehaviour
// {
//     public static bool DO_NOT = false;

//     [SerializeField]
//     private int _state;
//     [SerializeField]
//     private int _cardValue;
//     [SerializeField]
//     private bool _initialized = false;

//     private Sprite _cardBack;
//     private Sprite _cardFace;

//     private GameObject _manager;

//     void Start()
//     {
//         _state = 0;
//         _manager = GameObject.FindGameObjectWithTag("Manager");
//     }

//     // public void setupGraphics() 
//     // {
//     //     _cardBack = _manager.GetComponent<GameManager>().getCardBack();
//     //     _cardFace = _manager.GetComponent<GameManager>().getCardFace(_cardValue);
    
//     //     flipCard();
//     // }

//     // void flipCard()
//     // {
//     //     if (_state == 0 && !DO_NOT)
//     //         GetComponent<Image>().sprite = _cardBack;
//     // }



// }
