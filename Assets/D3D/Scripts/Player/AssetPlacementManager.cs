using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using D3D;


public class AssetPlacementManager : MonoBehaviour
{
    public enum InputMode { selectMode, buildMode, modifyMode, tileMode }

    Vector3 mouseToWorld;
    Int3 startNodePos;
    Int3 endNodePos;
    InputMode currentInputMode;
    List<GraphNode> selectedNodesPos;
    GraphNode startNode;
    GraphNode endNode;

    Ray camRay;
    RaycastHit hitInfo;
    //Tile selectedTile;
    //AttachNode selectedNode;
    //PlaceableAsset currentObject;

    public bool canPlaceObject;

    public void InitializeManager()
    {
        currentInputMode = InputMode.selectMode;
        selectedNodesPos = new List<GraphNode>();
    }

    public void SelectionHandler()
    {
        //MouseButtonDown will grab a node and highlight it
        if (Input.GetMouseButtonDown(0))
        {
            selectedNodesPos.Clear();
            camRay = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
            if (Physics.Raycast(camRay, out hitInfo)) mouseToWorld = hitInfo.point;
            startNode = AstarPath.active.GetNearest(mouseToWorld).node;
            startNodePos = AstarPath.active.GetNearest(mouseToWorld).node.position;
            //Debug.Log("Start " + startNodePos.ToString());
        }
        else if (Input.GetMouseButton(0))
        {
            camRay = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
            if (Physics.Raycast(camRay, out hitInfo)) mouseToWorld = hitInfo.point;
            endNode = AstarPath.active.GetNearest(mouseToWorld).node;
            endNodePos = AstarPath.active.GetNearest(mouseToWorld).node.position;
            CreateSelectionFromNodes();
            //Debug.Log("End " + endNodePos.ToString());
        }
        else if (Input.GetMouseButtonUp(0))
        {
            //Debug.Log(selectedNodesPos.Count);
        }
        
        /*switch(currentInputMode)
        {
            case InputMode.selectMode:
                GetBuildingUnderCursor();
                break;

            case InputMode.buildMode:
                if (CheckIfObjectSelected())
                {
                    GetBuildingUnderCursor();
                    MoveObjectToCursor();
                    canPlaceObject = CheckBuildingPlacement();
                    PlaceBuilding();
                }
                break;

            case InputMode.modifyMode:
                if (CheckIfObjectSelected())
                {
                    GetBuildingUnderCursor();
                    MoveModToBuilding();
                    //canPlaceObject = CheckModPlacement();
                    AttachMod();
                }
                break;

            case InputMode.tileMode:
                break;
        }*/
        
    }

    void CreateSelectionFromNodes()
    {
        var gg = AstarPath.active.data.gridGraph;

        selectedNodesPos = gg.GetNodesInRegion(new IntRect(Mathf.Abs(startNodePos.x / gg.width), 
            Mathf.Abs(startNodePos.z / gg.depth),
            Mathf.Abs(endNodePos.x / gg.width),
            Mathf.Abs(endNodePos.z / gg.depth)));

        //selectedNodesPos = gg.GetNodesInRegion(new Bounds(((Vector3)startNodePos + (Vector3)endNodePos) / 2,
        //new Vector3(Mathf.Abs(endNodePos.x - startNodePos.x) / gg.width, 1f, Mathf.Abs(endNodePos.z - startNodePos.z) / gg.width)));
        //new Vector3(Mathf.Abs(endNodePos.x - startNodePos.x) / gg.depth, 1f, Mathf.Abs(endNodePos.z - startNodePos.z) / gg.depth)));

        /*for (int z = 0; z < gg.depth; z++)
        {
            for (int x = startNode.NodeIndex; x < endNode.NodeIndex; x++)
            {
                selectedNodesPos.Add(gg.nodes[z*endNode.NodeIndex + x].position);
                Debug.Log(x + " " + " added!");
            }
        }*/
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        if(selectedNodesPos != null) if(selectedNodesPos.Count > 0)
        {
            Debug.Log(selectedNodesPos.Count + " nodes selected");
            foreach (GraphNode g in selectedNodesPos)
                Gizmos.DrawCube(((Vector3)g.position + (Vector3)g.position) / 2,
                new Vector3(AstarPath.active.data.gridGraph.nodeSize, 0.5f, AstarPath.active.data.gridGraph.nodeSize));
        }   
    }

