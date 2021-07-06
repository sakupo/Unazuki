using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spout
{
    public class SoundVolume : MonoBehaviour
    {
        [SerializeField, Range(0f, 10000f)] float m_gain = 30.0f; // 音量に掛ける倍率

        [SerializeField]
        private int device_index;
        public int Device_index
        {
            get
            {
                return device_index;
            }
            set
            {
                device_index = value;
            }
        }

        public float m_volumeRate; // 音量(0-1)

        private readonly int SampleNum = (2 << 9);
        AudioSource m_source;
        float[] currentValues;


        // Use this for initialization
        void Start()
        {

            m_source = GetComponent<AudioSource>();
            currentValues = new float[SampleNum];

            AudioSource aud = GetComponent<AudioSource>();
            for (int i = 0; i < Microphone.devices.Length; i++)
            {
                Debug.Log("device name : " + Microphone.devices[i]);
            }

            if ((aud != null) && (Microphone.devices.Length > 0)) // オーディオソースとマイクがある
            {
                string devName = Microphone.devices[0]; // 複数見つかってもとりあえず0番目のマイクを使用
                int minFreq, maxFreq;
                Microphone.GetDeviceCaps(devName, out minFreq, out maxFreq); // 最大最小サンプリング数を得る

                int ms = minFreq / SampleNum; // サンプリング時間を適切に取る
                m_source.loop = true; // ループにする
                m_source.clip = Microphone.Start(devName, true, ms, minFreq); // clipをマイクに設定
                while (!(Microphone.GetPosition(devName) > 0)) { } // きちんと値をとるために待つ
                Microphone.GetPosition(null);
                m_source.Play();
            }
        }

        // Update is called once per frame
        void Update()
        {
            m_source.GetSpectrumData(currentValues, 0, FFTWindow.Hamming);
            float sum = 0f;
            for (int i = 0; i < currentValues.Length; ++i)
            {
                sum += currentValues[i]; // データ（周波数帯ごとのパワー）を足す
            }
            // データ数で割ったものに倍率をかけて音量とする
            m_volumeRate = Mathf.Clamp01(sum * m_gain / (float)currentValues.Length);
            GameObject.Find("man").GetComponent<Renderer>().material.SetFloat("_Volume", m_volumeRate);
        }


    }
}
