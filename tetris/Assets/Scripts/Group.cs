using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Group : MonoBehaviour
{
    public float speed;
    public GameObject board;

    void Update()
    {
        gameObject.transform.Translate(Vector3.down * Time.deltaTime * speed);
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
            cubes[i].speed = 10;
            cubes[i].master = null;
        }
        Destroy(gameObject);
    }
}
