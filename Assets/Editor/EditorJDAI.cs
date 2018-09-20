using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEditor;

namespace JungDefiantAI
{
    //Remove MenuItems after finishing BehaviorTreeEditor
    public class MenuItems
    {
        //[MenuItem("JungDefiantAI/BehaviorTree")]
        static void CreateBehaviorTree()
        {

            BehaviorTree behaviortree = ScriptableObject.CreateInstance<BehaviorTree>();
            AssetDatabase.CreateAsset(behaviortree, "Assets/JungDefiantAI/BehaviorTree.asset");

            Debug.Log(AssetDatabase.GetAssetPath(behaviortree));
        }

        //[MenuItem("Assets/JungDefiantAI/AddSelectorNode")]
        static void AddSelectorNode()
        {
            var parentNode = Selection.activeObject as TreeNode;

            TreeNode selectorNode = ScriptableObject.CreateInstance<SelectorNode>();
            if (parentNode.AddChildNode(selectorNode))
            {
                selectorNode.name = "SelectorNode";
                selectorNode.depth = parentNode.depth + 1;
                AssetDatabase.AddObjectToAsset(selectorNode, parentNode);
                AssetDatabase.ImportAsset(AssetDatabase.GetAssetPath(selectorNode));
                Debug.Log(AssetDatabase.GetAssetPath(selectorNode));
            }
            else Debug.Log("Adding new node failed");


        }

        //[MenuItem("Assets/JungDefiantAI/AddSelectorNode", true)]
        private static bool AddSelectorNodeValidation()
        {
            return Selection.activeObject is TreeNode;
        }
    }

    public class BehaviorTreeEditor : EditorWindow
    {

        //Miscellaneous variables
        bool isInitializing = true;
        string BehaviorTreeAssetPath = "";
        string BehaviorTreeAssetName = "";
        List<Rect> NodeGUIList = new List<Rect>();
        Catalog NodeCatalogRef;
        Catalog DecoratorCatalogRef;
        BehaviorTree CurrentBehaviorTree;
        TreeNode NewNodeToBeAdded;
        Rect nodeWindowRect = new Rect(new Rect(15, 15, 150, 300));
        Action newAction;
        Decorator newDecorator;

        //Vector2 scrollPosition;

        //Specific Window variables
        bool showAddNodeWindow = false;
        bool showCreateTreeWindow = false;
        bool showRemoveChildWindow = false;
        bool showLoadTreeWindow = false;
        bool changesToLoadTreePath = true;
        string[] addNodeGridNames;
        string[] removeChildGridNames;
        string[] loadTreeGridNames;
        List<string> loadTreeGridGUID;
        List<PropertyInfo> propertyListing;
        int addNodeInd = 0;
        int removeChildInd = 0;
        int loadTreeInd = 0;
        int DisconnectingParentID = 0;
        Rect addNodeWindowRect;

        //Attaching Node variables
        bool isAttachingNode = false;
        int isAttachingNodeID;

        [MenuItem("Window/JungDefiantAI Editor")]

        static void ShowEditor()
        {
            BehaviorTreeEditor editor = GetWindow<BehaviorTreeEditor>();
            editor.Show(true);
        }


