using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro; // <<<<<===== 記住！因為要控制 TextMeshPro，所以一定要加上這一行！

public class GameManager : MonoBehaviour
{
    // --- 舊有的變數 ---
    public SpriteRenderer characterSprite;
    public Button nextLevelButton;
    public Button checkButton;
    public Button crossButton;
    public Sprite[] levelSprites;
    private int currentLevel = 0;

    // --- 【新增】的變數 ---
    public TextMeshProUGUI questionTextUI;     // 用來顯示問題的 UI 文字物件
    public TextMeshProUGUI wrongAnswerTextUI;    // 用來顯示答錯訊息的 UI 文字物件

    [TextArea(3, 5)] // 這個屬性可以讓你在 Inspector 中把輸入框變大，方便打字
    public string[] questionTexts;            // 存放每一關問題的陣列

    [TextArea(3, 5)]
    public string[] wrongAnswerTexts;         // 存放每一關答錯訊息的陣列


    void Start()
    {
        // 初始化場景
        UpdateLevelContent(); // 將初始化邏輯打包成一個函式
        characterSprite.color = Color.black;
        nextLevelButton.gameObject.SetActive(false);
        wrongAnswerTextUI.gameObject.SetActive(false);
    }

    public void OnCheckClicked()
    {
        characterSprite.color = Color.white;
        nextLevelButton.gameObject.SetActive(true);
        wrongAnswerTextUI.gameObject.SetActive(false);
        checkButton.interactable = false;
        crossButton.interactable = false;
    }

    public void OnCrossClicked()
    {
        // 【修改】現在我們會根據當前關卡來設定文字
        wrongAnswerTextUI.text = wrongAnswerTexts[currentLevel];
        wrongAnswerTextUI.gameObject.SetActive(true);
    }

    public void LoadNextLevel()
    {
        currentLevel++;
        if (currentLevel < levelSprites.Length)
        {
            // 載入下一關並重置狀態
            UpdateLevelContent(); // 呼叫函式來更新所有內容
            characterSprite.color = Color.black;
            nextLevelButton.gameObject.SetActive(false);
            wrongAnswerTextUI.gameObject.SetActive(false);
            checkButton.interactable = true;
            crossButton.interactable = true;
        }
        else
        {
            SceneManager.LoadScene("EndScene");
        }
    }

    // --- 【新增】的函式 ---
    // 這個函式負責根據 currentLevel 更新所有關卡內容
    void UpdateLevelContent()
    {
        characterSprite.sprite = levelSprites[currentLevel];
        questionTextUI.text = questionTexts[currentLevel];
    }
}