using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root : MonoBehaviour
{
    public Group pice;

	void Start ()
    {
		
	}
	
	void Update ()
    {
		if (Input.GetKeyDown(KeyCode.A))
        {
            pice.MakeMove(-1);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            pice.MakeMove(1);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            pice.MakeTurn(1);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            pice.MakeTurn(-1);
        }
    }

    public void NextTurn()
    {
        
    }
}
