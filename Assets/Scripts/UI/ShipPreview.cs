
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipPreview : MonoBehaviour {

    public List<GameObject> shipList;
    private int index = 0;

    public Button btnNext;

    // Use this for initialization
    void Start() {

        //Load all ship preview prefabs from the directory
        GameObject[] ships = Resources.LoadAll<GameObject>("shipPreview");

        foreach (GameObject c in ships)
        {
            /*
             * Instantiate ships as GameObjects
             * */
            GameObject _ships = Instantiate(c) as GameObject;
            _ships.transform.SetParent(GameObject.Find("ShipSpawn").transform);

            //Add ships to List
            shipList.Add(_ships);

            //Disable spawned objects and enable the list instead
            _ships.SetActive(false);
            shipList[index].SetActive(true);
        }
    }

    public void bntNext()
    {
        shipList[index].SetActive(false);

        //if last index then go back to the first index
        if (index == shipList.Count-1)
        {
            index = 0;
        }
        else
        {
            index++;
        }

        shipList[index].SetActive(true);
    }

    public void bntPrev()
    {
        shipList[index].SetActive(false);

        //if first index then go back to the last index
        if(index == 0)
        {
            index = shipList.Count - 1;
        }
        else
        {
            index--;
        }
        
        shipList[index].SetActive(true);
    }
}
