using System;
using SqlSugar;

namespace NET_FiveMinutes_006_AlbertToolHelperDesktop.Models
{
    [SugarTable("T_AlbertToolHelperModel")]
    public class AlbertToolHelperModel
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public long Id { get; set; }
        public string Sort { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        [SugarColumn(Length = Int32.MaxValue)]
        public string Description { get; set; }
        [SugarColumn(Length = Int32.MaxValue)]
        public string SupportVersion { get; set; }
        public string Doc { get; set; }
    }
}