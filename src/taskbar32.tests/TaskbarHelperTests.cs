namespace taskbar32.tests;

public class TaskbarHelperTests
{
    [WinFormsFact]
    public void TaskbarHelper_ActivateTab()
    {
        using Form form = new();
        form.Show();

        TaskbarHelper taskbarHelper = new(form.Handle);
        taskbarHelper.ActivateTab();
    }

    [WinFormsFact]
    public void TaskbarHelper_DeleteTab_AddTab()
    {
        using Form form = new();
        form.Show();

        TaskbarHelper taskbarHelper = new(form.Handle);
        taskbarHelper.DeleteTab();
        taskbarHelper.AddTab();
    }

    [WinFormsTheory]
    [InlineData(true)]
    [InlineData(false)]
    public void TaskbarHelper_MarkFullscreenWindow(bool fullScreen)
    {
        using Form form = new();
        form.Show();

        TaskbarHelper taskbarHelper = new(form.Handle);
        taskbarHelper.MarkFullscreenWindow(fullScreen);
    }

    [WinFormsFact]
    public void TaskbarHelper_SetActiveAlt()
    {
        using Form form = new();
        form.Show();

        TaskbarHelper taskbarHelper = new(form.Handle);
        taskbarHelper.SetActiveAlt();
    }

    [WinFormsFact]
    public void TaskbarHelper_SetProgressState_Error()
    {
        using Form form = new();
        form.Show();

        TaskbarHelper taskbarHelper = new(form.Handle);
        taskbarHelper.SetProgressState(TaskbarProgressState.Error);
    }

    [WinFormsFact]
    public void TaskbarHelper_SetProgressState_Indeterminate()
    {
        using Form form = new();
        form.Show();

        TaskbarHelper taskbarHelper = new(form.Handle);
        taskbarHelper.SetProgressState(TaskbarProgressState.Indeterminate);
    }

    [WinFormsFact]
    public void TaskbarHelper_SetProgressState_NoProgress()
    {
        using Form form = new();
        form.Show();

        TaskbarHelper taskbarHelper = new(form.Handle);
        taskbarHelper.SetProgressState(TaskbarProgressState.NoProgress);
    }

    [WinFormsFact]
    public void TaskbarHelper_SetProgressState_Normal()
    {
        using Form form = new();
        form.Show();

        TaskbarHelper taskbarHelper = new(form.Handle);
        taskbarHelper.SetProgressState(TaskbarProgressState.Normal);
    }

    [WinFormsFact]
    public void TaskbarHelper_SetProgressState_Paused()
    {
        using Form form = new();
        form.Show();

        TaskbarHelper taskbarHelper = new(form.Handle);
        taskbarHelper.SetProgressState(TaskbarProgressState.Paused);
    }

    [WinFormsFact]
    public void TaskbarHelper_SetProgressValue()
    {
        using Form form = new();
        form.Show();

        TaskbarHelper taskbarHelper = new(form.Handle);
        taskbarHelper.SetProgressValue(50, 100);
    }

    [WinFormsFact]
    public void TaskbarHelper_SetThumbnailTooltip()
    {
        using Form form = new();
        form.Show();

        TaskbarHelper taskbarHelper = new(form.Handle);
        taskbarHelper.SetThumbnailTooltip("Meow");
    }
}