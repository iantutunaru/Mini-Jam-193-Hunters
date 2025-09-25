using UnityEngine;
using TMPro;

public class StoryManager : MonoBehaviour
{
    public TMP_Text storyText;
    public TMP_Text pagenumText;

    [TextArea(3, 10)]
    public string[] storyPages;
    private int currentPageIndex = 0;



    void Start()
    {
        UpdateStoryText();
    }

    void UpdateStoryText()
    {
        if (currentPageIndex < storyPages.Length)
        {
            storyText.text = storyPages[currentPageIndex];
            pagenumText.text = $"{currentPageIndex+1} of 13";
        }
    }

    public void NextPage()
    {
        if (currentPageIndex < storyPages.Length - 1)
        {
            currentPageIndex++;
            UpdateStoryText();
        }
    }

    public void PreviousPage()
    {
        if (currentPageIndex > 0)
        {
            currentPageIndex--;
            UpdateStoryText();
        }
    }
}
