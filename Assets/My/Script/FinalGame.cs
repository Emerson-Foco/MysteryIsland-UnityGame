using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalGame : MonoBehaviour
{
    public int chackObjectives;
    public PlayerCollect playerCollect;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        chackObjectives = playerCollect.contObjectiveComplete;
    }

}
