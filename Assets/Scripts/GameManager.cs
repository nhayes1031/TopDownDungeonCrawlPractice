using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleton<GameManager>
{
    public void Begin()
    {
        StartCoroutine(BeginGame());
    }

    private IEnumerator BeginGame()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
        while (operation.isDone == false)
            yield return null;

        Debug.Log("Game Beginning");

        PlayerManager.Instance.SpawnPlayerCharacters();
    }
}
