using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu]
    public class GameBattle : GameFlowBase
    {
        [SerializeField] public GameObject GameBattlePrefab;

        public IEnumerator Run()
        {
            GameObject instantiated = Instantiate(GameBattlePrefab);

            GameBattleManager gbmComponent = instantiated.GetComponent<GameBattleManager>();

            yield return gbmComponent.PrepareBattle();

            yield return gbmComponent.Battle();

            yield return gbmComponent.FinishBattle();

            Destroy(instantiated);
        }
    }
}