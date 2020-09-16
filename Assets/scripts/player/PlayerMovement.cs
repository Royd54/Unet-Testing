using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class PlayerMovement : NetworkBehaviour
{
    private float speed = 15f;
    [SerializeField] private GameObject ball;
    [SerializeField] private GameObject spawnPointBall;

    [SyncVar] private Vector2 pos;

    private void Update()
    {
        if (isLocalPlayer)
        {
            pos = transform.position;
            transform.position = pos;
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(-Vector2.right * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            }
            if (Input.GetKeyDown(KeyCode.Space) && !GameObject.Find("Ball"))
            {
                CmdBallSpawnerServer();
            }
        }
    }

    [Command]
    void CmdBallSpawnerServer()
    {
        GameObject ballToSpawn = Instantiate(ball, GameObject.Find("GameManager").GetComponent<Transform>().transform.position, Quaternion.identity) as GameObject;
        NetworkServer.Spawn(ballToSpawn);
    }


    [ClientRpc]
    void RpcBallSpawnerClient()
    {
        GameObject ballToSpawn = Instantiate(ball, GameObject.Find("GameManager").GetComponent<Transform>().transform.position, Quaternion.identity) as GameObject;
    }
}
