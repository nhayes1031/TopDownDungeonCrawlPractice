using System.Linq;
using UnityEngine;

public class PlayerManager : MonoSingleton<PlayerManager>
{
    private Player[] players;

    private void Awake()
    {
        players = FindObjectsOfType<Player>();
    }

    public void AddPlayerToGame(Controller controller)
    {
        var firstNonActivePlayer = players
            .OrderBy(t => t.PlayerNumber)
            .FirstOrDefault(t => t.HasController == false);
        firstNonActivePlayer.InitializePlayer(controller);
    }

    public void SpawnPlayerCharacters()
    {
        foreach (var player in players)
        {
            if (player.HasController && player.CharacterPrefab != null)
            {
                player.SpawnCharacter();
            }
        }
    }
}