    /*
    public bool CheckIfObjectSelected()
    {
        if (currentObject != null) return true;
        else return false;
    }

    public void GetBuildingUnderCursor()
    {
        camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(camRay, out hitInfo) && hitInfo.transform.gameObject.GetComponent<Building>() != null)
        {
            selectedTile = hitInfo.transform.gameObject.GetComponent<Tile>();
        }
    }

    public void MoveObjectToCursor()
    {
        if (selectedTile != null)
        {
            currentObject.transform.position = selectedTile.transform.position;
        }
        else return;
    }

    public void MoveModToBuilding()
    {
        //needs to check if mod CAN be placed on building according to mod's type
        //THEN needs to find node on building specifically for the type of mod being placed
        //therefore, buildings should have a list of nodes with keys that the mod can be compared to
        //then, currentObject is moved to position of that node
        //IMPORTANT: any mods need to fit a building's node perfectly, otherwise it looks funky
        //ALSO IMPORTANT: once a mod is placed, the mod needs to know it's owning building
        if (selectedTile != null && selectedTile.isOccupied)
        {
            Building selectedBuilding = selectedTile.building;
            Mod currentMod = currentObject as Mod;

            for(int n = 0; n < selectedBuilding.attNodeList.Count; n++)
            {
                if(currentMod.nodeTag == selectedBuilding.attNodeList[n].nodeTag)
                {
                    selectedNode = selectedBuilding.attNodeList[n];
                }
            }

            if(selectedNode != null)
            {
                currentMod.transform.position = selectedNode.transform.position;
            }
        }
        else return;
    }

    public bool CheckBuildingPlacement()
    {
        //first check if tiles are occupied
        Building currentBuilding = currentObject as Building;

        for(int w = selectedTile.xPos; w < currentBuilding.tileSize.x + selectedTile.xPos; w++)
        {
            for(int h = selectedTile.yPos; h < currentBuilding.tileSize.y + selectedTile.yPos; h++)
            {
                //if (PlayerController.Player.boardManager.GetTileAt(w, h) == null) return false;
                //else if (PlayerController.Player.boardManager.GetTileAt(w, h).isOccupied) return false;
            }
        }
        //TO ADD: then check if tile heights are contiguous
        return true;
    }

    /*
    public bool CheckModPlacement()
    {
        //first check if nodes are occupied
        /*Tile tileBeingChecked = PlayerController.Player.boardManager.GetTileAt(selectedTile.xPos, selectedTile.yPos);

        if (tileBeingChecked.isOccupied)
        {
            //AttachNode selectedNode = null;
            Building currentBuilding = selectedTile.building;
            Mod currentMod = currentObject as Mod;

            for (int n = 0; n < tileBeingChecked.building.attNodeList.Count; n++)
            {
                if (currentMod.nodeTag == currentBuilding.attNodeList[n].nodeTag)
                {
                    if (currentBuilding.attNodeList[n].isAttached) return false;
                    else
                    {
                        selectedNode = currentBuilding.attNodeList[n];
                        return true;
                    }
                }
            }
        }
        return false;
    }*/
    /*
    public void PlaceBuilding()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (canPlaceObject)
            {
                Building currentBuilding = currentObject as Building;

                for (int w = selectedTile.xPos; w < currentBuilding.tileSize.x + selectedTile.xPos; w++)
                {
                    for (int h = selectedTile.yPos; h < currentBuilding.tileSize.y + selectedTile.yPos; h++)
                    {
                        //PlayerController.Player.boardManager.GetTileAt(w, h).isOccupied = true;
                        //PlayerController.Player.boardManager.GetTileAt(w, h).building = currentBuilding;
                    }
                }

                currentObject = null;
                currentInputMode = InputMode.selectMode;
            }
        }
    }
    
    public void AttachMod()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (canPlaceObject)
            {
                currentObject.transform.SetParent(selectedNode.transform);
                selectedNode.isAttached = true;
                currentObject = null;
                currentInputMode = InputMode.selectMode;
            }
        }
    }

    public void SetNewBuilding(PlaceableAsset newObject)
    {
        currentObject = Instantiate(newObject);
        currentInputMode = InputMode.buildMode;
    }

    public Mod SetNewMod(PlaceableAsset newObject)
    {
        currentObject = Instantiate(newObject);
        currentInputMode = InputMode.modifyMode;
        return newObject as Mod;
    }

    public void SetInputMode(InputMode newMode)
    {
        currentInputMode = InputMode.selectMode;
    }*/

}
