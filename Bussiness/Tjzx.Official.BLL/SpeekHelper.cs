﻿using System;
using System.Linq;
using System.Web;
using DotNetSpeech;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Configuration;

namespace Tjzx.Official.BLL
{
    public class SpeekHelper
    {
        public static string Speek(string word)
        {
            string url;
            if (!CheckWord(word, out url))
            {
                var path = HttpContext.Current.Server.MapPath(url);
                var voice = new SpVoice();
                voice.Voice = voice.GetVoices(string.Empty, string.Empty).Item(0);
                var sp = new SpFileStream();
                sp.Open(path, SpeechStreamFileMode.SSFMCreateForWrite);
                voice.AudioOutputStream = sp;
                voice.Speak(word);
                voice.WaitUntilDone(System.Threading.Timeout.Infinite);
                sp.Close();
            }
            return url;
        }

        private static bool CheckWord(string word, out string url)
        {
            url = ConfigurationManager.AppSettings.Get("SpeekFile");
            url = (string.IsNullOrEmpty(url) ? "/SpeekFile/" : string.Format("/{0}/", url));
            var hash = GetMd5Sum(word) + ".wav";
            var dir = new DirectoryInfo(HttpContext.Current.Server.MapPath(url));
            url += hash;
            return dir.GetFiles("*.wav").Any(file => file.Name == hash);
        }

        private static string NewGuid()
        {
            return Guid.NewGuid().ToString().Replace("-", "").ToLower();
        }

        private static string GetMd5Sum(string str)
        {
            Encoder enc = Encoding.Unicode.GetEncoder();

            var unicodeText = new byte[str.Length*2];
            enc.GetBytes(str.ToCharArray(), 0, str.Length, unicodeText, 0, true);

            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(unicodeText);

            var sb = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                sb.Append(result[i].ToString("X2"));
            }

            return sb.ToString();
        }
    }
}