using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int SCREEN_X = 86;
    int SCREEN_Y = 48;

    [SerializeField] private Cell[][] board;
    
    // Start is called before the first frame update
    void Start()
    {
        board = new Cell[SCREEN_X][];

        for (int i = 0; i < SCREEN_X; i++)
        {
            board[i] = new Cell[SCREEN_Y];
        }

        for (int i = 0; i < SCREEN_X; i++)
        {
            for (int j = 0; j < SCREEN_Y; j++)
            {
                // board[i][j] = new Cell(i, j);
                board[i][j] = Instantiate(Resources.Load("Cube", typeof(Cell)), new Vector3(i, j, 0f), Quaternion.identity) as Cell;
                board[i][j].setAlive(randomActiveCell());
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        CountNeighbors();
        
        populationControl();
    }

    void CountNeighbors()
    {
        for (int x = 0; x < SCREEN_X; x++)
        {
            for (int y = 0; y < SCREEN_Y; y++)
            {
                // N
                int numNeighbors = 0;
                if (y + 1 < SCREEN_Y)
                {
                    if (board[x][y + 1].alive)
                        numNeighbors++;
                }
                
                // E
                if (x + 1 < SCREEN_X)
                {
                    if (board[x + 1][y].alive)
                        numNeighbors++;
                }
                
                // S
                if (y - 1 >= 0)
                {
                    if (board[x][y - 1].alive)
                        numNeighbors++;
                }
                
                // W
                if (x - 1 >= 0)
                {
                    if (board[x - 1][y].alive)
                        numNeighbors++;
                }
                
                // NE
                if (x + 1 < SCREEN_X && y + 1 < SCREEN_Y)
                {
                    if (board[x + 1][y + 1].alive)
                        numNeighbors++;
                }
                
                // NW
                if (x - 1 >= 0 && y + 1 < SCREEN_Y)
                {
                    if (board[x-1][y+1].alive)
                        numNeighbors++;
                }
                
                // SE
                if (x + 1 < SCREEN_Y && y - 1 >= 0)
                {
                    if (board[x+1][y-1].alive)
                        numNeighbors++;
                }
                
                // SW
                if (x - 1 >= 0 && y - 1 >= 0)
                {
                    if (board[x-1][y-1].alive)
                        numNeighbors++;
                }
                
                board[x][y].voisins = numNeighbors;
            }
        }
       
    }

    bool randomActiveCell()
    {
        int rand = UnityEngine.Random.Range(0, 100);
        if (rand > 80)
            return true;
        return false;
    }

    void populationControl()
    {
        for (int x = 0; x < SCREEN_X; x++)
        {
            for (int y = 0; y < SCREEN_Y; y++)
            {
                if (board[x][y].alive)
                {
                    if (board[x][y].voisins != 2 || board[x][y].voisins != 3)
                    {
                        board[x][y].setAlive(false);
                    }
                }
                else
                {
                    if (board[x][y].voisins == 3)
                    {
                        board[x][y].setAlive(true);
                    }
                }
            } 
        }
    }
}