        void OnGUI()
        {

            if (isInitializing)
            {
                NodeCatalogRef = (Catalog)AssetDatabase.LoadAssetAtPath("Assets/JungDefiantAI/Catalog/NodeCatalog.asset", typeof(Catalog));
                addNodeGridNames = new string[NodeCatalogRef.catalog.Length-1];
                for (int n = 1; n < NodeCatalogRef.catalog.Length; n++)
                    addNodeGridNames[n-1] = NodeCatalogRef.catalog[n];
                //scrollPosition = Vector2.zero;
            }

            if(CurrentBehaviorTree == null) NodeGUIList = new List<Rect>();

            if (CurrentBehaviorTree != null)
                for (int i = 0; i < CurrentBehaviorTree.TreeNodeList.Count; i++)
                {
                    if (CurrentBehaviorTree.TreeNodeList[i].ChildNodes != null)
                    foreach (TreeNode n in CurrentBehaviorTree.TreeNodeList[i].ChildNodes)
                    {
                        DrawNodeCurve(NodeGUIList[i], NodeGUIList[n.id]);
                    }
                }

            //scrollPosition = GUI.BeginScrollView(new Rect(0, 0, position.width, position.height), scrollPosition, new Rect(0, 0, position.width, 500));
            BeginWindows();

            if (CurrentBehaviorTree != null) GUILayout.Label("Current Behavior Tree: " + CurrentBehaviorTree.name);

            if (GUILayout.Button("Load Behavior Tree"))
            {
                showLoadTreeWindow = true;
            }

            if (GUILayout.Button("Create New Behavior Tree"))
            {
                showCreateTreeWindow = true;
            }

            if (CurrentBehaviorTree != null)
                if (GUILayout.Button("Add New Node"))
                {
                    showAddNodeWindow = true;
                }

            for (int i = 0; i < NodeGUIList.Count; i++)
            {
                NodeGUIList[i] = GUI.Window(i, NodeGUIList[i], DrawNodeWindow, "Node: ID " + i);
            }


            if (showAddNodeWindow)
            {
                GUI.Window(-1, new Rect(250, 300, 400, 130), DrawAddNodeWindow, "Add Node Window");
            }

            if (showCreateTreeWindow)
            {
                GUI.Window(-2, new Rect(250, 300, 400, 130), DrawCreateTreeWindow, "Create New Behavior Tree");
            }

            if (showRemoveChildWindow)
            {
                GUI.Window(-3, new Rect(250, 300, 400, 130), DrawRemoveChildWindow, "Remove Child From Node");
            }

            if(showLoadTreeWindow)
            {
                GUI.Window(-1, new Rect(250, 300, 400, 130), DrawLoadTreeWindow, "Load Behavior Tree");
            }

            EndWindows();

            //GUI.EndScrollView();
                
        }

        void DrawNodeWindow(int id)
        {

            if (id > 0)
            {
                GUILayout.BeginVertical("Box");

                GUILayout.Label("Decorator");
                //Decorator thisDecorator = CurrentBehaviorTree.TreeNodeList[id].thisDecorator;
                newDecorator = (Decorator)EditorGUILayout.ObjectField(newDecorator, typeof(Decorator), true);

                if (newDecorator != null && newDecorator != CurrentBehaviorTree.TreeNodeList[id].thisDecorator)
                {
                    CurrentBehaviorTree.TreeNodeList[id].thisDecorator = newDecorator;
                    AssetDatabase.Refresh();
                    EditorUtility.SetDirty(CurrentBehaviorTree.TreeNodeList[id]);
                    AssetDatabase.SaveAssets();
                    Debug.Log("Saving Decorator Asset");
                    Debug.Log(newDecorator == CurrentBehaviorTree.TreeNodeList[id].thisDecorator);
                }
                
                if (CurrentBehaviorTree.TreeNodeList[id].thisDecorator != null)
                {
                    for(int p = 0; p < CurrentBehaviorTree.TreeNodeList[id].thisDecorator.GetType().GetProperties().Length; p++)
                    {
                        propertyListing.Add(CurrentBehaviorTree.TreeNodeList[id].thisDecorator.GetType().GetProperties()[p]);
                    }
                    
                    //EditorGUI.Popup
                }

                /*
                if (GUILayout.Button("Add Decorator"))
                {
                    AddDecoratorID = id;
                    showAddDecoratorWindow = true;
                }*/

                GUILayout.EndVertical();
            }

            GUILayout.BeginVertical("Box");

            GUILayout.Label("Depth: " + CurrentBehaviorTree.TreeNodeList[id].depth);
            string TypeLabel = CurrentBehaviorTree.TreeNodeList[id].GetType().ToString();
            GUILayout.Label("Type: " + TypeLabel.Remove(0, 14));

            GUILayout.EndVertical();

            if (isAttachingNode && id > 0 && id != isAttachingNodeID)
                if (GUILayout.Button("Attach To Parent"))
                {
                    if (CurrentBehaviorTree.AddChildNode(isAttachingNodeID, id))
                        Debug.Log("Attached " + isAttachingNodeID + " to " + id);
                    else Debug.LogError("Node attachment failed!");
                    AssetDatabase.Refresh();
                    EditorUtility.SetDirty(CurrentBehaviorTree.TreeNodeList[isAttachingNodeID]);
                    AssetDatabase.SaveAssets();
                    isAttachingNode = false;
                    isAttachingNodeID = id;
                }

            if (!isAttachingNode | (isAttachingNode && id == isAttachingNodeID))
                if (CurrentBehaviorTree.TreeNodeList[id].GetType() != typeof(ActionNode))
                    if ((id == 0 && CurrentBehaviorTree.TreeNodeList[id].ChildNodes.Count < 1) | id > 0)
                        if (GUILayout.Button("Attach Child Node"))
                        {
                            if (!isAttachingNode)
                            {
                                isAttachingNode = true;
                                isAttachingNodeID = id;
                            }
                        }

            if(CurrentBehaviorTree.TreeNodeList[id].ChildNodes != null)
            if (CurrentBehaviorTree.TreeNodeList[id].ChildNodes.Count > 0)
            if (GUILayout.Button("Disconnect Child"))
            {
                    DisconnectingParentID = id;
                    showRemoveChildWindow = true;
            }

            if (CurrentBehaviorTree.TreeNodeList[id].GetType() == typeof(ActionNode))
            {
                GUILayout.Label("Assigned Action");
                ActionNode thisActionNode = (ActionNode)CurrentBehaviorTree.TreeNodeList[id];
                newAction = (Action)EditorGUILayout.ObjectField(newAction, typeof(Action), true);

                if(newAction != null && newAction != thisActionNode.thisAction)
                {
                    thisActionNode.thisAction = newAction;
                    thisActionNode.thisAction.InitializeAction();
                    AssetDatabase.Refresh();
                    EditorUtility.SetDirty(thisActionNode);
                    AssetDatabase.SaveAssets();
                }
            }
                

            if (id > 0)
                if (GUILayout.Button("Delete"))
                {
                    DeleteNode(id);
                }


            GUI.DragWindow();
        }

