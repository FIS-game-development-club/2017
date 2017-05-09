using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root : MonoBehaviour
{
    public Group pice;
    public List<GameObject> blocks;
    public List<Material> colors;

    void Start()
    {
        NextTurn();
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
        CheckForRow();
        MakeNewBlock();
    }

    public void MakeNewBlock()
    {
        int n = Mathf.FloorToInt(Random.value * blocks.Count);
        int m = Mathf.FloorToInt(Random.value * colors.Count);
        GameObject block = blocks[n];
        Material color = colors[m];
        GameObject g = GameObject.Instantiate(block, transform.position, Quaternion.identity);
        pice = g.GetComponent<Group>();
        pice.board = gameObject;
        int c = 0;
        if (pice.pivot == null)
        {
            c = pice.transform.childCount;
            for (int i = 0; i < c; i++)
            {
                pice.transform.GetChild(i).GetComponent<Renderer>().material = color;
            }
        }
        else
        {
            c = pice.pivot.transform.childCount;
            for (int i = 0; i < c; i++)
            {
                pice.pivot.gameObject.transform.GetChild(i).GetComponent<Renderer>().material = color;
            }
        }
    }

    public void CheckForRow()
    {
        Cube[] cubes = gameObject.GetComponentsInChildren<Cube>();
        bool[,] map = new bool[20, 10];
        bool[] hits = new bool[20];
        int[] bumps = new int[20];

        for (int i = 0; i < cubes.Length; i++)
        {
            map[cubes[i].target_y, cubes[i].target_x] = true;
        }
        int n = 0;
        for (int r = 0; r < 20; r++)
        {
            bool match = true;
            for (int c = 0; c < 10; c++)
            {
                if (!map[r,c])
                    match = false;
            }
            if (match)
            {
                n++;
                hits[r] = true;
                bumps[r] = n;
            }
        }

        for (int i = 0; i < cubes.Length; i++)
        {
            if (hits[cubes[i].target_y])
                Destroy(cubes[i].gameObject);
        }
    }
}
