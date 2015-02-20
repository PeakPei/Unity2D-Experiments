using UnityEngine;

/// <summary>
///   Start or quit the game
/// </summary>
public class GameOverScript : MonoBehaviour {
    void OnGUI() {
        const int buttonWidth = 120;
        const int buttonHeight = 60;

        if (GUI.Button(new Rect(Screen.width / 2 - (buttonWidth / 2),
                                (1 * Screen.height / 3) - (buttonHeight / 2),
                                buttonWidth, buttonHeight), "Retry!")) {
            // reload the level
            Application.LoadLevel("Stage1");
        }

        if (GUI.Button(new Rect(Screen.width / 2 - (buttonWidth / 2),
                                (2 * Screen.height / 3) - (buttonHeight / 2),
                                buttonWidth, buttonHeight), "Back to menu!")) {
            // reload the menu
            Application.LoadLevel("Menu");
        }
    }
}