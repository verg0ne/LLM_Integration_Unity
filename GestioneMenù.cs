using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Metodo chiamato quando viene premuto il bottone "Play"
    public void PlayButtonPressed()
    {
        // Assicurati che la scena di gioco sia aggiunta alle Build Settings
        SceneManager.LoadScene("Level design"); // Sostituisci con il nome esatto della tua scena di gioco
    }

    // Metodo chiamato quando viene premuto il bottone "Exit"
    public void ExitButtonPressed()
    {
        // Funziona solo nella build finale, per terminare l'applicazione
        Application.Quit();

        // Se stai testando nell'Editor, questa riga ferma il play mode
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}