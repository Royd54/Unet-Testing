using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine;

public class DestroyBall : NetworkBehaviour
{
    [SerializeField] private GameObject UIpanel;
    [SerializeField] private GameObject PlayerScores;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Destroy(collision.gameObject);
            //GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovement>().CmdhutsSpawner();
            if (gameObject.tag == "Goal")
            {
                CmdScoreUpdatePlayer2();
            }
            else { CmdScoreUpdatePlayer1(); }
            //UIpanel.GetComponent<Text>().text = PlayerScores.GetComponent<PlayerScores>().scorePlayer1 + " - " + PlayerScores.GetComponent<PlayerScores>().scorePlayer2;
        }
    }

    [Command]
    void CmdScoreUpdatePlayer1()
    {
        PlayerScores.GetComponent<PlayerScores>().scorePlayer1++;
        RpcSetScores(PlayerScores.GetComponent<PlayerScores>().scorePlayer1, PlayerScores.GetComponent<PlayerScores>().scorePlayer2);
    }

    [Command]
    void CmdScoreUpdatePlayer2()
    {
        PlayerScores.GetComponent<PlayerScores>().scorePlayer2++;
        RpcSetScores(PlayerScores.GetComponent<PlayerScores>().scorePlayer1, PlayerScores.GetComponent<PlayerScores>().scorePlayer2);
    }

    [ClientRpc]
    void RpcSetScores(int score1, int score2)
    {
        UIpanel.GetComponent<Text>().text = score1 + " - " + score2;
    }

}
