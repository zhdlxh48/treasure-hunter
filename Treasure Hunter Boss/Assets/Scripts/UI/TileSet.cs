using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileSet : MonoBehaviour
{
    public bool[,] tileXY;
    public int tileX = 3, tileY = 6;
    public GameObject endButton;
    public GameObject relicParent;
    public GameObject makeCanvas;
    public Effect effect;
    public GameObject makeRelic;
    public GameObject findText;
    public GameObject adventureText;

    EffectData[] data;
    Queue<string> relicNameQueue = new Queue<string>();

    private void Awake()
    {
        tileXY = new bool[tileX, tileY];
        endButton.SetActive(false);
        makeCanvas.SetActive(false);
        data = effect.dataArray;
    }

    public bool ChackTile()
    {
        int count = 0;
        for(int x = 0; x < tileX; x++)
        {
            for(int y = 0; y < tileY; y++)
            {
                if(tileXY[x,y] == true)
                {
                    count++;
                }
            }
        }
        if(count == tileX * tileY)
        {
            endButton.SetActive(true);
            return true;
        }
        else
        {
            endButton.SetActive(false);
            return false;
        }
    }

    public void DebugTile()
    {
        for (int x = 0; x < tileX; x++)
        {
            for (int y = 0; y < tileY; y++)
            {
                //Debug.Log("x = "+x+"  y = "+y+"   "+tileXY[x,y]);
            }
        }
    }

    public void OnEndButton()
    {
        int childCount = relicParent.transform.childCount;
        int relicCount = 0;
        int myRelicNum = 0;
        for (int i = 0; i < childCount; i++)
        {
            relicNameQueue.Enqueue(relicParent.transform.GetChild(i).GetComponent<Image>().sprite.name);
            Destroy(relicParent.transform.GetChild(i).gameObject);
        }

        for (int j = 0; j < data.Length; j++)
        {
            relicCount = 0;
            for (int i = 0; i < 4; i++)
            {
                string relicName = relicNameQueue.Dequeue();

                if (relicName == data[j].Firstrelicname || "" == data[j].Firstrelicname)
                {
                    relicCount++;
                }
                else if (relicName == data[j].Secondrelicname || "" == data[j].Secondrelicname)
                {
                    relicCount++;
                }
                else if (relicName == data[j].Thirdrelicname || "" == data[j].Thirdrelicname)
                {
                    relicCount++;
                }
                else if (relicName == data[j].Fourthrelicname || "" == data[j].Fourthrelicname)
                {
                    relicCount++;
                }
            }
            if (relicCount == 4)
            {
                myRelicNum = j;
                break;
            }
        }

        if (childCount == relicCount)
        {
            Sprite mySprite = Resources.Load<Sprite>("Images/Items/" + data[myRelicNum].Name);
            makeRelic.GetComponent<Image>().sprite = mySprite;
            findText.GetComponent<Text>().text =  data[myRelicNum].Findeffecttext;
            adventureText.GetComponent<Text>().text = data[myRelicNum].Adventureeffecttext;
        }

        for (int x = 0; x < tileX; x++)
        {
            for (int y = 0; y < tileY; y++)
            {
                tileXY[x, y] = false;
            }
        }
        endButton.SetActive(false);
        makeCanvas.SetActive(true);
    }
    public void OffEndButton()
    {
        makeCanvas.SetActive(false);
    }
}
