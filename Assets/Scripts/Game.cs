using System.Collections;
using UnityEngine;


namespace Assets.Scripts
{
    public class Game : MonoBehaviour
    {
        [SerializeField] public GameLogo _GameLogoFlow;
        [SerializeField] public GameTitle _GameTitleFlow;
        [SerializeField] public GameTown _GameTownFlow;
        [SerializeField] public GameBattle _GameBattleFlow;
        [SerializeField] public GameResult _GameResultFlow;

        private void Start()
        {
            StartCoroutine(GameLoop());
        }

        IEnumerator GameLoop()
        {
            yield return _GameLogoFlow.Run();

            yield return _GameTitleFlow.Run();

            while (true)
            {
                yield return _GameTownFlow.Run();

                yield return _GameBattleFlow.Run();

                yield return _GameResultFlow.Run();
            }
        }
    }
}