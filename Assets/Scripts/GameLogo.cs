using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu]
    public class GameLogo : GameFlowBase
    {
        public float LogoTime = 2.0f;
        public GameObject LogoCanvas;

        public IEnumerator Run()
        {
            var logoCanvas = Instantiate(LogoCanvas);

            yield return new WaitForSeconds(LogoTime);

            Destroy(logoCanvas);
        }
    }
}
