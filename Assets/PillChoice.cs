using UnityEngine;
using TMPro; // Важно для TMP
using UnityEngine.SceneManagement;

public class PillChoice : MonoBehaviour
{
    [Header("Что показать")]
    public GameObject imageToShow;
    public GameObject background;
    public TextMeshProUGUI text;

    [Header("UI Elements")]
    public TMP_Text hoverText; // TMP вместо обычного Text
    [TextArea]
    public string pillDescription;

    [Header("Что загрузить")]
    public string sceneToLoad = "menu";
    public float delayBeforeLoad = 5f;

    void OnMouseEnter()
    {
        if (hoverText != null)
        {
            hoverText.text = pillDescription;
            hoverText.enabled = true;
        }
    }

    void OnMouseExit()
    {
        if (hoverText != null)
        {
            hoverText.text = "";
            hoverText.enabled = false;
        }
    }

    void OnMouseDown()
    {
        if (imageToShow != null)
            imageToShow.SetActive(true);

        if (background != null)
            background.SetActive(false);
        
        if (text != null)
            text.enabled = false;

        if (hoverText != null)
            hoverText.enabled = false;

        Invoke("LoadNextScene", delayBeforeLoad);
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}