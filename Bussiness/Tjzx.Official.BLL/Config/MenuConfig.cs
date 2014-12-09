using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Tjzx.Official.BLL.Dict;
using System.Linq;
using Tjzx.BLL.Config;

namespace Tjzx.Official.BLL.Config
{
    [Serializable]
    [XmlRoot("root")]
    [FileName("menu.config")]
    public class MenuConfig : ConfigBase
    {
        [XmlArray("menus")]
        [XmlArrayItem("item")]
        public List<MenuItem> Menus { get; set; }
    }

    public class MenuItem
    {
        [XmlAttribute("id")]
        public int MenuId { get; set; }

        [XmlAttribute("pid")]
        public int ParentId { get; set; }

        [XmlAttribute("depth")]
        public int Depth { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("link")]
        public string Link { get; set; }

        [XmlAttribute("role")]
        public int Role { get; set; }

        [XmlAttribute("sort")]
        public int Sort { get; set; }

        [XmlAttribute("cls")]
        public string Icon { get; set; }
    }

    public class MenuManager
    {
        private readonly int _userRole;

        private readonly List<MenuItem> _menus;

        public MenuManager(int userRole)
        {
            _userRole = userRole;
            _menus = ConfigUtils<MenuConfig>.Instance().Get().Menus;
            foreach (var menuItem in _menus.Where(t => t.ParentId > 0))
            {
                var pItem = _menus.FirstOrDefault(t => t.MenuId == menuItem.ParentId);
                if (pItem != null)
                    pItem.Role |= menuItem.Role;
            }
        }

        public MenuManager(ManagerRole userRole)
            : this((int) userRole)
        {
        }

        public List<MenuItem> GetMenus(int parentId)
        {
            return _menus.Where(t => t.ParentId == parentId && (t.Role & _userRole) > 0).OrderBy(t => t.Sort).ToList();
        }
    }
}
