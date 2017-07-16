using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[ExecuteInEditMode]
public class SetPlayerSettings : MonoBehaviour
{

    [Header("Setup")]
    public _SaveLoad saveLoad;
    public PlayerSetup playerSetup;

    [Header("Controls")]
    private _Players playersClass;

    void Update()
    {
        //Json saving
        if (saveLoad.saveData)
        {
            playersClass.amountofPlayers = playerSetup.amountOfPlayers;
            playersClass.amountOfBlocksEach = playerSetup.amountOfBlocksEach;

            playersClass.players.Clear();
            foreach (Player p in playerSetup.players)
                playersClass.players.Add(new _PlayerSettings(p.name, p.playerNum, p.inputMode));

            saveLoad.SaveToFile(JsonUtility.ToJson(playersClass, true)); //Executes the "Save" function to write the json formatted string "jsonWrite" to the "filename" file.
        }
        if (saveLoad.loadData)
        {
            playersClass = JsonUtility.FromJson<_Players>(saveLoad.ReadFromFile()); //Read the data from the Json save file and loads it into the inventory.    }

            playerSetup.amountOfPlayers = playersClass.amountofPlayers;
            playerSetup.amountOfBlocksEach = playersClass.amountOfBlocksEach;
            playerSetup.GeneratePlayers();

            foreach (_PlayerSettings ps in playersClass.players) {
                foreach (Player p in playerSetup.players) {
                    if (p.playerNum == ps.playerNum) {
                        p.name = ps.name;
                        p.inputMode = ps.inputMode;
                    }
                }
            }
            
        }
    }
}

[System.Serializable]
public class _Players
{
    public int amountofPlayers;
    public int amountOfBlocksEach;
    public List<_PlayerSettings> players;

}

[System.Serializable]
public class _PlayerSettings
{
    public string name;
    public int playerNum;
    public InputMode inputMode;

    public _PlayerSettings(string _name, int _playerNum, InputMode _inputMode) {
        name = _name;
        playerNum = _playerNum;
        inputMode = _inputMode;
    }

}