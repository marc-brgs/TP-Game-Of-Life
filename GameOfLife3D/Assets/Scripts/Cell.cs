using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public int voisinsLoup = 0;
    public int voisinsHerbe = 0;
    public int voisinsMouton = 0;
    public bool alive = false;
    public int type; // 0 vide, 1 loup, 2 mouton, 3 herbe
    public int lifespan = 0;
    public int lastEat = 0;
    
    /*public Cell(int x, int y)
    {
        obj = new GameObject();
        var mf = obj.AddComponent<MeshFilter>();
        var mr = obj.AddComponent<MeshRenderer>();
        mf.mesh = Resources.GetBuiltinResource<Mesh>("Cube.fbx");
        
        obj.transform.position = new Vector3(x, y, 0f);
        voisins = 0;
        alive = false;
    }*/
    
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

        // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
