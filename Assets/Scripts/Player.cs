﻿using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int playerNumber;

    private UIPlayerText uiPlayerText;

    public bool HasController => Controller != null;
    public int PlayerNumber { get { return playerNumber; } }
    public Controller Controller { get; private set; }

    public Character CharacterPrefab { get; set; }

    private void Awake()
    {
        uiPlayerText = GetComponentInChildren<UIPlayerText>();
    }

    public void InitializePlayer(Controller controller)
    {
        Controller = controller;

        gameObject.name = string.Format("Player {0} - {1}", playerNumber, controller.gameObject.name);

        uiPlayerText.HandlePlayerInitialized();
    }

    public void SpawnCharacter()
    {
        var character = Instantiate(CharacterPrefab, Vector3.zero, Quaternion.identity);
        character.SetController(Controller);
    }
}
