namespace PCM.Models;

// Partial class
public partial class PCM {
    /// <summary>
    /// IHtmlValue interface (Value that can be converted to HTML and string)
    /// </summary>
    public interface IHtmlValue
    {
        string ToHtml();
    }
} // End Partial class
