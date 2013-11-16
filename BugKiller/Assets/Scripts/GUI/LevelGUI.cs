using UnityEngine;

public class LevelGUI : MonoBehaviour
{

    Player player = Player.Instance;

    void OnGUI()
    {
        if (player.IsAlive)
        {
            GUI.Label(new Rect(10, 10, 400, 120), "HP: " + player.Health);
        }
        else
        {
            GUI.Label(new Rect(10, 10, 400, 120), "game over");
        }
    }
}
