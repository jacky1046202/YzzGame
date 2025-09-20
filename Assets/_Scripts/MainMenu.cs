using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigationManager : MonoBehaviour
{
     public void StartGame()
    {
        // "GameScene" 是您下一個主要遊戲場景的名稱
        SceneManager.LoadScene("GameScene");
    }

    // 這是離開遊戲的函式
    public void QuitGame()
    {
        // 在 Unity 編輯器中，這行程式碼不會有作用
        // 所以我們加上一行日誌訊息，方便在編輯器中測試
        Debug.Log("Quit button pressed!");

        // 這行程式碼只在遊戲被建置 (Build) 成執行檔後才會真正關閉遊戲
        Application.Quit();
    }
}