        void DrawAddNodeWindow(int id)
        {
            GUILayout.BeginVertical("Box");
            
            addNodeInd = GUILayout.SelectionGrid(addNodeInd, addNodeGridNames, 1);

            GUILayout.EndVertical();

            GUILayout.BeginHorizontal("Box");
            if (GUILayout.Button("Create New Node"))
            {
                //Creates new node of given index
                Debug.Log("You are creating a new " + NodeCatalogRef.catalog[addNodeInd+1]);
                AssetDatabase.CreateAsset(CreateInstance(NodeCatalogRef.catalog[addNodeInd + 1]), BehaviorTreeAssetPath + "Nodes/" + NodeCatalogRef.catalog[addNodeInd + 1] +
                    (CurrentBehaviorTree.TreeNodeList.Count) + ".asset");
                NewNodeToBeAdded = (TreeNode)AssetDatabase.LoadAssetAtPath(BehaviorTreeAssetPath + "Nodes/" + NodeCatalogRef.catalog[addNodeInd + 1] + 
                    (CurrentBehaviorTree.TreeNodeList.Count) + ".asset", typeof(TreeNode));
                CurrentBehaviorTree.TreeNodeList.Add(NewNodeToBeAdded);
                NewNodeToBeAdded.ChildNodes = new List<TreeNode>();
                NewNodeToBeAdded.depth = -1;
                NewNodeToBeAdded.id = CurrentBehaviorTree.TreeNodeList.Count-1;
                NodeGUIList.Add(nodeWindowRect);
                showAddNodeWindow = false;
                AssetDatabase.Refresh();
                EditorUtility.SetDirty(NewNodeToBeAdded);
                EditorUtility.SetDirty(CurrentBehaviorTree);
                AssetDatabase.SaveAssets();

            }
            if (GUILayout.Button("Cancel"))
            {
                showAddNodeWindow = false;
            }
            GUILayout.EndHorizontal();

            GUI.DragWindow();
        }

