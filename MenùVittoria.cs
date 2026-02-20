using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    // Metodo per il pulsante RESTART: ricarica la scena di gioco
    public void RestartGame()
    {
        SceneManager.LoadScene("Level design"); // Sostituisci con il nome esatto della tua scena di gioco
    }

    // Metodo per il pulsante EXIT: chiude l'applicazione
    public void ExitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
