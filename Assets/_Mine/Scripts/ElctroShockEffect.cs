using UnityEngine;
using UnityEngine.UI;

public class ElectroShockEffect : MonoBehaviour
{
    public GameObject whiteScreenPanel;  // Reference to the white screen panel
    public float shockDuration = 0.2f;   // Duration of the shock effect
    public float blinkInterval = 0.05f;  // Interval between blinks
    private bool isFirstTime=true;
    private bool isLastTime=false;

    private Image panelImage;
    private bool isShocking = false;
    private float shockTimer = 0f;
    private float blinkTimer = 0f;
    public AudioSource startSound;
    public TaskManager taskManager;

    void Start()
    {
        panelImage = whiteScreenPanel.GetComponent<Image>();
    }

    void Update()
    {
        if (isShocking)
        {
            shockTimer -= Time.deltaTime;
            blinkTimer -= Time.deltaTime;

            if (shockTimer <= 0)
            {
                isShocking = false;
                panelImage.color = new Color(1, 1, 1, 0);  // Set to fully transparent
            }

            if (blinkTimer <= 0)
            {
                blinkTimer = blinkInterval;
                panelImage.color = panelImage.color.a == 1 ? new Color(1, 1, 1, 0) : new Color(1, 1, 1, 1);  // Toggle between opaque and transparent
            }
        }
    }

    public void TriggerShock()
    {
        if (isFirstTime)
        {
            isFirstTime = false;
            taskManager.StartNextTask();
        }
        if (isLastTime)
        {
            startSound.Play();
        }
        else
        {
            isShocking = true;
            shockTimer = shockDuration;
            blinkTimer = 0f;
            panelImage.color = new Color(1, 1, 1, 1);  // Start with opaque white
        }
        
    }

    public void ToggleisLastTime()
    {
        isLastTime = !isLastTime;
    }
}
