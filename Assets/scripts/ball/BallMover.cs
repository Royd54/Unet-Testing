using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class BallMover : NetworkBehaviour
{
    [SerializeField] private GameObject mainball;

    [SyncVar] public Vector2 pos;
    // Start is called before the first frame update
    void Start()
    {
        mainball = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        pos = mainball.GetComponent<BallBehaviour>().GetPos();
        transform.position = pos;
    }

    [Command]
    public void CmdUpdatePosServer(Vector2 pos)
    {
        this.transform.position = pos;
        RpcUpdatePosClient(this.transform.position);
    }

    [ClientRpc]
    public void RpcUpdatePosClient(Vector2 pos)
    {
        this.transform.position = pos;
    }
}
