using BitBoard.Domain.Shared.Models;

namespace BitBoard.Domain.Account.Models
{
    public class CodeEditorConfiguration : BaseEntity
    {
        public string CodeEditorConfigurationId => this.Id;
        public string Name { get; set; }
        public int FontSize { get; set; }
        public int TabSize { get; set; }
        public string ColorTheme { get; set; }
        public string ColorThemeUrl { get; set; }
        public bool HasGutter { get; set; }
        public bool HasLineNumbers { get; set; }
        public bool HighlightLine { get; set; }
        public int EditorHeight { get; set; }

        public CodeEditorUser Author { get; set; }
    }

    public class CodeEditorUser
    {
        public string UserId { get; set; }
        public string Username { get; set; }
    }
}