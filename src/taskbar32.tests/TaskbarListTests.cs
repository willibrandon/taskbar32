namespace taskbar32.tests;

public class TaskbarListTests
{
    [Fact]
    public void ActivateTab()
    {
        using Form form = new();
        form.Show();

        TaskbarHelper taskbarHelper = new(form.Handle);
        taskbarHelper.ActivateTab();
    }

    [Fact]
    public void DeleteTab_AddTab()
    {
        using Form form = new();
        form.Show();

        TaskbarHelper taskbarHelper = new(form.Handle);
        taskbarHelper.DeleteTab();
        taskbarHelper.AddTab();
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void MarkFullscreenWindow(bool fullScreen)
    {
        using Form form = new();
        form.Show();

        TaskbarHelper taskbarHelper = new(form.Handle);
        taskbarHelper.MarkFullscreenWindow(fullScreen);
    }

    [Fact]
    public void SetActiveAlt()
    {
        using Form form = new();
        form.Show();

        TaskbarHelper taskbarHelper = new(form.Handle);
        taskbarHelper.SetActiveAlt();
    }

    [Fact]
    public void SetProgressState_Error()
    {
        using Form form = new();
        form.Show();

        TaskbarHelper taskbarHelper = new(form.Handle);
        taskbarHelper.SetProgressState(TaskbarProgressState.Error);
    }

    [Fact]
    public void SetProgressState_Indeterminate()
    {
        using Form form = new();
        form.Show();

        TaskbarHelper taskbarHelper = new(form.Handle);
        taskbarHelper.SetProgressState(TaskbarProgressState.Indeterminate);
    }

    [Fact]
    public void SetProgressState_NoProgress()
    {
        using Form form = new();
        form.Show();

        TaskbarHelper taskbarHelper = new(form.Handle);
        taskbarHelper.SetProgressState(TaskbarProgressState.NoProgress);
    }

    [Fact]
    public void SetProgressState_Normal()
    {
        using Form form = new();
        form.Show();

        TaskbarHelper taskbarHelper = new(form.Handle);
        taskbarHelper.SetProgressState(TaskbarProgressState.Normal);
    }

    [Fact]
    public void SetProgressState_Paused()
    {
        using Form form = new();
        form.Show();

        TaskbarHelper taskbarHelper = new(form.Handle);
        taskbarHelper.SetProgressState(TaskbarProgressState.Paused);
    }

    [Fact]
    public void SetProgressValue()
    {
        using Form form = new();
        form.Show();

        TaskbarHelper taskbarHelper = new(form.Handle);
        taskbarHelper.SetProgressValue(50, 100);
    }

    [Fact]
    public void SetThumbnailTooltip()
    {
        using Form form = new();
        form.Show();

        TaskbarHelper taskbarHelper = new(form.Handle);
        taskbarHelper.SetThumbnailTooltip("Meow");
    }
}