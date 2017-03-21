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
    public int last_x;

    void Start()
    {
        root = board.GetComponent<Root>();
    }

    void Update()
    {
        gameObject.transform.Translate(Vector3.down * Time.deltaTime * speed);

        if (transform.position.x > target_x)
        {
            transform.Translate(new Vector3(-1, 0, 0) * speed * Time.deltaTime);
            if (transform.position.x < target_x)
            {
                transform.position = new Vector3(target_x, transform.position.y, transform.position.z);
            }
        }
        if (transform.position.x < target_x)
        {
            transform.Translate(new Vector3(1, 0, 0) * speed * Time.deltaTime);
            if (transform.position.x > target_x)
            {
                transform.position = new Vector3(target_x, transform.position.y, transform.position.z);
            }
        }
    }

    public void Collision()
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
        }
        root.NextTurn();
        Destroy(gameObject);
    }

    public void Trigger()
    {
        target_x = last_x;
    }

    public void MakeMove(int x)
    {
        last_x = target_x;
        target_x += x;
    }
}
