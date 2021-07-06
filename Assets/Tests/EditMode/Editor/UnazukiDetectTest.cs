using NUnit.Framework;
using OpenCvSharp;
using Unazuki;
using UnityEngine;
using Rect = OpenCvSharp.Rect;

namespace Tests
{
    public class UnazukiDetectTest
    {
        private DummyUnazukiProcessor dummyProcessor;
        private UnazukiExtractor unazukiExtractor;
        private const int faceBasePosX = 320;
        private const int faceBasePosY = 240;
        private const int minY = 0;
        private const int maxY = 200;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var faceBasePos = new Point(faceBasePosX, faceBasePosY);
            dummyProcessor = new DummyUnazukiProcessor();
            unazukiExtractor = new UnazukiExtractor(dummyProcessor) {FaceBasePos = faceBasePos};
        }
        
        // うなずきレベルの境界値&外れ値テスト
        [TestCase(faceBasePosY+minY-100, 0f )]
        [TestCase(faceBasePosY+minY, 0f )]
        [TestCase(faceBasePosY+maxY, 1f )]
        [TestCase(faceBasePosY+maxY+100, 1f )]
        public void UnazukiExtractorTest(int y, float expected)
        {
            dummyProcessor.Rect = new Rect(0, y, 0, 0);
            Assert.AreEqual(expected,unazukiExtractor.GetUnazukiLevel());
        }
    }

    public class DummyUnazukiProcessor : IUnazukiProcessor
    {
        public Rect Rect { get; set; }

        public Rect GetCurrentFaceRect()
        {
            return Rect;
        }
    }
}
