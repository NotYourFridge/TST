public class TrackingService
{
    private readonly TrackingContext _context;

    public TrackingService(TrackingContext context)
    {
        _context = context;
    }

    public void TrackClick(string page)
    {
        TrackInteraction(page, interaction => interaction.ClickCount++);
    }

    public void TrackHover(string page)
    {
        TrackInteraction(page, interaction => interaction.HoverCount++);
    }

    private void TrackInteraction(string page, Action<PageInteraction> action)
    {
        var interaction = _context.TrackingData
            .FirstOrDefault(p => p.Page == page);

        if (interaction != null)
        {
            action(interaction);
        }
        else
        {
            var newInteraction = new PageInteraction
            {
                Page = page
            };
            action(newInteraction);
            _context.TrackingData.Add(newInteraction);
        }

        _context.SaveChanges();
    }
}
