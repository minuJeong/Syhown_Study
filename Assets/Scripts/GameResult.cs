using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu]
    public class GameResult : GameFlowBase
    {
        public IEnumerator Run()
        {
            Debug.Log("결과 화면!");

            yield return new WaitForSeconds(2.0f);
        }
    }
}