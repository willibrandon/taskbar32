namespace taskbar32.tests;

public class TaskbarHelperTests
{
    [WinFormsFact]
    public void ActivateTab()
    {
        using Form form = new();
        form.Show();

        TaskbarHelper taskbarHelper = new(form.Handle);
        taskbarHelper.ActivateTab();
    }

    [WinFormsFact]
    public void DeleteTab_AddTab()
    {
        using Form form = new();
        form.Show();

        TaskbarHelper taskbarHelper = new(form.Handle);
        taskbarHelper.DeleteTab();
        taskbarHelper.AddTab();
    }

    [WinFormsFact]
    public void DisplayProgress()
    {
        using Form form = new();
        form.Show();

        TaskbarHelper taskbarHelper = new(form.Handle);

        foreach (int i in Enumerable.Range(0, 100))
        {
            taskbarHelper.SetProgressValue(completed: i, total: 100);
        }
    }

    [WinFormsTheory]
    [InlineData(true)]
    [InlineData(false)]
    public void MarkFullscreenWindow(bool fullScreen)
    {
        using Form form = new();
        form.Show();

        TaskbarHelper taskbarHelper = new(form.Handle);
        taskbarHelper.MarkFullscreenWindow(fullScreen);
    }

    [WinFormsFact]
    public void SetActiveAlt()
    {
        using Form form = new();
        form.Show();

        TaskbarHelper taskbarHelper = new(form.Handle);
        taskbarHelper.SetActiveAlt();
    }

    [WinFormsFact]
    public void SetProgressState_Error()
    {
        using Form form = new();
        form.Show();

        TaskbarHelper taskbarHelper = new(form.Handle);
        taskbarHelper.SetProgressState(TaskbarProgressState.Error);
    }

    [WinFormsFact]
    public void SetProgressState_Indeterminate()
    {
        using Form form = new();
        form.Show();

        TaskbarHelper taskbarHelper = new(form.Handle);
        taskbarHelper.SetProgressState(TaskbarProgressState.Indeterminate);
    }

    [WinFormsFact]
    public void SetProgressState_NoProgress()
    {
        using Form form = new();
        form.Show();

        TaskbarHelper taskbarHelper = new(form.Handle);
        taskbarHelper.SetProgressState(TaskbarProgressState.NoProgress);
    }

    [WinFormsFact]
    public void SetProgressState_Normal()
    {
        using Form form = new();
        form.Show();

        TaskbarHelper taskbarHelper = new(form.Handle);
        taskbarHelper.SetProgressState(TaskbarProgressState.Normal);
    }

    [WinFormsFact]
    public void SetProgressState_Paused()
    {
        using Form form = new();
        form.Show();

        TaskbarHelper taskbarHelper = new(form.Handle);
        taskbarHelper.SetProgressState(TaskbarProgressState.Paused);
    }

    [WinFormsFact]
    public void SetProgressValue()
    {
        using Form form = new();
        form.Show();

        TaskbarHelper taskbarHelper = new(form.Handle);
        taskbarHelper.SetProgressValue(50, 100);
    }

    [WinFormsFact]
    public void SetThumbnailTooltip()
    {
        using Form form = new();
        form.Show();

        TaskbarHelper taskbarHelper = new(form.Handle);
        taskbarHelper.SetThumbnailTooltip("Meow ❤️");
    }
}