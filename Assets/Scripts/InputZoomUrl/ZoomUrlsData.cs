using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace InputZoomUrl
{
    // room名とurlのペアを全て保存するデータ構造
    [System.Serializable]
    public class ZoomUrlsData : ISerializationCallbackReceiver
    {
        public List<Tuple<string, string>> data;
        public List<string> dataForSerialize;

        public ZoomUrlsData()
        {
            data = new List<Tuple<string, string>>(){};
            dataForSerialize = new List<string>();
        }

        // List中のn番目のデータ(room名とurlのタプル)を返す
        public Tuple<string, string> Get(int n)
        {
            return data[n];
        }

        // 新しいデータを追加
        public void Add(Tuple<string, string> newData)
        {
            data.Add(newData);
        }

        // n番目のデータを変更
        public void Edit(int n, Tuple<string, string> newData)
        {
            data.RemoveAt(n);
            data.Insert(n, newData);
        }

        // n番目のデータを削除
        public void Delete(int n)
        {
            data.RemoveAt(n);
        }

        // データサイズを取得
        public int Count()
        {
            return data.Count;
        }
    
        // 要素数がn個のタプルのリストを、要素数が2n個のリストに変換する
        // (タプルがJsonUtilityでserializeできないため)
        public void OnBeforeSerialize()
        {
            dataForSerialize.Clear();
            
            foreach (Tuple<string, string> tupleData in data)
            {
                dataForSerialize.Add(tupleData.Item1);
                dataForSerialize.Add(tupleData.Item2);
            }
        }

        public void OnAfterDeserialize()
        {
            data.Clear();

            int size = dataForSerialize.Count;
            for (int index = 0; index < size; index += 2)
            {
                data.Add(new Tuple<string, string>(dataForSerialize[index], dataForSerialize[index + 1]));
            }
        }
    }
}