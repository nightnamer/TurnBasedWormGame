using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private NumberOfPlayers _players;
    private SpawnManager _spawnManager;

    private int players = 1;
    public void PlayGame ()
    {
        _players.players = players;
        //Go to next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
    }

    public void TwoPlayers()
    {
        players = 2;
        PlayGame();
    }
    
    public void ThreePlayers()
    {
        players = 3;
        PlayGame();
    }
    
    public void FourPlayers()
    {
        players = 4;
        PlayGame();
    }
    
}
