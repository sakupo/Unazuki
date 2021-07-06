using OpenCvSharp;
using UnityEngine;
using Rect = OpenCvSharp.Rect;

namespace Unazuki
{
  public class UnazukiExtractor
  {
    private readonly IUnazukiProcessor processor;
    // 顔の位置の基準値．これより下(正の値)に行くとうなずきになる．
    public Point FaceBasePos { get; set; }
    // 差分の下限
    private float minY = 0f;
    // 差分の上限
    private float maxY = 200f;

    public UnazukiExtractor(IUnazukiProcessor processor)
    {
      this.processor = processor;
    }

    public float GetUnazukiLevel()
    {
      Rect faceRect = processor.GetCurrentFaceRect();
      float facePosDiff = faceRect.Center.Y - FaceBasePos.Y;
      var unazukiLevel = CalcUnazukiLevel(facePosDiff);
      return unazukiLevel;
    }

    private float CalcUnazukiLevel(float diff)
    {
      var level = diff / (maxY - minY);
      
      if (level < 0f)
      {
        return 0f;
      } 
      if (level > 1f)
      {
        return 1f;
      }

      return level;
    }
  }
}