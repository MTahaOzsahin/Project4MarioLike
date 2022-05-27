using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project4.Concretes.Managers
{
    public class GameManager : MonoBehaviour
    {
        float delayLevelTime = 1f;
        [SerializeField] int score;

        public int Score { get; set; }
        
        public static GameManager Instance { get; private set; }

        public event System.Action<int> OnScoreChanged;
        public event System.Action<bool> OnSceneChanged;
        private void Awake()
        {
            SingeltonThisGameObject();
        }
        void SingeltonThisGameObject()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
        public void IncreaseScore(int score = 0)
        {
            this.Score += score;
            OnScoreChanged.Invoke(this.Score);
        }

        public void ExitGame()
        {
            Application.Quit();
        }
        public void LoadScene(int LevelIndex = 0)
        {
            StartCoroutine(LoadSceneAsync(LevelIndex));
        }
        IEnumerator LoadSceneAsync(int LevelIndex)
        {
            yield return new WaitForSeconds(delayLevelTime);

            int buildsIndex = SceneManager.GetActiveScene().buildIndex;

            yield return SceneManager.UnloadSceneAsync(buildsIndex);

            SceneManager.LoadSceneAsync(buildsIndex + LevelIndex, LoadSceneMode.Additive).completed += (AsyncOperation obj) =>
             {
                 SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(buildsIndex + LevelIndex));
             };
            OnSceneChanged?.Invoke(false);
        }
        public void LoadMenuAndUi(float delayLoadingTime)
        {
            StartCoroutine(LoadMenuAndUiAsync(delayLoadingTime));
        }
        IEnumerator LoadMenuAndUiAsync(float delayLoadingTime)
        {
            yield return new WaitForSeconds(delayLoadingTime);
            yield return SceneManager.LoadSceneAsync("Level 0");
            yield return SceneManager.LoadSceneAsync("UiScene", LoadSceneMode.Additive);

            OnSceneChanged?.Invoke(true);
        }





    }
}
