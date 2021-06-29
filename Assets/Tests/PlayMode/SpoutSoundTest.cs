
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Spout;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;


namespace Tests
{
    public class SpoutSoundTest
    {
        private Canvas mainCanvas;
        SoundVolume soundvolume;


        [SetUp]
        public void SetUp()
        {
            // 初期シーンのロード
            SceneManager.LoadScene("RootScene");
            SceneManager.LoadSceneAsync("SpoutScene").completed += _ => {
                soundvolume = GameObject.Find("AudioSource")?.GetComponent<SoundVolume>();
            };


        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator Spout_VolumeTest()
        {
            //音量は1~0か
            var volume = soundvolume.m_volumeRate;
            Assert.GreaterOrEqual(volume, 0f);
            Assert.LessOrEqual(volume, 1f);
            yield return null;
        }
    }
}