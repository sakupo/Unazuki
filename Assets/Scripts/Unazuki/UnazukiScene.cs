using System;
using OpenCvSharp;
using UnityEngine;

namespace Unazuki
{
  public class UnazukiScene : MonoBehaviour
  {
    [SerializeField] private UnazukiProcessor processor;
    public UnazukiExtractor Extractor { get; private set; }

    void Awake()
    {
      Extractor = new UnazukiExtractor(processor) {FaceBasePos = new Point(0, 240)};
    }
  }
}