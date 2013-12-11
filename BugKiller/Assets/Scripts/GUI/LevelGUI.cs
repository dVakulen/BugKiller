using UnityEngine;

public class LevelGUI : MonoBehaviour
{
    Player player = Player.Instance;

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 400, 120), "HP: " + player.Health);
    }
}
