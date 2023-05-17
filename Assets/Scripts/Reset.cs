using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    public GameObject parent_puzzle, smile;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnMouseUp()
    {
        for(int i = 0; i < 4; i++)
        {
            parent_puzzle.transform.GetChild(i).GetComponent<drag>().on_tempel = false;
            parent_puzzle.transform.GetChild(i).GetComponent<drag>().on_pos = false;
            parent_puzzle.transform.GetChild(i).position = parent_puzzle.transform.GetChild(i).GetComponent<drag>().pos_awal;
            parent_puzzle.transform.GetChild(i).localScale = parent_puzzle.transform.GetChild(i).GetComponent<drag>().scale_awal;
        }
        smile.SetActive(false);
        parent_puzzle.GetComponent<feedback>().selesai = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
