using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alien_control : MonoBehaviour
{
    public float speed = 10;
    public float value = 20;
    public bool left = true;
    public bool hit = false;

    public GameObject bullet;
    public Transform barrel;

    private float timer = 0.0f;
    private float shoot;
    SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        shoot = Random.Range(1, 20);

        float clr = Random.Range(0, 10);

        if (clr > 8.5f)
        {
            sprite.color = Color.red;
            value *= 3;
        }
        else if (clr > 7)
        {
            sprite.color = Color.blue;
            value *= 2;
        }
        else if (clr > 5)
        {
            sprite.color = Color.green;
            value *= 1.5f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (left)
        {
            if (transform.position.x < 20)
            {
                transform.Translate(Vector3.right * Time.deltaTime * speed);
            }
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - 3, transform.position.z);
                left = !left;
            }
        }
        else
        {
            if (transform.position.x > -20)
            {
                transform.Translate(Vector3.left * Time.deltaTime * speed);
            }
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - 3, transform.position.z);
                left = !left;
            }
        }

        if (hit)
        {
            Destroy(gameObject);
        }

        if (timer > shoot)
        {
            Instantiate(bullet, barrel.position, Quaternion.identity);
            timer = 0f;
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "barrier")
        {
            col.gameObject.GetComponent<barrier_control>().hit = true;
            Destroy(gameObject);
        }
    }
}
