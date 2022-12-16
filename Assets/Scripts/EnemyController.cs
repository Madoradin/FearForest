using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [SerializeField] private GameObject crabMonster;
    [SerializeField] private GameObject pumpkinMonster;

    private Vector3 crabStart;
    private Vector3 crabEnd;

    private Vector3 pumpkinStart;
    private Vector3 pumpkinEnd;

    [SerializeField] private float monsterSpeed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {

        crabStart = crabMonster.transform.position;
        crabEnd = new Vector3(386, crabStart.y, 509);
        pumpkinStart = pumpkinMonster.transform.position;
        pumpkinEnd = new Vector3(538,pumpkinStart.y, 239);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (crabMonster != null)
        {
            crabMonster.transform.position = Vector3.Lerp(crabStart, crabEnd, Mathf.PingPong(Time.time * monsterSpeed, 1));
        }

        if (pumpkinMonster != null)
        {
            pumpkinMonster.transform.position = Vector3.Lerp(pumpkinStart, pumpkinEnd, Mathf.PingPong(Time.time * monsterSpeed, 1));
        }

    }
}
