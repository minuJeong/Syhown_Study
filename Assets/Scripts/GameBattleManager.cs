using System.Collections;
using UnityEngine;


enum Turn
{
    Me, Enemy,
}

public class GameBattleManager : MonoBehaviour
{
    [SerializeField] public GameObject MePrefab;
    [SerializeField] public GameObject EnemyPrefab;

    [SerializeField] public Transform MePosition;
    [SerializeField] public Transform EnemyPosition;

    private GameObject me;
    private GameObject enemy;

    public IEnumerator PrepareBattle()
    {
        me = Instantiate(MePrefab);
        me.transform.SetParent(MePosition);
        me.transform.localPosition = Vector3.zero;
        me.transform.localRotation = Quaternion.identity;
        me.GetComponent<Pawn>().Init();

        enemy = Instantiate(EnemyPrefab);
        enemy.transform.SetParent(EnemyPosition);
        enemy.transform.localPosition = Vector3.zero;
        enemy.transform.localRotation = Quaternion.identity;
        enemy.GetComponent<Pawn>().Init();

        yield return new WaitForSeconds(1.0f);
    }

    public IEnumerator Battle()
    {
        Pawn mePawn = me.GetComponent<Pawn>();
        Pawn enemyPawn = enemy.GetComponent<Pawn>();

        Turn battleTurn = Turn.Me;

        while (mePawn.Health > 0.0f && enemyPawn.Health > 0.0f)
        {
            switch (battleTurn)
            {
                case Turn.Me:
                    mePawn.Attack(enemyPawn);
                    battleTurn = Turn.Enemy;
                    break;

                case Turn.Enemy:
                    enemyPawn.Attack(mePawn);
                    battleTurn = Turn.Me;
                    break;
            }

            yield return new WaitForSeconds(2.0f);
        }
    }

    public IEnumerator FinishBattle()
    {
        Destroy(me);
        Destroy(enemy);

        yield break;
    }
}
