using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public class Case
    {
        public GameObject obj;
        public int voisins;
        public bool alive;

        public Case()
        {
            obj = new GameObject();
            voisins = 0;
            alive = false;
        }
    }

    [SerializeField] private Case[][] board;
    
    // Start is called before the first frame update
    void Start()
    {
        board = new Case[20][];

        for (int i = 0; i < 20; i++)
        {
            board[i] = new Case[20];
        }

        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                board[i][j] = new Case();
                board[i][j].obj 
            }
        }
        
        Debug.Log(board[0][2].alive);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void renderBoard()
    {
        
    }
}
