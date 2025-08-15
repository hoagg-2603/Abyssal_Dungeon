using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyAi : MonoBehaviour
{
    [SerializeField] private float roamingChangeDirfFloat = 2f;
    private enum State
    {
        Roaming
    }

    private State state;
    private EnemyPathFinding enemyPathFinding;

    private void Awake()
    {
        enemyPathFinding = GetComponent<EnemyPathFinding>();
        state = State.Roaming;
    }

    private void Start()
    {
        StartCoroutine(RoamingRoutine());
    }

    private IEnumerator RoamingRoutine()
    {
        while (state == State.Roaming)
        {
            Vector2 roamPos = GetRoamingPosition();
            enemyPathFinding.MoveTo(roamPos);
            yield return new WaitForSeconds(roamingChangeDirfFloat);
        }
    }

    private Vector2 GetRoamingPosition()
    {
        return new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }
}
