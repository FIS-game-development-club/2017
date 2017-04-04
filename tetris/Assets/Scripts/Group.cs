using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Group : MonoBehaviour
{
    public float speed;
    public GameObject board;
    public GameObject pivot;
    private Root root;
    public int target_x;

    void Start()
    {
        root = board.GetComponent<Root>();
    }

    void Update()
    {
        gameObject.transform.Translate(Vector3.down * Time.deltaTime * speed);

        transform.position = new Vector3(target_x, transform.position.y, 0);
    }

    public void Hit()
    {
        Cube[] cubes = GetComponentsInChildren<Cube>();
        for (int i = 0; i < cubes.Length; i++)
        {
            cubes[i].gameObject.transform.parent = board.transform;
            cubes[i].gameObject.transform.rotation = Quaternion.identity;
            cubes[i].target_x = Mathf.RoundToInt(cubes[i].transform.position.x);
            cubes[i].target_y = Mathf.RoundToInt(cubes[i].transform.position.y);
            if (cubes[i].target_y < 1)
                cubes[i].target_y = 1;
            cubes[i].speed = 10;
            cubes[i].master = null;
            cubes[i].c.isTrigger = true;
        }
        root.NextTurn();
        Destroy(gameObject);
    }

    public void MakeMove(int x)
    {
        Cube[] cubes = GetComponentsInChildren<Cube>();
        for(int i = 0; i < cubes.Length; i++)
        {
            RaycastHit[] hits = Physics.RaycastAll(new Ray(cubes[i].transform.position, new Vector3(x, 0, 0)), 1.0f);
            for (int j = 0; j < hits.Length; j++)
            {
                Cube c = hits[j].collider.gameObject.GetComponent<Cube>();
                if (c == null)
                    return;
                bool is_part_of_this = false;
                for (int k = 0; k < cubes.Length; k++)
                {
                    if (c == cubes[k])
                        is_part_of_this = true;
                }
                if (!is_part_of_this)
                    return;
            }
        }
        target_x += x;
    }

    public void MakeTurn(int r)
    {
        //Model w/ complex numbers!
        Transform p = transform.FindChild("pivot");
        if (p == null)
            return;
        p.transform.Rotate(Vector3.forward * 90 * r);
    }
}
