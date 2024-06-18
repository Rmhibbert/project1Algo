using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Lets us reference this instance from any other script.
    public static GameManager Instance;
    

    // A number tracking how many sheep we've saved.
    // [HideInInspector] tells Unity not to show this variable in the editor, even though it is public.
    [HideInInspector]
    public int sheepSaved;

    // A number tracking how many sheep have been dropped.
    [HideInInspector]
    public int sheepDropped;

    // A number specifying how many sheep can be dropped before we lose the game.
    public int sheepDroppedBeforeGameOver;

    // A reference to the sheep manager.
    public SheepSpawner sheepSpawner;

    public void Awake()
    {
        Instance = this;
    }

    public void SaveSheep()
    {
        sheepSaved++;
        UIManager.Instance.UpdateScoreUI();

    }

    private void GameOver()
    {
        GameObject[] sheepObjects = GameObject.FindGameObjectsWithTag("Sheep");
        foreach (var sheep in sheepObjects)
        {
            Destroy(sheep);
        }

        sheepSpawner.enabled = false;
        SceneManager.LoadScene("Title");
    }

    public void DroppedSheep()
    {
        sheepDropped++;
        UIManager.Instance.UpdateLivesUI();

        if (sheepDropped >= sheepDroppedBeforeGameOver)
        {
            GameOver();
        }

    }

}
