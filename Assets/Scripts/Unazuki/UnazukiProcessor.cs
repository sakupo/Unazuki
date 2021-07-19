using System;
using OpenCvSharp;
using UnityEngine;
using OpenCvSharp.Demo;
using Rect = OpenCvSharp.Rect;

namespace Unazuki
{
  using Unity = OpenCvSharp.Unity;

  public class UnazukiProcessor : WebCamera, IUnazukiProcessor
  {
    public TextAsset faces;
    public TextAsset eyes;
    public TextAsset shapes;

    private FaceProcessorLive<WebCamTexture> processor;
    private Rect CurrentDetectedFace { get; set; }

    /// <summary>
    /// Default initializer for MonoBehavior sub-classes
    /// </summary>
    protected override void Awake()
    {
      base.Awake();
      base.forceFrontalCamera =
        true; // we work with frontal cams here, let's force it for macOS s MacBook doesn't state frontal cam correctly

      byte[] shapeDat = shapes.bytes;
      if (shapeDat.Length == 0)
      {
        string errorMessage =
          "In order to have Face Landmarks working you must download special pre-trained shape predictor " +
          "available for free via DLib library website and replace a placeholder file located at " +
          "\"OpenCV+Unity/Assets/Resources/shape_predictor_68_face_landmarks.bytes\"\n\n" +
          "Without shape predictor demo will only detect face rects.";

#if UNITY_EDITOR
        // query user to download the proper shape predictor
        if (UnityEditor.EditorUtility.DisplayDialog("Shape predictor data missing", errorMessage, "Download",
          "OK, process with face rects only"))
          Application.OpenURL("http://dlib.net/files/shape_predictor_68_face_landmarks.dat.bz2");
#else
             UnityEngine.Debug.Log(errorMessage);
#endif
      }

      processor = new FaceProcessorLive<WebCamTexture>();
      processor.Initialize(faces.text, eyes.text, shapes.bytes);

      // data stabilizer - affects face rects, face landmarks etc.
      processor.DataStabilizer.Enabled = true; // enable stabilizer
      processor.DataStabilizer.Threshold = 2.0; // threshold value in pixels
      processor.DataStabilizer.SamplesCount = 2; // how many samples do we need to compute stable data

      // performance data - some tricks to make it work faster
      processor.Performance.Downscale = 256; // processed image is pre-scaled down to N px by long side
      processor.Performance.SkipRate = 0; // we actually process only each Nth frame (and every frame for skipRate = 0)
    }

    /// <summary>
    /// Per-frame video capture processor
    /// </summary>
    protected override bool ProcessTexture(WebCamTexture input, ref Texture2D output)
    {
      // detect everything we're interested in
      processor.ProcessTexture(input, TextureParameters);

      // mark detected objects
      processor.MarkDetected();
      if (processor.Faces.Count > 0)
      {
        var faceRect = processor.Faces[0].Region;
        // 外れ値を除外
        if (faceRect.Center.X != 0 || faceRect.Center.Y != 0)
        {
          // 最初に検出した顔の位置を保存
          CurrentDetectedFace = processor.Faces[0].Region;
        }
      }

      // processor.Image now holds data we'd like to visualize
      output = Unity.MatToTexture(processor.Image,
        output); // if output is valid texture it's buffer will be re-used, otherwise it will be re-created

      return true;
    }

    public virtual Rect GetCurrentFaceRect()
    {
      return CurrentDetectedFace;
    }
  }

  public interface IUnazukiProcessor
  {
    Rect GetCurrentFaceRect();
  }
}