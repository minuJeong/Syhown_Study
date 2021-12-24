using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu]
    public class GameTitle : GameFlowBase
    {
        [SerializeField] public GameObject TitleCanvas;

        public IEnumerator Run()
        {
            var titleCanvas = Instantiate(TitleCanvas);

            while (!Input.GetMouseButtonUp(0))
            {
                yield return null;
            }

            Destroy(titleCanvas);
        }
    }
}