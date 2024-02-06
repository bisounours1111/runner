using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour
{
    public GameObject wallPrefab;
    public int nbPosition = 0;
    public int ecart = 0;
    public Vector3 position;
    public GameObject Bullets;

    void Start()
    {

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Reset();
        }

        if (Input.GetMouseButton(1))
        {
            SpawnWall();
        }
    }

    void SpawnWall()
    {
        Vector3 posWall = new Vector3(position.x + ecart * nbPosition, position.y, position.z);
        GameObject wall = Instantiate(wallPrefab, posWall, Quaternion.identity);
        wall.transform.parent = transform;
        nbPosition++;
    }

    void Reset()
    {
        nbPosition = 0;

        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        foreach (Transform child in Bullets.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
}
