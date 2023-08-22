using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Tilemaps;

public class S_MapGenerator : MonoBehaviour
{
    public Vector3Int cellPosition;

    public GameObject mineral;

    [Header("MapStatus")]
    [SerializeField] Vector2Int mapSize;
    [SerializeField] float mineralXoffeset;
    [SerializeField] float mineralYoffeset;

    [Header("Tile")]
    [SerializeField] Tilemap tileMap;
    [SerializeField] Tile mineralTile;
    [SerializeField] Tile GroundTile;
    [SerializeField] Tile downTile;
    [SerializeField] Tile topTile;
    [SerializeField] Tile leftWallTile;
    [SerializeField] Tile rightWallTile;
    [SerializeField] Tile rightCornerTile;
    [SerializeField] Tile leftCornerTile;

    void Start()
    {
        tileMap = GetComponent<Tilemap>();
        FillBackground();
    }


    void FillBackground()
    {

        for (int i = -10; i < mapSize.x + 10; i++) //�ٱ�Ÿ���� �� �����ڸ��� ���� ������� �ʰ�, 10��ŭ ����
        {
            for (int j = -10; j < mapSize.y + 10; j++)
            {
                int rnd = Random.Range(0, 100);

                if (rnd >= 0 && rnd < 6)
                {
                    //tileMap.SetTile(new Vector3Int(i - mapSize.x / 2, j - mapSize.y / 2, 0), mineralTile);
                    var mine = Instantiate(mineral, tileMap.transform);
                    mine.transform.position = new Vector3(i - mapSize.x / 2 + mineralXoffeset, j - mapSize.y / 2 - mineralYoffeset, 0);
                }

                else
                    tileMap.SetTile(new Vector3Int(i - mapSize.x / 2, j - mapSize.y / 2, 0), GroundTile);
            }
        }
    }

    void FillWall() //�� Ÿ�ϰ� �ٱ� Ÿ���� ������ �κ�
    {
        if (tileMap.GetTile(cellPosition) == null) //����Ÿ���� null�̸�
        {
            /* for (int x = -1; x < 1; x++)
             {
                 for (int y = -1; y < 1; y++)
                 {
                     Vector3Int checkTilePos = new Vector3Int(cellPosition.x + x, cellPosition.y + y, 0);

                     if (x == 0 && y == 0) { continue; }

                     if (tileMap.GetTile(checkTilePos) != null)
                     {
                         if (tileMap.GetTile(new Vector3Int(cellPosition.x + x+1, cellPosition.y + y, 0)) == null)
                             tileMap.SetTile(new Vector3Int(cellPosition.x + x, cellPosition.y + y, 0), rightCornerTile);
                     }

                  }
              }*/
            if (tileMap.GetTile(new Vector3Int(cellPosition.x + 1, cellPosition.y, 0)) != null) //������ Ÿ�� üũ
                tileMap.SetTile(new Vector3Int(cellPosition.x + 1, cellPosition.y, 0), leftWallTile);
            if (tileMap.GetTile(new Vector3Int(cellPosition.x - 1, cellPosition.y, 0)) != null) //���� Ÿ�� üũ
                tileMap.SetTile(new Vector3Int(cellPosition.x - 1, cellPosition.y, 0), rightWallTile);
            if (tileMap.GetTile(new Vector3Int(cellPosition.x, cellPosition.y + 1, 0)) != null) //�� Ÿ�� üũ
                tileMap.SetTile(new Vector3Int(cellPosition.x, cellPosition.y + 1, 0), downTile);
            if (tileMap.GetTile(new Vector3Int(cellPosition.x, cellPosition.y - 1, 0)) != null) //�Ʒ� Ÿ�� üũ
                tileMap.SetTile(new Vector3Int(cellPosition.x, cellPosition.y - 1, 0), topTile);
        }
    }

    public void MakeDot(Vector3 Pos)
    {
        cellPosition = tileMap.WorldToCell(Pos);

        tileMap.SetTile(cellPosition, null);
        FillWall();
    }
}


