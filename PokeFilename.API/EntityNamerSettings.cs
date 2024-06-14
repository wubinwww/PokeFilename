using System.ComponentModel;
using PKHeX.Core;

namespace PokeFilename.API
{
    public class EntityNamerSettings
    {
        [Category("PKM名称设定选择"), Description("选择宝可梦名称设定")]
        public EntityNamers Namer { get; set; }

        [Category("自定义名称设置"), Description("自定义宝可梦的名称格式2")]
        public string CustomPatternRegular { get; set; } = "{Species} - {Nickname} - {PID}";

        [Category("自定义名称设置"), Description("自定义宝可梦的PKM名称格式1")]
        public string CustomPatternGameBoy { get; set; } = "{Species}-★-{Nickname}-昵称{OT_Name}-性别{OT_Gender}-里id{DisplaySID}-表id{DisplayTID}-语言{Language}-{PID}";

        public IFileNamer<PKM> Create() => Namer switch
        {
            EntityNamers.AnubisNamer => new AnubisNamer(),
            EntityNamers.CustomNamer => new CustomNamer(CustomPatternRegular, CustomPatternGameBoy),
            _ => new DefaultEntityNamer(),
        };
    }
}
