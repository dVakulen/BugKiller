using UnityEngine;

public class DeathMenuScript : MonoBehaviour
{
    public GUITexture image;
    public GameObject buttonTexture;
    public string levelName = "FirstIterationDemo";

    void OnGUI()
    {
        ShowDeathMenu();
    }

    void ShowDeathMenu()
    {
        GUILayout.BeginArea(new Rect((Screen.width * 0.5f - 50), (Screen.height * 0.5f + 65), 100, 200));
        if (GUILayout.Button("Restart"))
        {
            //load needed level
            Application.LoadLevel(levelName);
        }
        if (GUILayout.Button("Main Menu"))
        {
            //MainMenu
            Application.LoadLevel("MainManu");
        }
        GUILayout.EndArea();
    }
}
