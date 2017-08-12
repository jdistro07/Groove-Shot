using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectID : MonoBehaviour
{
    public string ObjectIDMap;
    public string ObjectIDShips;

    private string IDMap;
    private string IDShips;

    void Start()
    {
        IDMap = ObjectIDMap;
        IDShips = ObjectIDShips;

        print("Map "+IDMap+"Ship "+IDShips);
    }

}
