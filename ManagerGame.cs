using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManagerGame : MonoBehaviour
{
    public static ManagerGame   managerGame;
    public static int           iNumberFullBlocks;
    public static int           iNumberBlocksDestroyed;
    public Image                imgStars;
    public GameObject           goPanelNextLevel;
    public GameObject           goBall;

    void Awake()
    {
        managerGame = this;
    }

    void Start()
    {
        
    }

    void Update()
    {
        NextLevel();
    }

    public void NextLevelSceneLoad(int iScene)
    {
        iNumberBlocksDestroyed = 0;
        goPanelNextLevel.SetActive(false);
        SceneManager.LoadScene(iScene);
    }

    private void NextLevel()
    {
        if (GenaratorBlocks.genaratorBlocks.bGenaratorBlocksAutomatic == true && iNumberBlocksDestroyed == iNumberFullBlocks)
        {
            Destroy(goBall);
            Time.timeScale = 0;
            goPanelNextLevel.SetActive(true);
        }
        else if(GenaratorBlocks.genaratorBlocks.bGenaratorBlocksAutomatic == false && iNumberBlocksDestroyed == GenaratorBlocks.genaratorBlocks.iNumberBlocksManual)
        {
            Destroy(goBall);
            Time.timeScale = 0;
            goPanelNextLevel.SetActive(true);
        }
    }

    public void GameOver(GameObject goPanelGameOver)
    {
        if (GenaratorBlocks.genaratorBlocks.bGenaratorBlocksAutomatic)
        {
            print("NumberBlocksDestroyed = " + iNumberBlocksDestroyed);
            print("NumberFullBlocks = " + iNumberFullBlocks);
            print("Value fillAmount = " + (float)imgStars.fillAmount);
            imgStars.fillAmount = (float)iNumberBlocksDestroyed / (float)iNumberFullBlocks;
            //txtPoints.text = "Points: \n" + iPonts.ToString();
            Debug.Log("Game over");
            goPanelGameOver.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            print("NumberBlocksDestroyed = " + iNumberBlocksDestroyed);
            print("NumberFullBlocksManual = " + GenaratorBlocks.genaratorBlocks.iNumberBlocksManual);
            print("Value fillAmount = " + (float)imgStars.fillAmount);
            imgStars.fillAmount = (float)iNumberBlocksDestroyed / (float)GenaratorBlocks.genaratorBlocks.iNumberBlocksManual;
            //txtPoints.text = "Points: \n" + iPonts.ToString();
            Debug.Log("Game over");
            goPanelGameOver.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
