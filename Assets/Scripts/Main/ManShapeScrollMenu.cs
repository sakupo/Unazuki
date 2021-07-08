using System.Collections.Generic;
using UnityEngine;

namespace Main
{
  public class ManShapeScrollMenu : MonoBehaviour
  {
    [SerializeField] private List<Mesh> shapeMeshes = new List<Mesh>();
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject menuItemPrefab;

    void Start()
    {
      CreateMenu();
    }

    private void CreateMenu()
    {
      foreach (var mesh in shapeMeshes)
      {
        // menuItemの生成
        var itemObj = Instantiate(menuItemPrefab, menu.transform, false);
        var shapeMeshFilter = itemObj.GetComponentInChildren<MeshFilter>();
        shapeMeshFilter.mesh = mesh;
      }
    }
  }
}