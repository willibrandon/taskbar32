namespace taskbar32.tests;

public class FormExtensionsTests
{
    [WinFormsFact]
    public void ActivateTab()
    {
        using Form form = new();
        form.Show();

        form.ActivateTab();
    }

    [WinFormsFact]
    public void DeleteTab_AddTab()
    {
        using Form form = new();
        form.Show();

        form.DeleteTab();
        form.AddTab();
    }

    [WinFormsTheory]
    [InlineData(true)]
    [InlineData(false)]
    public void MarkFullscreenWindow(bool fullScreen)
    {
        using Form form = new();
        form.Show();

        form.MarkFullscreenWindow(fullScreen);
    }

    [WinFormsFact]
    public void SetActiveAlt()
    {
        using Form form = new();
        form.Show();

        form.SetActiveAlt();
    }

    [WinFormsFact]
    public void SetProgressState_Error()
    {
        using Form form = new();
        form.Show();

        form.SetProgressState(TaskbarProgressState.Error);
    }

    [WinFormsFact]
    public void SetProgressState_Indeterminate()
    {
        using Form form = new();
        form.Show();

        form.SetProgressState(TaskbarProgressState.Indeterminate);
    }

    [WinFormsFact]
    public void SetProgressState_NoProgress()
    {
        using Form form = new();
        form.Show();

        form.SetProgressState(TaskbarProgressState.NoProgress);
    }

    [WinFormsFact]
    public void SetProgressState_Normal()
    {
        using Form form = new();
        form.Show();

        form.SetProgressState(TaskbarProgressState.Normal);
    }

    [WinFormsFact]
    public void SetProgressState_Paused()
    {
        using Form form = new();
        form.Show();

        form.SetProgressState(TaskbarProgressState.Paused);
    }

    [WinFormsFact]
    public void SetProgressValue()
    {
        using Form form = new();
        form.Show();

        form.SetProgressValue(50, 100);
    }

    [WinFormsFact]
    public void SetThumbnailTooltip()
    {
        using Form form = new();
        form.Show();

        form.SetThumbnailTooltip("Meow");
    }
}
