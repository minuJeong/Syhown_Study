using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName="Flow/GameTown")]
    public class GameTown : GameFlowBase
    {
        [SerializeField] public GameObject townPrefab;

        public IEnumerator Run()
        {
            GameObject instantiated = Instantiate(townPrefab);

            GameTownManager gtmComponent = instantiated.GetComponent<GameTownManager>();

            while (!gtmComponent.IsDone)
            {
                yield return null;
            }
            
            Destroy(instantiated);
        }
    }
}