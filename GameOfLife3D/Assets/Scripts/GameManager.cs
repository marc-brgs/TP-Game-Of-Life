using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int SCREEN_X = 85;
    int SCREEN_Y = 48;
    public float speed = 0.1f;
    private float timer = 0;

    public float chanceReproductionLoup = 0.5f;
    public float chanceReproductionMouton = 0.5f;
    public int maxLifespanLoup = 2;
    public int maxLifespanMouton = 5;
    
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
                if (board[i][j].alive)
                {
                    board[i][j].type = randomTypeCell();
                }
                else
                {
                    board[i][j].type = 0;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= speed)
        {
            timer = 0f;
            countNeighbors();
            populationControl();
            colorizeType();
        }
        else
        {
            timer += Time.deltaTime;
        }
    }
    
    bool randomActiveCell()
    {
        int rand = UnityEngine.Random.Range(0, 100);
        if (rand > 75)
            return true;
        return false;
    }

    int randomTypeCell()
    {
        int rand = UnityEngine.Random.Range(0, 100);
        if (rand < 33)
            return 1;
        else if (rand > 66)
            return 3;
        else
            return 2;
    }
    
    void countNeighbors()
    {
        for (int x = 0; x < SCREEN_X; x++)
        {
            for (int y = 0; y < SCREEN_Y; y++)
            {
                // N
                int numLoup = 0;
                int numMouton = 0;
                int numHerbe = 0;
                
                if (y + 1 < SCREEN_Y)
                {
                    if (board[x][y + 1].alive)
                    {
                        if(board[x][y + 1].type == 1)
                            numLoup++;
                        else if (board[x][y + 1].type == 2)
                            numMouton++;
                        else if (board[x][y + 1].type == 3)
                            numHerbe++;
                    }
                        
                }
                
                // E
                if (x + 1 < SCREEN_X)
                {
                    if (board[x+1][y].alive)
                    {
                        if(board[x+1][y].type == 1)
                            numLoup++;
                        else if (board[x+1][y].type == 2)
                            numMouton++;
                        else if (board[x+1][y].type == 3)
                            numHerbe++;
                    }
                }
                
                // S
                if (y - 1 >= 0)
                {
                    if (board[x][y-1].alive)
                    {
                        if(board[x][y-1].type == 1)
                            numLoup++;
                        else if (board[x][y-1].type == 2)
                            numMouton++;
                        else if (board[x][y-1].type == 3)
                            numHerbe++;
                    }
                }
                
                // W
                if (x - 1 >= 0)
                {
                    if (board[x-1][y].alive)
                    {
                        if(board[x-1][y].type == 1)
                            numLoup++;
                        else if (board[x-1][y].type == 2)
                            numMouton++;
                        else if (board[x-1][y].type == 3)
                            numHerbe++;
                    }
                }
                
                // NE
                if (x + 1 < SCREEN_X && y + 1 < SCREEN_Y)
                {
                    if (board[x+1][y+1].alive)
                    {
                        if(board[x+1][y+1].type == 1)
                            numLoup++;
                        else if (board[x+1][y+1].type == 2)
                            numMouton++;
                        else if (board[x+1][y+1].type == 3)
                            numHerbe++;
                    }
                }
                
                // NW
                if (x - 1 >= 0 && y + 1 < SCREEN_Y)
                {
                    if (board[x-1][y+1].alive)
                    {
                        if(board[x-1][y+1].type == 1)
                            numLoup++;
                        else if (board[x-1][y+1].type == 2)
                            numMouton++;
                        else if (board[x-1][y+1].type == 3)
                            numHerbe++;
                    }
                }
                
                // SE
                if (x + 1 < SCREEN_Y && y - 1 >= 0)
                {
                    if (board[x+1][y-1].alive)
                    {
                        if(board[x+1][y-1].type == 1)
                            numLoup++;
                        else if (board[x+1][y-1].type == 2)
                            numMouton++;
                        else if (board[x+1][y-1].type == 3)
                            numHerbe++;
                    }
                }
                
                // SW
                if (x - 1 >= 0 && y - 1 >= 0)
                {
                    if (board[x-1][y-1].alive)
                    {
                        if(board[x-1][y-1].type == 1)
                            numLoup++;
                        else if (board[x-1][y-1].type == 2)
                            numMouton++;
                        else if (board[x-1][y-1].type == 3)
                            numHerbe++;
                    }
                }
                
                board[x][y].voisinsLoup = numLoup;
                board[x][y].voisinsMouton = numMouton;
                board[x][y].voisinsHerbe = numHerbe;
            }
        }
       
    }

    void populationControl()
    {
        for (int x = 0; x < SCREEN_X; x++)
        {
            for (int y = 0; y < SCREEN_Y; y++)
            {
                if (board[x][y].alive)
                {
                    // Game of Life basique
                    /* if (board[x][y].voisins != 2 && board[x][y].voisins != 3)
                    {
                        board[x][y].setAlive(false);
                    } */
                    
                    // Lifespan loup et mouton counter attack (3 moutons peuvent tuer un loup)
                    if (board[x][y].type == 1)
                    {
                        if(board[x][y].lifespan > maxLifespanLoup)
                            board[x][y].setAlive(false);
                        if (board[x][y].voisinsMouton > 2)
                            board[x][y].setAlive(false);
                    }
                    
                    // Eat mouton
                    if (board[x][y].type == 2)
                    {
                        if (board[x][y].voisinsLoup > 0)
                            board[x][y].setAlive(false);
                        
                        if(board[x][y].lifespan > maxLifespanMouton)
                            board[x][y].setAlive(false);
                    }
                    
                    // Eat herbe
                    if (board[x][y].type == 3)
                    {
                        if (board[x][y].voisinsMouton > 0)
                            board[x][y].setAlive(false);
                    }
                    
                }
                else
                {
                    // Game of Life basique
                    /* if (board[x][y].voisins == 3)
                    {
                        board[x][y].setAlive(true);
                    } */
                    
                    // Reproduction mouton
                    if (board[x][y].voisinsMouton > 2)
                    {
                        int rand = UnityEngine.Random.Range(0, 100);
                        if (rand < chanceReproductionMouton * 100)
                            board[x][y].setAlive(true, 2);
                    }
                    
                    // Reproduction loup
                    if (board[x][y].voisinsLoup > 2)
                    {
                        int rand = UnityEngine.Random.Range(0, 100);
                        if (rand < chanceReproductionLoup * 100)
                            board[x][y].setAlive(true, 1);
                    }
                }
                
                board[x][y].lifespan++;
            } 
        }
    }
    
    // Recolor cell depending of their type
    void colorizeType()
    {
        for (int x = 0; x < SCREEN_X; x++)
        {
            for (int y = 0; y < SCREEN_Y; y++)
            {
                if(board[x][y].type == 1)
                    board[x][y].GetComponent<Renderer>().material.color = Color.black;
                else if(board[x][y].type == 2)
                    board[x][y].GetComponent<Renderer>().material.color = Color.white;
                else if(board[x][y].type == 3)
                    board[x][y].GetComponent<Renderer>().material.color = Color.green;
            }
        }
    }
}
