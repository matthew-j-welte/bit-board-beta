using System.ComponentModel.DataAnnotations.Schema;

namespace API.Data.Entities
{
    [Table("CodeEditorConfiguration")]
    public class CodeEditorConfiguration : BaseEntity
    {
        public int CodeEditorConfigurationId { get; set; }
        public string Name { get; set; }
        public int FontSize { get; set; }
        public int TabSize { get; set; }
        public string ColorTheme { get; set; }
        public string ColorThemeUrl { get; set; }
        public bool HasGutter { get; set; }
        public bool HasLineNumbers { get; set; }
        public bool HighlightLine { get; set; }
        public int EditorHeight { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }
    }
}