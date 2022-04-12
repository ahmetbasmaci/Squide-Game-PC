using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl1_PlayersMovement : MonoBehaviour
{
    [Header("Status")]
    public bool isRunning = false;

    float min_Speed = 3;
    float max_Speed = 9;
    float speed = 0;

    int minDeadRound = 1;
    int maxDeadRound = 10;
    int deadRound = 0;


    void Start()
    {
        SetRandomVaribals();
    }

    private void SetRandomVaribals()
    {
        deadRound = Random.Range(minDeadRound, maxDeadRound);

        speed = Random.Range(min_Speed, max_Speed);
    }

    void Update()
    {
       if (GetComponent<Lvl1_PlayersManager>().isDead || GetComponent<Lvl1_PlayersManager>().isWon) return;
        

        MovingControl();

    }

    
    private void MovingControl()
    {
        if (!EnemyGilrControl.instance.isLooking || deadRound == Lvl1_Manager.instance.currentRound)
        {
            Vector3 newPosition = Vector3.forward * speed * Time.deltaTime;
            transform.Translate(newPosition, Space.Self);

            isRunning = true;
        }
        else
            isRunning = false;

    }//MovingControl
}
