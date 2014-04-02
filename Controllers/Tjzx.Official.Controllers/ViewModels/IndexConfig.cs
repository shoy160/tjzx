﻿using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Tjzx.Web;

namespace Tjzx.Official.Controllers.ViewModels
{
    /// <summary>
    /// 首页配置
    /// </summary>
    [Serializable]
    [XmlRoot("root")]
    public class IndexConfig
    {
        /// <summary>
        /// 导航菜单
        /// </summary>
        [XmlArray("navigations")]
        [XmlArrayItem("item")]
        public List<Navigation> Navigations { get; set; }

        /// <summary>
        /// 滚动图片广告
        /// </summary>
        [XmlArray("sliders")]
        [XmlArrayItem("item")]
        public List<Slider> Sliders { get; set; }

        /// <summary>
        /// 展示分类
        /// </summary>
        [XmlArray("categories")]
        [XmlArrayItem("item")]
        public List<Category> Categories { get; set; }

        [XmlArray("friends")]
        [XmlArrayItem("item")]
        public List<WordLink> FriendsLink { get; set; }

        [XmlIgnore] private const string FileName = "index.config";

        public static IndexConfig Get()
        {
            return ConfigManager.GetConfig<IndexConfig>(FileName);
        }

        public static void Set(IndexConfig config)
        {
            ConfigManager.SetConfig(FileName, config);
        }
    }

    /// <summary>
    /// 导航菜单
    /// </summary>
    [Serializable]
    public class Navigation
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("class")]
        public string Class { get; set; }

        [XmlAttribute("sort")]
        public int Sort { get; set; }

        [XmlAttribute("link")]
        public string Link { get; set; }

        [XmlAttribute("target")]
        public string Target { get; set; }
    }

    /// <summary>
    /// 滚动广告图片
    /// </summary>
    [Serializable]
    public class Slider
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("url")]
        public string ImageUrl { get; set; }

        [XmlAttribute("title")]
        public string Title { get; set; }

        [XmlAttribute("link")]
        public string Link { get; set; }

        [XmlAttribute("sort")]
        public int Sort { get; set; }
    }

    public class WordLink
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("title")]
        public string Title { get; set; }

        [XmlAttribute("link")]
        public string Link { get; set; }

        [XmlAttribute("sort")]
        public int Sort { get; set; }
    }

    /// <summary>
    /// 套餐分类
    /// </summary>
    [Serializable]
    public class Category
    {
        [XmlAttribute("url")]
        public string ImageUrl { get; set; }

        [XmlAttribute("name")]
        public string CategoryName { get; set; }

        [XmlAttribute("cateId")]
        public int CategoryId { get; set; }

        [XmlAttribute("sort")]
        public int Sort { get; set; }
    }
}