using UnityEngine;
using System.Collections;

public class GenaratorBlocks : MonoBehaviour
{
    public GameObject[]             goBlocks;
    public int                      iLines;
    public bool                     bGenaratorBlocksAutomatic;
    public static GenaratorBlocks   genaratorBlocks;
    public int                      iNumberBlocksManual;

    void Awake()
    {
        genaratorBlocks = this;
    }

    // Use this for initialization
    void Start ()
    {
        if(bGenaratorBlocksAutomatic == false)
        {
            iLines = 0;
        }

        CreateGroupBlock();
	}

    private void CreateGroupBlock()
    {
        Bounds limitBlock = goBlocks[0].GetComponent<SpriteRenderer>().bounds;
        float fWidthBlock = limitBlock.size.x;
        float fHeightBlock = limitBlock.size.y;
        float fWidthScreen, fHeightScreen, fMultiplierWidth;
        int iColumns;

        InformationBlock(fWidthBlock, out fWidthScreen, out fHeightScreen, out iColumns, out fMultiplierWidth);
        ManagerGame.iNumberFullBlocks = iLines * iColumns;

        for (int i = 0; i < iLines; i++)
        {
            for(int j = 0; j < iColumns; j++)
            {
                GameObject blockRandom = goBlocks[Random.Range(0, goBlocks.Length)];
                GameObject blockInstantiate = (GameObject)Instantiate(blockRandom);
                blockInstantiate.transform.position = new Vector3(-(fWidthScreen * 0.5f) + (j * fWidthBlock * fMultiplierWidth), (fHeightScreen * 0.5f) - (i * fHeightBlock), 0);
                float fNewWidthBlock = blockInstantiate.transform.localScale.x * fMultiplierWidth;
                blockInstantiate.transform.localScale = new Vector3(fNewWidthBlock, blockInstantiate.transform.localScale.y, 1);
            }
        }
    }

    private void InformationBlock(float fWidthBlock, out float fWidthScreen, out float fHeightScreen, out int iColumns, out float fMultiplierWidth)
    {
        Camera cam = Camera.main;
        fWidthScreen = (cam.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)) - cam.ScreenToWorldPoint(new Vector3(0, 0, 0))).x;
        fHeightScreen = (cam.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)) - cam.ScreenToWorldPoint(new Vector3(0, 0, 0))).y;
        iColumns = (int)(fWidthScreen/fWidthBlock);
        fMultiplierWidth = fWidthScreen / (iColumns*fWidthBlock);
    }
}
