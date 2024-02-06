using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject BulletsPrefab;
    [SerializeField]
    private GameObject Bullets;
    public float power = 500f;
    public float delay = 0.1f;

    public int nb = 0;
    public float speed = 5f;

    float timer = 0f;

    public TextMeshProUGUI scoreText;

    void SpawnBullet()
    {
        Quaternion rotation = transform.rotation;
        Vector3 Scale = transform.parent.localScale;
        GameObject bullet = Instantiate(BulletsPrefab, transform.position, rotation);
        Vector3 localUp = bullet.transform.TransformDirection(Vector3.up);
        bullet.GetComponent<Rigidbody>().AddForce(localUp * power);
        bullet.transform.parent = Bullets.transform;
        bullet.transform.localScale = bullet.transform.localScale * Scale.x;
        nb++;
        scoreText.text = "Nombre de balle: " + nb;
    }

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            timer -= Time.deltaTime;

            if (timer <= 0f)
            {
                SpawnBullet();
                timer = delay;
            }
            Debug.Log(timer);
        }
        else
        {
            timer = 0f;
        }

        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        if (scrollInput > 0f)
        {
            power += 10f;
        }
        else if (scrollInput < 0f)
        {
            power -= 10f;
        }

        float verticalInput = Input.GetAxis("Vertical");

        if (verticalInput > 0f)
        {
            transform.Rotate(new Vector3(0f, 0f, -5f) * Time.deltaTime * speed);
        }
        else if (verticalInput < 0f)
        {
            transform.Rotate(new Vector3(0f, 0f, 5f) * Time.deltaTime * speed);
        }

        float horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput > 0f)
        {
            transform.Rotate(new Vector3(5f, 0f, 0f) * Time.deltaTime * speed);
        }
        else if (horizontalInput < 0f)
        {
            transform.Rotate(new Vector3(-5f, 0f, 0f) * Time.deltaTime * speed);
        }
    }

}