        void DrawCreateTreeWindow(int id)
        {

            GUILayout.BeginVertical("Box");
            GUILayout.Label("Name new BehaviorTree");
            GUILayout.Space(30);
            BehaviorTreeAssetName = GUI.TextField(new Rect(10, 40, 380, 20), BehaviorTreeAssetName);
            GUILayout.EndVertical();

            if (GUILayout.Button("Create Tree") && BehaviorTreeAssetName.Length > 0)
            {
                AssetDatabase.CreateFolder("Assets/JungDefiantAI/BehaviorTrees", BehaviorTreeAssetName);
                BehaviorTreeAssetPath = "Assets/JungDefiantAI/BehaviorTrees/" + BehaviorTreeAssetName + "/";
                NodeGUIList = new List<Rect>();
                AssetDatabase.CreateAsset(CreateInstance("BehaviorTree"), BehaviorTreeAssetPath + BehaviorTreeAssetName + ".asset");
                CurrentBehaviorTree = (BehaviorTree)AssetDatabase.LoadAssetAtPath(BehaviorTreeAssetPath + BehaviorTreeAssetName + ".asset", typeof(BehaviorTree));
                if (CurrentBehaviorTree != null)
                {
                    CurrentBehaviorTree.Initialize();
                    AssetDatabase.CreateFolder("Assets/JungDefiantAI/BehaviorTrees/" + BehaviorTreeAssetName, "Nodes");
                    AssetDatabase.CreateAsset(CreateInstance(NodeCatalogRef.catalog[0]), BehaviorTreeAssetPath + "Nodes/" + NodeCatalogRef.catalog[0] + ".asset");
                    NewNodeToBeAdded = (TreeNode)AssetDatabase.LoadAssetAtPath(BehaviorTreeAssetPath + "Nodes/" + NodeCatalogRef.catalog[0] + ".asset", typeof(TreeNode));
                    CurrentBehaviorTree.TreeNodeList.Add(NewNodeToBeAdded);
                    CurrentBehaviorTree.TreeNodeList[0].ChildNodes = new List<TreeNode>();
                    CurrentBehaviorTree.TreeNodeList[0].depth = 0;
                    CurrentBehaviorTree.TreeNodeList[0].id = 0;
                    NodeGUIList.Add(nodeWindowRect);
                    changesToLoadTreePath = true;
                    AssetDatabase.Refresh();
                    EditorUtility.SetDirty(CurrentBehaviorTree);
                    EditorUtility.SetDirty(NewNodeToBeAdded);
                    AssetDatabase.SaveAssets();
                }
                else Debug.LogError("Behavior Tree failed to be created!");
                showCreateTreeWindow = false;
            }  

            if (GUILayout.Button("Cancel"))
            {
                showCreateTreeWindow = false;
            }

            GUI.DragWindow();
        }

        void DrawLoadTreeWindow(int id)
        {
            GUILayout.BeginVertical("Box");

            if(changesToLoadTreePath)
            {
                loadTreeGridGUID = new List<string>();
                foreach (string s in AssetDatabase.FindAssets("t:BehaviorTree")) loadTreeGridGUID.Add(s);
                loadTreeGridNames = new string[loadTreeGridGUID.Count];
                for (int i = 0; i < loadTreeGridGUID.Count; i++) {
                    loadTreeGridNames[i] = AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(loadTreeGridGUID[i]), typeof(BehaviorTree)).name;
                }
                changesToLoadTreePath = false;
            }

            loadTreeInd = GUILayout.SelectionGrid(loadTreeInd, loadTreeGridNames, 1);

            GUILayout.EndVertical();

            GUILayout.BeginHorizontal("Box");
            if (GUILayout.Button("LoadTree"))
            {
                //Creates new node of given index
                if(loadTreeGridNames.Length == AssetDatabase.FindAssets("t:BehaviorTree").Length)
                {
                    CurrentBehaviorTree = (BehaviorTree)AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(loadTreeGridGUID[loadTreeInd]), typeof(BehaviorTree));
                    BehaviorTreeAssetName = CurrentBehaviorTree.name;
                    BehaviorTreeAssetPath = "Assets/JungDefiantAI/BehaviorTrees/" + BehaviorTreeAssetName + "/";
                    NodeGUIList = new List<Rect>();
                    for(int n = 0; n < CurrentBehaviorTree.TreeNodeList.Count; n++)
                    {
                        NodeGUIList.Add(nodeWindowRect);
                    }
                }
                else
                {
                    changesToLoadTreePath = true;
                    Debug.LogError("Tree not found!");
                }
                showLoadTreeWindow = false;

            }
            if (GUILayout.Button("Cancel"))
            {
                showLoadTreeWindow = false;
            }
            GUILayout.EndHorizontal();

