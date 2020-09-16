using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallBehaviour : MonoBehaviour
{
    private float speed = 5f;

    private void Start()
    {
        Physics2D.IgnoreLayerCollision(0, 1);
        if (Mathf.Round(Random.Range(0, 1)) > 0)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = -Vector2.up * speed;
        }
    }

    private void Update()
    {
        gameObject.GetComponent<BallMover>().CmdUpdatePosServer(GetPos());
    }

    float HitFactor(Vector2 BallPos, Vector2 RacketPos, float RacketHeight)
    {
        return (BallPos.x - RacketPos.x) / RacketHeight;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(collision.transform.position.y > transform.position.y)
            {
                float x = HitFactor(transform.position, collision.transform.position, collision.collider.bounds.size.x);
                Vector2 Dir = new Vector2(x, -1).normalized;
                GetComponent<Rigidbody2D>().velocity = Dir * speed;
                speed += 1;
            }
            if (collision.transform.position.y < transform.position.y)
            {
                float x = HitFactor(transform.position, collision.transform.position, collision.collider.bounds.size.x);
                Vector2 Dir = new Vector2(x, 1).normalized;
                GetComponent<Rigidbody2D>().velocity = Dir * speed;
                speed += 1;
            }
        }
    }

    public Vector2 GetPos()
    {
        return transform.position;
    }

}
