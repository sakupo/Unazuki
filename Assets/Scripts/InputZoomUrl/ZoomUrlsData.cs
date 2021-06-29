using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace InputZoomUrl
{
    // room名とurlのペアを全て保存するデータ構造
    public class ZoomUrlsData
    {
        private List<Tuple<string, string>> zoomUrlsData;

        public ZoomUrlsData()
        {
            zoomUrlsData = new List<Tuple<string, string>>()
            {
                new Tuple<string, string>("aaa", "www.aaa"),
                new Tuple<string, string>("bbb", "www.bbb"),
                new Tuple<string, string>("ccc", "www.ccc")
            };
        }

        // List中のn番目のデータ(room名とurlのタプル)を返す
        public Tuple<string, string> Get(int n)
        {
            return zoomUrlsData[n];
        }

        // 新しいデータを追加
        public void Add(string roomName, string zoomUrl)
        {
            zoomUrlsData.Add(new Tuple<string, string>(roomName, zoomUrl));
        }

        // データサイズを取得
        public int Count()
        {
            return zoomUrlsData.Count;
        }
    }
}