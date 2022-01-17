using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class backpack : MonoBehaviour
{
    // 10 predetermined spots for backpack items
    private float[] Xspots = {-6.606903f, -3.289886f, 0, 3.289886f, 6.606903f};
    private float topRowY = 1.612106f, bottomRowY = -1.612106f;

    // order: newspaper, coins, shirtNet, catchNet, stick, fabrics, coralSnake, purpleSnake, blackTellowSnake, mouse, waterPump

    private bool[] itemInBag = {staticVariables.newspaper, staticVariables.coins, staticVariables.shirtNet, staticVariables.catchNet,
                                staticVariables.stick, staticVariables.fabrics, staticVariables.coralSnake, staticVariables.purpleSnake,
                                staticVariables.blackTellowSnake, staticVariables.mouse, staticVariables.waterPump};

    public GameObject[] cards;

    private int cardCount = 0;

    public Texture2D defaultCursor;

    public GameObject insideNewspaper;
    public Button backButton;
    public Text backButtonText;

    private void Start()
    {
        Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.ForceSoftware);

        for (int i = 0; i < cards.Length; i++)
        {
            if (itemInBag[i] == true)
            {

                float posX = Xspots[cardCount % 5];

                cardCount++;

                float posY;
                if (cardCount < 5)
                    posY = topRowY;
                else
                    posY = bottomRowY;

                cards[i].GetComponent<Transform>().position = new Vector3(posX, posY, 0);
            }
        }

    }
    public void useCoins()
    {
        if (SceneManager.GetActiveScene().name == "PopFashion")
        {
            // I did this in playerControls: 

            // walk to cashier
            // coins go from bad to big on screen then shrink into her
            // shirt net gets collected
        }
        else
        {
            // player says "I don't need to use this here"
            staticVariables.pressedUseUselessObj = true; // just mark that it was pressed and the next scene will deal with it
            SceneManager.LoadScene(staticVariables.runningScene);
        }
    }

    public void readNewspaper()
    {
        // make newspaper take up the screen
        insideNewspaper.GetComponent<SpriteRenderer>().enabled = true;

        backButton.enabled = true;
        backButtonText.enabled = true;

        staticVariables.hasReadNewspaper = true;
    }

    public void putNewpaperAway()
    {
        // make newspaper disappear from screen
        insideNewspaper.GetComponent<SpriteRenderer>().enabled = false;

        backButton.enabled = false;
        backButtonText.enabled = false;
    }
}
