using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sistem : MonoBehaviour
{
    public static sistem instance;
    public int ID;
    public GameObject spawn;
    public GameObject[] hewan;
    
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this; 
    }
    void Start()
    {
        ID = 0;
        SpawnObject();
    }

    public void SpawnObject()
    {
        GameObject BendaSebelumnya = GameObject.FindGameObjectWithTag("Hewan");
        if (BendaSebelumnya != null) Destroy(BendaSebelumnya);
        GameObject Benda = Instantiate (hewan[ID]);
        Benda.transform.SetParent(spawn.transform,false);
        Benda.transform.localScale = new Vector3(10,4,7);
    }

    private void update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            GantiHewan (true);
        }
         if (Input.GetKeyDown(KeyCode.LeftArrow))
         {
             GantiHewan (false);
         }
    }


    public void GantiHewan(bool Kanan)
    {
        if(Kanan)
        {
            if(ID >= hewan.Length-1)
            {
                ID = 0;
            }
            else
            {
                ID++;  
            }
        }
        else
        {
            if(ID <= 0)
            {
                ID = hewan.Length-1;
            }
            else
            {
                ID--;  
            }
        }
        SpawnObject();
    }    
}