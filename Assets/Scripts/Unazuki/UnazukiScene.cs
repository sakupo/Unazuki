using System;
using OpenCvSharp;
using UnityEngine;

namespace Unazuki
{
  public class UnazukiScene : MonoBehaviour
  {
    [SerializeField] private UnazukiProcessor processor;
    private UnazukiExtractor extractor;
    void Awake()
    {
      extractor = new UnazukiExtractor(processor) {FaceBasePos = new Point(0, 240)};
    }
  }
}