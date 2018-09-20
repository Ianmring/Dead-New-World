using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using D3D;

public class BoardManager : MonoBehaviour {

    public Tile tilePrefab;
    Tile[,] tileContainer;
    int plotWidth; //rank of tileContainer
    int plotLength; //length of tileContainer

	// Use this for initialization
	public void InitializeBoard ()
    {
        plotWidth = 25;
        plotLength = 25;
        tileContainer = new Tile[plotWidth, plotLength];

        for (int r = 0; r < plotWidth; r++)
        {
            for (int l = 0; l < plotLength; l++)
            { 
                Tile newTile = Instantiate(tilePrefab, new Vector3(r * (tilePrefab.GetComponent<Renderer>().bounds.size.x * 1.05f), 0, 
                    l * (tilePrefab.GetComponent<Renderer>().bounds.size.z * 1.05f)), Quaternion.identity, transform);
                tileContainer[r, l] = newTile;
                tileContainer[r, l].xPos = r;
                tileContainer[r, l].yPos = l;
                tileContainer[r, l].isActive = true;
                tileContainer[r, l].isOccupied = false;
                tileContainer[r, l].name = "Tile " + r + " " + l;
            }
        }
    }

    public Tile GetTileAtWorldCoord(Vector3 coord)
    {
        int xPos = Mathf.RoundToInt(coord.x / (tilePrefab.GetComponent<Renderer>().bounds.size.x * 1.05f));
        int yPos = Mathf.RoundToInt(coord.y / (tilePrefab.GetComponent<Renderer>().bounds.size.z * 1.05f));

        return GetTileAt(xPos, yPos);
    }

    public Tile GetTileAt(int x, int y)
    {
        return tileContainer[x, y];
    }

    //METHOD TO BE IMPLEMENTED: Scan board after tiles are created
    //METHOD TO BE IMPLEMENTED: Set node tag on tile and scan bounds of tiles to reconfigure pathfinding
}
