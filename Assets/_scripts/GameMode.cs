using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Assertions;
using UnityEngine.Events;

[System.Serializable]
public class GameModeIntEvent : UnityEvent<int>
{ }
public class GameMode : MonoBehaviour
{
    public static GameMode instance;
    public GameObject ballprefab;
    public int spawnBallForEveryBrickDestroy = 3;

    public int winSceneIndex;
    public int loseSceneIndex;

    private int ballsInPlay;
    private int starsInPlay;

    public GameModeIntEvent onBallsChanged;
    public GameModeIntEvent onStarsChanged;
    private void Awake()
    {

        if (!instance)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void Onballadded()
    {
        ballsInPlay++;
        onBallsChanged.Invoke(ballsInPlay);

    }

    public void OnBallremoved()
    {
        ballsInPlay--;
        onBallsChanged.Invoke(ballsInPlay);

        if (ballsInPlay <= 0)
        {
            SceneManager.LoadScene(loseSceneIndex);
        }

    }

    public void OnStarsadded()
    {
        starsInPlay++;
        onStarsChanged.Invoke(starsInPlay);
    }

    public void OnStarsremoved()
    {
        starsInPlay--;
        onStarsChanged.Invoke(starsInPlay);
        if (starsInPlay <= 0)
        {
            SceneManager.LoadScene(winSceneIndex);
        }
    }
}
