using System.ComponentModel.DataAnnotations;

public class PageInteraction{

    [Key]
    public int TrackingId { get; set; }

    [Required]
    public string Page { get; set; }

    public int ClickCount { get; set; }
    
    public int HoverCount { get; set; }

}