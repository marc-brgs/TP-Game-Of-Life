using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public int voisins; // basique
    public int voisinsLoup = 0;
    public int voisinsHerbe = 0;
    public int voisinsMouton = 0;
    public bool alive = false;
    public int type; // 0 vide, 1 loup, 2 mouton, 3 herbe
    public int lifespan = 0;
    public int lastEat = 0;

    public void setAlive(bool alive, int type=0)
    {
        this.alive = alive;

        if (alive)
        {
            GetComponent<MeshRenderer>().enabled = true;
            lifespan = 0;
            this.type = type;
        }
        else
        {
            GetComponent<MeshRenderer>().enabled = false;
            this.type = type;
        }
    }
}
