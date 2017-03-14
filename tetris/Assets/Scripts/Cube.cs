using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public int target_x;
    public int target_y;
    public float speed;

    public Group master;

    void Update()
    {
        if (master != null)
            return;
        if (transform.position.x > target_x)
        {
            transform.Translate(new Vector3(-1, 0 ,0) * speed * Time.deltaTime);
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
        if (transform.position.y > target_y)
        {
            transform.Translate(new Vector3(0, -1, 0) * speed * Time.deltaTime);
            if (transform.position.y < target_y)
            {
                transform.position = new Vector3(transform.position.x, target_y, transform.position.z);
            }
        }
        if (transform.position.y < target_y)
        {
            transform.Translate(new Vector3(0, 1, 0) * speed * Time.deltaTime);
            if (transform.position.y > target_y)
            {
                transform.position = new Vector3(transform.position.x, target_y, transform.position.z);
            }
        }
    }

    void OnCollisionEnter(Collision c)
    {
        Debug.Log("Hello");
        if (master != null)
            master.Collision();
    }
}
