using System;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;
using Utility;

namespace Main
{
  public class ManShapeScrollMenu : MonoBehaviour
  {
    [SerializeField] private List<Mesh> shapeMeshes = new List<Mesh>();
    public List<string> shapeNames;
    [SerializeField] private GameObject menu;
    private ManShapeController manShapeController;
    [SerializeField] private GameObject menuItemPrefab;
    private readonly List<MeshRenderer> itemMeshRenderers = new List<MeshRenderer>();
    private int currentHighRightId = 0;

    void Start()
    {
      manShapeController = GetComponent<ManShapeController>();
      CreateMenu();
    }

    private void Update()
    {
      var currentShapeNumber = manShapeController.CurrentShapeNumber;
      if (currentHighRightId != currentShapeNumber)
      {
        DeselectItem(itemMeshRenderers[currentHighRightId]);
        currentHighRightId = currentShapeNumber;
        SelectItem(itemMeshRenderers[currentHighRightId]);
      }
    }
    
    private void DeselectItem(MeshRenderer MeshRenderer)
    {
      MeshRenderer.material.color = Color.gray;
    }

    private void SelectItem(MeshRenderer MeshRenderer)
    {
      MeshRenderer.material.color = new Color(255/255f, 125/255f, 0/255f);
    }

    private void CreateMenu()
    {
      for (int i = 0; i < shapeNames.Count; i++)
      {
        var shapeName = shapeNames[i];
        var mesh = shapeMeshes[i];
        // menuItemの生成
        var itemObj = Instantiate(menuItemPrefab, menu.transform, false);
        itemObj.name = shapeName;
        var itemButton = itemObj.GetComponent<ManShapeMenuItem>();
        itemButton.Subscribe(manShapeController);
        var shapeMeshFilter = itemObj.GetComponentInChildren<MeshFilter>();
        shapeMeshFilter.mesh = mesh;
        var itemMeshRenderer = itemObj.GetComponentInChildrenWithoutSelf<MeshRenderer>();
        DeselectItem(itemMeshRenderer);
        itemMeshRenderers.Add(itemMeshRenderer);
      }
      
      if (itemMeshRenderers.Count > 0)
      {
        SelectItem(itemMeshRenderers[0]);
      }
    }
  }
}