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

        public Case(int x, int y)
        {
            obj = new GameObject();
            var mf = obj.AddComponent<MeshFilter>();
            var mr = obj.AddComponent<MeshRenderer>();
            mf.mesh = Resources.GetBuiltinResource<Mesh>("Cube.fbx");
            
            obj.transform.position = new Vector3(x, y, 0f);
            voisins = 0;
            alive = false;
        }
        
        public void setAlive()
        {
            if (alive)
                obj.GetComponent<MeshRenderer>().enabled = true;
            else
                obj.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    [SerializeField] private Case[][] board;
    
    // Start is called before the first frame update
    void Start()
    {
        int x = 86;
        int y = 48;
        
        board = new Case[x][];

        for (int i = 0; i < x; i++)
        {
            board[i] = new Case[y];
        }

        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                board[i][j] = new Case(i, j);
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
