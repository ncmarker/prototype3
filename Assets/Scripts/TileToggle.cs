using UnityEngine;
using UnityEngine.Tilemaps;

public class TileToggler : MonoBehaviour
{
    [SerializeField] private Tilemap wallTilemap; 
    [SerializeField] private Tilemap mazeTilemap; 
    [SerializeField] private TilemapCollider2D wallCollider; 

    [SerializeField] private Tile wallTile; 
    [SerializeField] private Tile mazeTile; 

    private Vector3Int wallPos = Vector3Int.zero;
    private Vector3Int mazePos = Vector3Int.zero;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            wallPos = new Vector3Int(-1,-4,0);
            mazePos = new Vector3Int(0,-5,0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            wallPos = new Vector3Int(2,-1,0);
            mazePos = new Vector3Int(-3,1,0);
        }

        MapChange(wallPos, mazePos);
    }

    void MapChange(Vector3Int wallPos, Vector3Int mazePos) {
        // add path where wall was
        if (wallTilemap.GetTile(wallPos) == wallTile)
        {
            wallTilemap.SetTile(wallPos, null); 
            mazeTilemap.SetTile(wallPos, mazeTile); 
        }
        // add wall where path was
        if (mazeTilemap.GetTile(mazePos) == mazeTile)
        {
            mazeTilemap.SetTile(mazePos, null); 
            wallTilemap.SetTile(mazePos, wallTile); 
        }
    }
}
