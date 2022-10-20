using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public int voisins = 0;
    public bool alive = false;
    
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
    
    public void setAlive(bool alive)
    {
        this.alive = alive;
        
        if (alive)
            GetComponent<MeshRenderer>().enabled = true;
        else
            GetComponent<MeshRenderer>().enabled = false;
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
