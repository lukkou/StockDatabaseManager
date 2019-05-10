﻿using System.Collections.Generic;
using CoreTweet;

using RealtimeIndexImporter.Utility;
using RealtimeIndexImporter.Common;
using RealtimeIndexImporter.Models;

namespace RealtimeIndexImporter.Logic
{
    class PublicInformationTweetLogic
    {
        /// <summary>
        /// 金利文字定数
        /// </summary>
        private const string InterestRate = "金利";

        /// <summary>
        /// 公開された指標をツイート
        /// </summary>
        /// <param name="list"></param>
        public void PublicInformationTweet(List<IndexCalendar> list)
        {
            var tokens = Tokens.Create(Define.Tweeter.ConsumerKey, Define.Tweeter.ConsumerSecret, Define.Tweeter.AccessToken, Define.Tweeter.AccessSecret);
            foreach(IndexCalendar item in list)
            {
                string tweetText = string.Empty;
                string countryFlag = Tools.CountryNameToCountryFlag(item.CountryName);
                string title = string.Empty;
                title += countryFlag;
                //タイトルに金利の文字が無い場合国名をつける
                if (item.EventName.IndexOf(InterestRate) == -1)
                {
                    title += item.CountryName;
                }
                title += " " + item.EventName;

                tweetText += title + "\r\n";
                tweetText += "通貨　[" + item.CurrencyCode + "]\r\n";
                tweetText += "今回値[" + item.ActualValue + "]\r\n";
                if (!string.IsNullOrEmpty(item.ForecastValue))
                {
                    tweetText += "予想値[" + item.ForecastValue + "]\r\n";
                }
                tweetText += "前回値[" + item.PreviousValue + "]\r\n";
                tweetText += "\r\n" + Define.Mql5BaseUrl + item.LinkUrl;

                tokens.Statuses.Update(status => tweetText);
            }
        }
    }
}
