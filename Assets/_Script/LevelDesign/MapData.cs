using UnityEngine;
using UnityEngine.Rendering;

[CreateAssetMenu(fileName ="newMapData", menuName = "MapData")]
public class MapData : ScriptableObject
{
    public SerializedDictionary<Vector2Int, Tile?> Tiles = new();


    public RectInt Bounds;//custom inspector avec bouton "edit" qui ouvre une window comme pour les couleurs



    public void GenerateTilingWalls()
    {
        for(int i = Bounds.xMin;i <= Bounds.xMax; i++)
        {
            for (int j = Bounds.yMin; j <= Bounds.yMax; j++)
            {
                if(Mathf.Abs(i-Bounds.x)%2==1 && Mathf.Abs(j-Bounds.y)%2 ==1) Tiles[new Vector2Int(i,j)] = Tile.SolidBlock;
            }
        }
    }
}