            GUI.DragWindow();
        }

        void DrawRemoveChildWindow(int id)
        {
            GUILayout.BeginVertical("Box");

            removeChildGridNames = new string[CurrentBehaviorTree.TreeNodeList[DisconnectingParentID].ChildNodes.Count];
            for (int c = 0; c < CurrentBehaviorTree.TreeNodeList[DisconnectingParentID].ChildNodes.Count; c++)
                removeChildGridNames[c] = CurrentBehaviorTree.TreeNodeList[DisconnectingParentID].ChildNodes[c].name;
            removeChildInd = GUILayout.SelectionGrid(removeChildInd, removeChildGridNames, 1);

            GUILayout.EndVertical();

            GUILayout.BeginHorizontal("Box");
            if (GUILayout.Button("Disconnect Child Node"))
            {
                //Creates new node of given index
                Debug.Log("You are disconnecting child node " + CurrentBehaviorTree.TreeNodeList[DisconnectingParentID].ChildNodes[removeChildInd].name);
                CurrentBehaviorTree.TreeNodeList[DisconnectingParentID].ChildNodes[removeChildInd].depth = -1;
                CurrentBehaviorTree.TreeNodeList[DisconnectingParentID].ChildNodes.RemoveAt(removeChildInd);
                AssetDatabase.Refresh();
                EditorUtility.SetDirty(CurrentBehaviorTree.TreeNodeList[DisconnectingParentID]);
                AssetDatabase.SaveAssets();
                showRemoveChildWindow = false;

            }
            if (GUILayout.Button("Cancel"))
            {
                showRemoveChildWindow = false;
            }
            GUILayout.EndHorizontal();

            //CurrentBehaviorTree.TreeNodeList[id].ChildNodes.RemoveAt()
        }
        /*
        void DrawAddDecoratorWindow(int id)
        {
            GUILayout.BeginVertical("Box");

            addDecoratorInd = GUILayout.SelectionGrid(addDecoratorInd, addDecoratorGridNames, 1);

            GUILayout.EndVertical();

            GUILayout.BeginHorizontal("Box");
            if (GUILayout.Button("Add New Decorator"))
            {
                //Creates new node of given index
                Debug.Log("You are adding " + DecoratorCatalogRef.catalog[addNodeInd] + " to node " + CurrentBehaviorTree.TreeNodeList[AddDecoratorID].name);
                CurrentBehaviorTree.TreeNodeList[AddDecoratorID].thisDecorator = (Decorator)AssetDatabase.LoadAssetAtPath("Assets/JungDefiantAI/Nodes/Decorator/" + DecoratorCatalogRef.catalog[addNodeInd], typeof(Decorator));
                showAddDecoratorWindow = false;
                AssetDatabase.Refresh();
                EditorUtility.SetDirty(NewNodeToBeAdded);
                EditorUtility.SetDirty(CurrentBehaviorTree);
                AssetDatabase.SaveAssets();

            }
            if (GUILayout.Button("Cancel"))
            {
                showAddDecoratorWindow = false;
            }
            GUILayout.EndHorizontal();

            GUI.DragWindow();
        }*/

        void DrawNodeCurve(Rect start, Rect end)
        {
            Vector3 startPos = new Vector3(start.x + start.width / 2, start.y + start.height, 0);
            Vector3 endPos = new Vector3(end.x + end.width / 2, end.y, 0);
            Vector3 startTan = startPos + Vector3.down * -50;
            Vector3 endTan = endPos + Vector3.up * -50;
            Color shadowCol = new Color(0, 0, 0, 0.06f);

            for (int i = 0; i < 3; i++)
            {// Draw a shadow
                Handles.DrawBezier(startPos, endPos, startTan, endTan, shadowCol, null, (i + 1) * 5);
            }

            Handles.DrawBezier(startPos, endPos, startTan, endTan, Color.black, null, 1);
        }

        void DeleteNode(int id)
        {

        }
    }

}

